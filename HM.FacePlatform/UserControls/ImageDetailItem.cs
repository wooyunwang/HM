using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Utils_;

namespace HM.FacePlatform.UserControls
{
    public partial class ImageDetailItem : UserControl
    {
        #region 模板参数定义
        public Action<ImageDetailItem> ActionComplete;

        public Register _register { get; set; }

        private Image _Photo = Properties.Resources.userPhoto;


        #endregion
        public ImageDetailItem(Register _register)
        {
            this._register = _register;

            InitializeComponent();
        }

        private void ImageDetailItem_Load(object sender, EventArgs e)
        {
            ReFlash();
        }

        public void ReFlash()
        {
            picPhoto.BackgroundImage = _Photo;

            if (!string.IsNullOrEmpty(_register.photo_path)) picPhoto.ImageLocation = Path.Combine(FacePlatformCache.GetPictureDirectory(), _register.photo_path);

            this.labCreateTime.Text = _register.create_time.ToString();
            this.lblRegisterType.Text = EnumHelper.GetName(_register.register_type) + " (" + EnumHelper.GetName(_register.check_state) + ")";
        }

        private void ImageDetailItem_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((ImageDetailItem)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {

            if (ActionComplete != null)
            {
                ActionComplete(this);
            }
        }

    }
}
