using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Form_;
using HM.Utils_;

namespace HM.FacePlatform.UserControls
{
    public partial class ImageDetailItem : HMUserControl
    {
        public Action<ImageDetailItem> DeleteImageAction;

        public Register _registerWithUser { get; set; }

        private Image _Photo = Properties.Resources.userPhoto;

        public ImageDetailItem(Register registerWithUser)
        {
            this._registerWithUser = registerWithUser;

            InitializeComponent();
        }

        private void ImageDetailItem_Load(object sender, EventArgs e)
        {
            ReFlash();
        }

        public void ReFlash()
        {
            picPhoto.BackgroundImage = _Photo;

            if (!string.IsNullOrEmpty(_registerWithUser.photo_path)) picPhoto.ImageLocation = Path.Combine(FacePlatformCache.GetPictureDirectory(), _registerWithUser.photo_path);

            this.LblCreateTime.Text = _registerWithUser.create_time.ToString("yyyy-MM-dd HH:mm:ss");
            this.LblCheckType.Text = EnumHelper.GetName(_registerWithUser.check_state);
            this.LblRegisterType.Text = EnumHelper.GetName(_registerWithUser.register_type);
        }

        private void ImageDetailItem_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((ImageDetailItem)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (DeleteImageAction != null)
            {
                DeleteImageAction(this);
            }
        }

    }
}
