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
using VO;

namespace HM.FacePlatform.Forms
{
    public delegate void ThreadDelegate();
    public partial class PhotoRegisterFrm : HMForm
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
            _userHouse = ucFamily._userHouse;
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
        private void btn_SelPic_Click(object sender, EventArgs e)
        {
            ClearMessage();
            var result = _maoBLL.CheckMao();
            if (result.IsSuccess)
            {
                SelectPicture();
            }
            else
            {
                var badMaos = result.Obj.Where(it => it.Value.Item1 == false)
                    .Select(it => it.Value).Select(it => it.Item2);
                foreach (var mao in badMaos)
                {
                    ShowMessage($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！", MessageType.Error);
                }
                ShowMessage("这将导致注册失败！", MessageType.Error);
            }
        }
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
                            string compressImageName = Path.Combine(compressDirectory, Guid.NewGuid().ToString(), ".jpg");
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
                        string compressImageName = Path.Combine(compressDirectory, Guid.NewGuid().ToString(), ".jpg");
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

                    LoadLoading();

                    Mao mao = FacePlatformCache.GetALL<Mao>().FirstOrDefault();
                    foreach (var imagePath in lstCompressImage)
                    {
                        string faceId = Key_.SequentialGuid();
                        Face.Common_.Face face = Face.Common_.FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), Face.Common_.FaceVender.EyeCool);
                        ActionResult result = face.Checking(faceId, RegisterType.手动注册, imagePath, "");
                        if (!result.IsSuccess)
                        {
                            HMMessageBox.Show(this, result.ToAlertString());
                            continue;
                        }
                        else
                        {
                            Add_PhotoToList(new PicUrlAndFaceIDVO
                            {
                                FaceID = faceId,
                                PicUrl = imagePath,
                                mao_id = mao.id
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
                finally
                {
                    CloseLoding();//要开启
                }
            }
        }

        private void Add_PhotoToList(PicUrlAndFaceIDVO regPicUrlAndFaceID)//a2
        {
            if (!File.Exists(regPicUrlAndFaceID.PicUrl))
            {
                return;
            }

            if (_dicPhoto.ContainsKey(regPicUrlAndFaceID.PicUrl))
            {
                return;
            }

            _dicPhoto.Add(regPicUrlAndFaceID.PicUrl, regPicUrlAndFaceID);
            RefreshPhotoList();
        }

        /// <summary>
        /// 刷新照片列表
        /// </summary>
        private void RefreshPhotoList()
        {
            pnToRegister.Controls.Clear();
            Register _register = new Register();
            foreach (PicUrlAndFaceIDVO item in _dicPhoto.Values)
            {
                _register.photo_path = item.PicUrl;
                ImageItem imageItem = new ImageItem(_register);
                pnToRegister.Controls.Add(imageItem);
                imageItem.DeleteImageAction += new Action<ImageItem>(DeleteToRegisterImage);
            }
        }

        private void DeleteToRegisterImage(ImageItem imageItem)
        {
            if (HMMessageBox.Show(this, "确定要删除该照片吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            _dicPhoto.Remove(imageItem._register.photo_path);
            RefreshPhotoList();
        }
        #endregion

        #region 打开或关闭loading窗体
        /// <summary>
        /// 关闭loading窗体
        /// </summary>
        private void CloseLoding()
        {
            try
            {
                ThreadDelegate td = delegate
                {
                    frmLoading.Close();
                };
                if (frmLoading.InvokeRequired)
                    frmLoading.Invoke(td);
                else
                    td();
            }
            catch
            { }
        }

        /// <summary>
        /// 打开loading窗体
        /// </summary>
        private void LoadLoading()
        {
            try
            {
                new Thread(new ThreadStart(delegate
                {
                    if (frmLoading != null)
                    {
                        if (frmLoading.IsDisposed)
                            frmLoading = new Form_Loading();//如果已经销毁，则重新创建子窗口对象

                        frmLoading.StartPosition = FormStartPosition.CenterScreen;
                        frmLoading.TopLevel = true;
                        frmLoading.ShowDialog();
                    }
                    else
                    {
                        frmLoading = new Form_Loading();
                        frmLoading.StartPosition = FormStartPosition.CenterScreen;
                        frmLoading.TopLevel = true;
                        frmLoading.ShowDialog();
                    }


                })).Start();
            }
            catch { }
        }
        #endregion

        #region 注册人脸
        private void btn_RegisterTemp_Click(object sender, EventArgs e)
        {
            ClearMessage();

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

            LoadLoading();

            DateTime endDate = tbEnd.Value.AddDays(1).AddSeconds(-1);
            if (!tbEnd.Visible)
            {
                int defaultDays = Config_.GetInt("FaceEndTime") ?? 365;
                endDate = DateTime.Now.AddDays(defaultDays + 1).AddSeconds(-1);
            }
            List<string> toRemovePhotoUrl = new List<string>();
            IList<Mao> maos = FacePlatformCache.GetALL<Mao>();
            Mao mao = maos.FirstOrDefault();
            var register = _registerBLL.FirstOrDefault(it => it.is_del != IsDelType.是 && it.user_uid == _ucFamily._user.user_uid);
            foreach (PicUrlAndFaceIDVO item in _dicPhoto.Values)
            {
                ShowMessage("##开始注册：" + item.PicUrl, MessageType.Information);

                Face.Common_.Face face = Face.Common_.FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), Face.Common_.FaceVender.EyeCool);

                string faceId = string.Empty;
                if (string.IsNullOrEmpty(item.FaceID))
                {
                    faceId = Key_.SequentialGuid();
                    ActionResult result = face.Checking(faceId, RegisterType.手动注册, item.PicUrl, "");
                    if (!result.IsSuccess)
                    {
                        ShowMessage(string.Format("**{0}", result.ToAlertString()), MessageType.Warning);
                        continue;
                    }
                    else
                    {
                        item.FaceID = faceId;
                        item.mao_id = mao.id;
                    }
                }

                if (register == null && !string.IsNullOrWhiteSpace(register.face_id))
                {
                    ActionResult result = face.MatchCompare2(item.FaceID, RegisterType.手动注册, register.face_id);
                    if (!result.IsSuccess)
                    {
                        ShowMessage(result.ToAlertString(), MessageType.Warning);
                        continue;
                    }
                }

                string savedPictureName = _registerBLL.FileSaveAs(item.PicUrl, FacePlatformCache.GetPictureDirectory());//保存图片到本地
                if (string.IsNullOrEmpty(savedPictureName))
                {
                    ShowMessage("**图片保存失败，请稍后重试", MessageType.Error);
                    continue;
                }

                faceId = Key_.SequentialGuid();//faceId需要重新生成

                Register newRegister = new Register
                {
                    user_uid = _ucFamily._user.user_uid,
                    face_id = faceId,
                    photo_path = savedPictureName,
                    register_type = RegisterType.手动注册,
                    check_state = CheckType.审核通过,
                };
                var registerResult = _registerBLL.Add(newRegister);
                if (!registerResult.IsSuccess)
                {
                    ShowMessage("**数据库异常，请稍后重试", MessageType.Error);
                    continue;
                }

                toRemovePhotoUrl.Add(item.PicUrl);//图片添加到删除列表

                foreach (Mao itemMao in maos)
                {
                    Face.Common_.Face faceItem = Face.Common_.FaceFactory.CreateFace(itemMao.GetIP(), itemMao.GetPort(), Face.Common_.FaceVender.EyeCool);
                    var registerResultItem = faceItem.Register(new Face.Common_.RegisterInput()
                    {
                        activeTime = endDate,
                        Birthday = _ucFamily._user.birthday,
                        CertificateType = Face.Common_.EyeCool.CertificateType.唯一标识,
                        cNO = itemMao.mao_no,
                        CRMId = _ucFamily._user.user_uid,
                        FaceId = faceId,
                        Name = _ucFamily._user.name,
                        PeopleId = "",
                        Phone = "",
                        ProjectCode = Program._Mainform._ProjectCode,
                        RegisterType = RegisterType.手动注册,
                        RoomNo = _ucFamily._house.roomnumber,
                        Sex = _ucFamily._user.sex,
                        UserType = _ucFamily._userHouse.relation
                    });

                    if (registerResultItem.IsSuccess)
                    {
                        ShowMessage("**" + itemMao.mao_name + "，注册成功", MessageType.Success);

                        if (register == null)
                        {
                            register = _registerBLL.FirstOrDefault(it => it.is_del != IsDelType.是 && it.user_uid == _ucFamily._user.user_uid);
                        }
                    }
                    else
                    {
                        ShowMessage("**" + itemMao.mao_name + "，注册失败(稍后将自动重试)：" + registerResultItem.ToAlertString(), MessageType.Error);

                        MaoFailedJob job = new MaoFailedJob
                        {
                            register_or_user_id = newRegister.id,
                            mao_id = itemMao.id,
                            job_type = JobType.注册,
                        };
                        _maoFailedJobBLL.AddOrUpdate(it => new
                        {
                            it.register_or_user_id,
                            it.mao_id,
                            it.job_type
                        }, job);
                    }
                }
            }

            foreach (string url in toRemovePhotoUrl)
            {
                _dicPhoto.Remove(url);
            }
            RefreshPhotoList();
            FillRegistedList();

            tbEnd.Enabled = false;//有效期不能更改

            CloseLoding();
        }
        /// <summary>
        /// 填充已注册模板
        /// </summary>
        private void FillRegistedList()
        {
            pnRegisted.Controls.Clear();
            IList<Register> registers = _registerBLL.Get(it => it.user_uid == _user.user_uid && it.is_del != IsDelType.是);

            foreach (Register _register in registers)
            {
                ImageItem imageItem = new ImageItem(_register);
                pnRegisted.Controls.Add(imageItem);
                imageItem.DeleteImageAction += new Action<ImageItem>(DeleteRegistedImage);
            }
        }
        /// <summary>
        /// 删除已注册模板
        /// </summary>
        /// <param name="imageItem"></param>
        private void DeleteRegistedImage(ImageItem imageItem)
        {
            if (HMMessageBox.Show(this, "此人脸已审核通过，确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            LoadLoading();
            ClearMessage();

            ActionResult result;
            DateTime change_time = DateTime.Now;
            imageItem._register.change_time = change_time;
            IList<Mao> maos = FacePlatformCache.GetALL<Mao>();
            foreach (Mao mao in maos)
            {
                Face.Common_.Face face = Face.Common_.FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), Face.Common_.FaceVender.EyeCool);

                result = face.FaceDel(_user.people_id, new List<string>() { imageItem._register.face_id });

                if (result.IsSuccess)
                {
                    ShowMessage("**" + mao.mao_name + "，删除成功", MessageType.Success);
                }
                else
                {
                    ShowMessage("**" + mao.mao_name + "，删除失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

                    MaoFailedJob job = new MaoFailedJob
                    {
                        register_or_user_id = imageItem._register.id,
                        mao_id = mao.id,
                        job_type = JobType.删除,
                    };
                    _maoFailedJobBLL.AddOrUpdate(it => new
                    {
                        it.register_or_user_id,
                        it.mao_id,
                        it.job_type
                    }, job);
                }
            }

            FillRegistedList();

            bool userRegisted = _registerBLL.Any(it => it.user_uid == _user.user_uid && it.is_del != IsDelType.是);
            if (!userRegisted)
            {
                _user.check_state = CheckType.待审核;
                _userBLL.Edit(_user);
            }

            CloseLoding();
        }

        private void ShowMessage(string message, MessageType type)
        {
            ed_ResultBox.AppendText(message + "\r\n", MessageColor.GetColorByMessgaeType(type));
        }

        private void ClearMessage()
        {
            ed_ResultBox.Text = string.Empty;
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
            _camera.CapturedEvent += cameraCapturedEvent;
            _camera.Show();
        }

        private void cameraCapturedEvent()
        {
            string filePath = _camera.captureSavedName;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                PicUrlAndFaceIDVO picFace = new PicUrlAndFaceIDVO
                {
                    PicUrl = filePath,
                };
                Add_PhotoToList(picFace);
            }
        }
        #endregion
    }
}
