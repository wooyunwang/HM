using System;
using System.IO;
using System.Windows.Forms;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;

namespace HM.FacePlatform.UserControls
{
    public partial class ImageItem : UserControl
    {
        public event Action<ImageItem> DeleteImageAction;
        public Register _register { get; set; }
        public bool isShowDelete = true;
        public ImageItem(HM.FacePlatform.Model.Register _register)
        {
            this._register = _register;
            InitializeComponent();
        }

        private void ImageItem_Load(object sender, EventArgs e)
        {
            if(_register.id > 0)
            {
                picImage.ImageLocation = Path.Combine(FacePlatformCache.GetPictureDirectory(), _register.photo_path);
            }
            else
            {
                picImage.ImageLocation = _register.photo_path;
            }

            if (!isShowDelete) btnDeleteImage.Visible = false;
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (DeleteImageAction != null) DeleteImageAction(this);
        }

    }
}
