using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using HM.Form_;

namespace HM.FacePlatform.Forms
{
    public partial class ShowCamera : FrmBase
    {
        public delegate void CapturedEventHandler();
        public event CapturedEventHandler CapturedEvent;

        public string captureSavePath { get; set; }
        public string captureSavedName { get; set; }

        FilterInfoCollection videoDevicesList;
        IVideoSource videoSource;

        public ShowCamera()
        {
            InitializeComponent();
        }

        private void ShowCamera_Load(object sender, EventArgs e)
        {
            videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevicesList.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevicesList[0].MonikerString);
                videoPlayer.VideoSource = videoSource;
                videoPlayer.Start();
            }
            else
            {
                HMMessageBox.Show(this, "没有检测到摄像头", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = videoPlayer.GetCurrentVideoFrame();
            captureSavedName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
            captureSavedName = Path.Combine(captureSavePath, captureSavedName);
            bitmap.Save(captureSavedName, ImageFormat.Jpeg);

            if (CapturedEvent != null) CapturedEvent();
        }

        private void ShowCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }

    }


}
