using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Forms;
using HM.FacePlatform.Model;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HM.FacePlatform.UserControls
{
    public partial class ucFamily : UserControl
    {
        public event Action<ucFamily> UpdateAction;
        Image _photo = Properties.Resources.userPhoto;
        Image _unregistered = Properties.Resources.unregistered;
        Image _registered = Properties.Resources.registed;

        public UserHouse _userHouse { get; set; }
        public House _house { get; set; }
        public User _user { get; set; }
        public RegisterBLL _registerBLL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHouse">关系对象必须包括用户信息和房屋信息</param>
        public ucFamily(UserHouse userHouse)
        {
            InitializeComponent();
            _registerBLL = new RegisterBLL();
            _userHouse = userHouse;
            _user = userHouse.User;
            _house = userHouse.House;
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
            Register register = _registerBLL.FirstOrDefault(it => it.is_del != IsDelType.是 && it.user_uid == _user.user_uid, true, it => it.id);

            picPhoto.BackgroundImage = _photo;
            picPhoto.ImageLocation = string.IsNullOrEmpty(register.photo_path) ? null : Path.Combine(MainForm.picturePath, register.photo_path);
            lblName.Text = $"{ _user.name }({ _user.mobile })";
            lblUserType.Text = EnumHelper.GetName(_userHouse.user_type);

            if (_userHouse.user_type == UserType.工作人员)
            {
                if (!string.IsNullOrEmpty(_user.job))
                    lblUserType.Text = _user.job;
            }
            else
            {
                if (!string.IsNullOrEmpty(_userHouse.relation))
                    lblUserType.Text += " (" + _userHouse.relation + ")";
            }
            lblSex.Text = EnumHelper.GetName(_user.sex);
            lblDataFrom.Text = EnumHelper.GetName(_user.data_from);
            lblId.Text = _userHouse.id.ToString();
            switch (_user.check_state)
            {
                case CheckType.审核不通过:
                    picIsRegisted.Image = _unregistered;
                    break;
                case CheckType.审核通过:
                    picIsRegisted.Image = _registered;
                    break;
                case CheckType.待审核:
                    //wait 需添加待审核图片，及相关待审核的逻辑处理
                    break;
                default:
                    break;
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            PhotoRegisterFrm photoRegFrm = new PhotoRegisterFrm(this);
            photoRegFrm.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateAction != null)
            {
                UpdateAction(this);
            }
        }
    }
}
