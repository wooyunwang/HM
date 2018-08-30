using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;

namespace HM.FacePlatform.UserControls
{
    public partial class ucNoCheck : UserControl
    {
        public Action<ucNoCheck> CheckAction;

        public Register _registerWithUser { get; set; }
        public bool isForCheck = true;
        public bool IsSelect { get; set; }

        private Image _Photo = Properties.Resources.userPhoto;

        public ucNoCheck()
        {
            InitializeComponent();
        }

        private void ucNoCheck_Load(object sender, EventArgs e)
        {
            ReFlash();
        }

        public void ReFlash()
        {
            if (!isForCheck)
            {
                btnCheck.Text = "查看";
                cbSel.Visible = false;
                labCheckState.Visible = true;
            }

            picPhoto.BackgroundImage = _Photo;
            if (!string.IsNullOrEmpty(_registerWithUser.photo_path)) picPhoto.ImageLocation = Path.Combine(FacePlatformCache.GetPictureDirectory(), _registerWithUser.photo_path);

            this.LblName.Text = _registerWithUser.user.name;
            this.LblTime.Text = _registerWithUser.user.reg_time.ToString("yyyy-MM-dd HH:mm:ss");
            this.LblRegisterType.Text = Utils_.EnumHelper.GetName(_registerWithUser.register_type);

            switch (_registerWithUser.check_state)
            {
                case CheckType.审核不通过:
                    {
                        this.labCheckState.Text = "不通过";
                        this.labCheckState.ForeColor = Color.Red;
                    }
                    break;
                case CheckType.审核通过:
                    {
                        this.labCheckState.Text = "通过";
                        this.labCheckState.ForeColor = Color.Green;
                    }
                    break;
                case CheckType.待审核:
                    {
                        this.labCheckState.Text = "待审核";
                        this.labCheckState.ForeColor = Color.Blue;
                    }
                    break;
                default:
                    {
                        this.labCheckState.Text = "未知";
                        this.labCheckState.ForeColor = Color.Black;
                    }
                    break;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (CheckAction != null)
            {
                CheckAction(this);
            }
        }

        private void cbSel_CheckedChanged(object sender, EventArgs e)
        {
            IsSelect = cbSel.Checked;
        }

        public void SelectCheckBox(bool isSelect)
        {
            cbSel.Checked = isSelect;
            IsSelect = isSelect;
        }


    }
}
