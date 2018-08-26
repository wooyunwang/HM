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
        public ImageItem(Register _register)
        {
            this._register = _register;
            InitializeComponent();
        }

        private void ImageItem_Load(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (_register.id > 0)
            {
                path = Path.Combine(FacePlatformCache.GetPictureDirectory(), _register.photo_path);
            }
            else
            {
                path = _register.photo_path;
            }
            picImage.Image = Utils_.Image_.ReadImage(path);
            if (!isShowDelete) btnDeleteImage.Visible = false;
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (DeleteImageAction != null) DeleteImageAction(this);
        }
        /// <summary>
        /// 
        /// </summary>
        public void DeleteImage()
        {
            string path = string.Empty;
            if (_register.id > 0)
            {
                path = Path.Combine(FacePlatformCache.GetPictureDirectory(), _register.photo_path);
            }
            else
            {
                path = _register.photo_path;
            }
            File.Delete(path);
        }
    }
}
