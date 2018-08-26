using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Forms;
using HM.FacePlatform.Model;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HM.Form_;

namespace HM.FacePlatform.UserControls
{
    public partial class UcFamily : UserControl
    {
        public Action<UcFamily> UpdateAction;
        public Action DeleteAction;
        Image _photo = Properties.Resources.userPhoto;
        Image _unregistered = Properties.Resources.unregistered;
        Image _registered = Properties.Resources.registed;

        public UserHouse _userHouseWithUserAndHouse { get; set; }
        public House _house { get; set; }
        public User _user { get; set; }
        public RegisterBLL _registerBLL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHouseWithUserAndHouse">关系对象必须包括用户信息和房屋信息</param>
        public UcFamily(UserHouse userHouseWithUserAndHouse)
        {
            InitializeComponent();
            _registerBLL = new RegisterBLL();
            _userHouseWithUserAndHouse = userHouseWithUserAndHouse;
            try
            {
                _user = userHouseWithUserAndHouse.User;
                _house = userHouseWithUserAndHouse.House;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFamily_Load(object sender, EventArgs e)
        {
            Init();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            this.UIThread(() =>
            {
                picPhoto.BackgroundImage = _photo;

                IList<Register> lstRegister = _registerBLL.Get(it => it.is_del != IsDelType.是 && it.user_uid == _user.user_uid && it.check_state != CheckType.审核不通过, true, it => it.id);
                if (lstRegister.Any())
                {
                    var register = lstRegister.FirstOrDefault();
                    picPhoto.ImageLocation = string.IsNullOrEmpty(register.photo_path) ? null : Path.Combine(FacePlatformCache.GetPictureDirectory(), register.photo_path);
                    lblCountCompare.Text = lstRegister.Where(it => it.check_state == CheckType.审核通过).Count() + "-" + lstRegister.Count;
                }
                else
                {
                    picPhoto.ImageLocation = null;
                    lblCountCompare.Text = "0-0";
                }

                lblName.Text = _user.name + (string.IsNullOrWhiteSpace(_user.mobile) ? "" : $"（{_user.mobile}）");
                lblUserType.Text = EnumHelper.GetName(_userHouseWithUserAndHouse.user_type);

                if (_userHouseWithUserAndHouse.user_type == UserType.工作人员)
                {
                    if (!string.IsNullOrEmpty(_user.job))
                        lblUserType.Text = _user.job;
                }
                else
                {
                    if (!string.IsNullOrEmpty(_userHouseWithUserAndHouse.relation))
                        lblUserType.Text += " (" + _userHouseWithUserAndHouse.relation + ")";
                }
                lblSex.Text = EnumHelper.GetName(_user.sex);
                lblDataFrom.Text = EnumHelper.GetName(_user.data_from);
                switch (_user.check_state)
                {
                    case CheckType.审核不通过:
                        picIsRegisted.Image = _unregistered;
                        break;
                    case CheckType.审核通过:
                        picIsRegisted.Image = _registered;
                        break;
                    case CheckType.待审核:
                        picIsRegisted.Image = _registered;
                        //wait 需添加待审核图片，及相关待审核的逻辑处理
                        break;
                    default:
                        break;
                }

                if (_user.data_from == DataFromType.CRM)
                {
                    BtnDelete.Enabled = false;
                }
            });
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, EventArgs e)
        {
            PhotoRegisterFrm photoRegFrm = new PhotoRegisterFrm(this);
            DialogResult dr = photoRegFrm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Init();
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateAction != null)
            {
                UpdateAction(this);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<List<Mao>> checkResult = faceJobFrm.BasicCheck(true);
            if (checkResult.IsSuccess)
            {
                faceJobFrm.DeleteUserHouse(checkResult.Obj, _userHouseWithUserAndHouse);
                DialogResult dr = faceJobFrm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (DeleteAction != null)
                    {
                        DeleteAction();
                    }
                }
            }
        }
    }
}
