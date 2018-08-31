using HM.Common_;
using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.FacePlatform.UserControls;
using HM.Form_;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM.FacePlatform.VO;

namespace HM.FacePlatform.Forms
{
    public delegate void ThreadDelegate();
    public partial class PhotoRegisterFrm : FrmBase
    {
        MaoFailedJobBLL _maoFailedJobBLL;
        RegisterBLL _registerBLL;
        UserBLL _userBLL;
        MaoBLL _maoBLL;
        UcFamily _ucFamily;
        UserHouse _userHouse;
        User _user;
        House _house;
        ShowCamera _camera;

        Form_Loading frmLoading = new Form_Loading();

        public Dictionary<string, PicUrlAndFaceIDVO> _dicPhoto = new Dictionary<string, PicUrlAndFaceIDVO>();

        public PhotoRegisterFrm(UcFamily ucFamily)
        {
            _ucFamily = ucFamily;
            _user = ucFamily._user;
            _userHouse = ucFamily._userHouseWithUserAndHouse;
            _house = ucFamily._house;
            _registerBLL = new RegisterBLL();
            _userBLL = new UserBLL();
            _maoBLL = new MaoBLL();
            _maoFailedJobBLL = new MaoFailedJobBLL();
            InitializeComponent();
        }

        private void PhotoRegisterFrm_Load(object sender, EventArgs e)
        {
            FillRegistedList();

            tbHouse.Text = _house.house_name;
            tbName.Text = _user.name;
            //否为访客，是否已有人脸有效期
            if (_userHouse.user_type == UserType.访客)
            {
                labEndTime.Visible = true;
                tbEnd.Visible = true;
                pnEndTime.Visible = true;
                tbEnd.Value = DateTime.Now.AddMonths(1);
            }
        }

        #region 选择照片
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelPic_Click(object sender, EventArgs e)
        {
            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck();
            if (checkResult.IsSuccess)
            {
                SelectPicture();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void SelectPicture()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "图片文件|*.jpg",
                Title = "选择模板图片",
                Multiselect = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int pictureMaxSize = FacePlatformCache.GetPictureMaxSize();
                    if (ofd.FileNames.Any(it => new FileInfo(it).Length > pictureMaxSize))
                    {
                        HMMessageBox.Show(this, "单张图片大小不能超过【" + pictureMaxSize / 1024 / 1024 + "M】");
                    }
                    string compressDirectory = FacePlatformCache.GetCompressDirectory();
                    List<string> lstCompressImage = new List<string>();

                    if (ofd.FileNames.Count() > 0)
                    {
                        Parallel.ForEach(ofd.FileNames, fileName =>
                        {
                            string compressImageName = Path.Combine(compressDirectory, Guid.NewGuid().ToString() + ".jpg");
                            bool isSuccess = Image_.CompressImage(fileName, compressImageName);
                            if (isSuccess)
                            {
                                lstCompressImage.Add(compressImageName);
                            }
                            else
                            {
                                lstCompressImage.Add(fileName);
                            }
                        });
                    }
                    else if (ofd.FileNames.Count() == 1)
                    {
                        string fileName = ofd.FileNames[0];
                        string compressImageName = Path.Combine(compressDirectory, Guid.NewGuid().ToString() + ".jpg");
                        bool isSuccess = Image_.CompressImage(fileName, compressImageName);
                        if (isSuccess)
                        {
                            lstCompressImage.Add(compressImageName);
                        }
                        else
                        {
                            lstCompressImage.Add(fileName);
                        }
                    }
                    else
                    {
                        return;
                    }
                    FaceJobFrm faceJobFrm = new FaceJobFrm();
                    var result = faceJobFrm.BasicCheck(user_uid: this._user.user_uid);
                    if (result.IsSuccess)
                    {
                        Task.Run(() =>
                        {
                            Mao mao = FacePlatformCache.GetALL<Mao>().FirstOrDefault();
                            foreach (var imagePath in lstCompressImage)
                            {
                                string faceId = Key_.SequentialGuid();
                                Face.Common_.Face face = Face.Common_.FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), Face.Common_.FaceVender.EyeCool);
                                ActionResult checkResult = face.Checking2(faceId, RegisterType.手动注册, imagePath, "客户端选择图片");
                                if (!checkResult.IsSuccess)
                                {
                                    HMMessageBox.Show(this, checkResult.ToAlertString());
                                    continue;
                                }
                                else
                                {
                                    AddPhotoToDic(new PicUrlAndFaceIDVO
                                    {
                                        face_id = faceId,
                                        image_path = imagePath,
                                        mao_id = mao.id
                                    });
                                }
                            }
                        }).ContinueWith((task) =>
                        {

                        });
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                    MessageBox.Show(Exception_.GetInnerException(ex).Message);
                }
            }
        }
        /// <summary>
        /// 将图片添加到字典
        /// </summary>
        /// <param name="regPicUrlAndFaceID"></param>
        private void AddPhotoToDic(PicUrlAndFaceIDVO regPicUrlAndFaceID)
        {
            if (!File.Exists(regPicUrlAndFaceID.image_path))
            {
                return;
            }

            if (_dicPhoto.ContainsKey(regPicUrlAndFaceID.image_path))
            {
                return;
            }

            _dicPhoto.Add(regPicUrlAndFaceID.image_path, regPicUrlAndFaceID);
            RefreshPhotoList();
        }

        /// <summary>
        /// 刷新照片列表
        /// </summary>
        private void RefreshPhotoList()
        {
            this.UIThread(() =>
            {
                pnToRegister.Controls.Clear();
                Register _register = new Register();
                foreach (PicUrlAndFaceIDVO item in _dicPhoto.Values)
                {
                    _register.photo_path = item.image_path;
                    ImageItem imageItem = new ImageItem(_register);
                    pnToRegister.Controls.Add(imageItem);
                    imageItem.DeleteImageAction = new Action<ImageItem>(DeleteToRegisterImage);
                }
            });
        }

        private void DeleteToRegisterImage(ImageItem imageItem)
        {
            if (HMMessageBox.Show(this, "确定要删除该照片吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            _dicPhoto.Remove(imageItem._register.photo_path);
            imageItem.DeleteImage();
            RefreshPhotoList();
        }
        #endregion


        #region 注册人脸
        private void btn_RegisterTemp_Click(object sender, EventArgs e)
        {
            if (_dicPhoto.Count < 1)
            {
                HMMessageBox.Show(this, "请上传或拍摄图片");
                return;
            }
            if (tbEnd.Visible && tbEnd.Value < DateTime.Now)
            {
                HMMessageBox.Show(this, "有效期时间不能小于当前时间");
                return;
            }

            DateTime? endDate = null;
            if (tbEnd.Visible)
            {
                endDate = tbEnd.Value.AddDays(1).AddSeconds(-1);
            }
            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck(user_uid: _ucFamily._user.user_uid);
            if (checkResult.IsSuccess)
            {
                faceJobFrm.Register(checkResult.Obj, _ucFamily._user, _dicPhoto.Values.ToList(), endDate, (lstPhotoUrlForRemove) =>
                 {
                     foreach (string url in lstPhotoUrlForRemove)
                     {
                         if (_dicPhoto.ContainsKey(url))
                         {
                             _dicPhoto.Remove(url);
                         }
                     }
                     RefreshPhotoList();
                     FillRegistedList();
                     _ucFamily.Init();
                     this.UIThread(() =>
                     {
                         tbEnd.Enabled = false;//有效期不能更改
                     });
                 });
                DialogResult dr = faceJobFrm.ShowDialog();
            }
        }
        /// <summary>
        /// 填充已注册模板
        /// </summary>
        private void FillRegistedList()
        {
            ActionResult<List<Register>> result = _registerBLL.GetWithUser(_user.user_uid);

            this.UIThread(() =>
            {
                FlpRegisted.Controls.Clear();
                if (result.IsSuccess)
                {
                    FlpRegisted.SuspendLayout();
                    foreach (Register registerWithUser in result.Obj)
                    {
                        ImageItem imageItem = new ImageItem(registerWithUser);
                        FlpRegisted.Controls.Add(imageItem);
                        if (imageItem.isShowDelete)
                        {
                            imageItem.DeleteImageAction = new Action<ImageItem>(DeleteRegistedImage);
                        }
                    }
                    FlpRegisted.ResumeLayout();
                    FlpRegisted.PerformLayout();
                }
                else
                {
                    HMMessageBox.Show(this, result.ToAlertString());
                }
            });
        }
        /// <summary>
        /// 删除已注册模板
        /// </summary>
        /// <param name="imageItem"></param>
        private void DeleteRegistedImage(ImageItem imageItem)
        {
            if (HMMessageBox.Show(this, "此人脸已审核通过，确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck(true);
            if (checkResult.IsSuccess)
            {
                faceJobFrm.DeleteRegistedImage(checkResult.Obj, _user, imageItem._register, () =>
                {
                    FillRegistedList();
                    _ucFamily.Init();
                });
            }
        }
        #endregion

        #region 摄像机注册
        private void btn_PCCamera_Click(object sender, EventArgs e)
        {
            IList<Mao> lstMao = FacePlatformCache.GetALL<Mao>();
            if (!lstMao.Any())
            {
                HMMessageBox.Show(this, "请先配置猫信息!");
                return;
            }

            _camera = new ShowCamera();
            _camera.captureSavePath = FacePlatformCache.GetCaptureDirectory();
            _camera.CapturedEvent += CameraCapturedEvent;
            _camera.Show();
        }

        private void CameraCapturedEvent()
        {
            string filePath = _camera.captureSavedName;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                PicUrlAndFaceIDVO picFace = new PicUrlAndFaceIDVO
                {
                    image_path = filePath,
                };
                AddPhotoToDic(picFace);
            }
        }
        #endregion
    }
}
