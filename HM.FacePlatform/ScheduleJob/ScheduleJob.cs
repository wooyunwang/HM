using HM.Common_;
using Quartz;
using Quartz.Impl;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM.Enum_;
using HM.Form_;

namespace HM.FacePlatform
{
    public partial class ScheduleJob : Form
    {
        private readonly IScheduler scheduler;

        int formMiddleHeight;
        int formWidth;
        int formMinHeight;
        public ScheduleJob()
        {
            InitializeComponent();

            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        private void ScheduleJob_Load(object sender, EventArgs e)
        {
            formMiddleHeight = this.Height;
            formWidth = this.Width;
            formMinHeight = this.pnHead.Height;

            ResetLoaction();

            Task.Run(() =>
            {
                ProgressBarRun();
            });

            Task.Run(() =>
            {
                //ShowMessage("系统启动", MessageType.Information);

                BaseJob.jobFrom = this;

                scheduler.Start();
            });
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            btnMax.BackgroundImage = Properties.Resources.Middlemum;
            btnMax.Tag = "1";

            this.Size = new Size(formWidth, formMinHeight);
            ResetLoaction();
            this.TopMost = true;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            string isMax = btnMax.Tag.ToString();


            if (isMax == "0")
            {
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(formWidth, formMiddleHeight);
                ResetLoaction();
                this.TopMost = true;
            }

            btnMax.Tag = isMax == "0" ? "1" : "0";

            btnMax.BackgroundImage = isMax == "0" ? Properties.Resources.Middlemum : Properties.Resources.Maximum;
        }

        private void ProgressBarRun()
        {
            while (true)
            {
                this.UIThread(() =>
                {
                    pbProcess.Value = (pbProcess.Value + 1) % pbProcess.Maximum;
                });

                Thread.Sleep(1000);
            }
        }

        public void ShowMessage(string message, MessageType type)
        {
            this.UIThread(() =>
            {
                tbMessage.AppendText(string.Format("{0}：{1}\r\n", DateTime.Now, message)
                    , MessageColor.GetColorByMessgaeType(type));
            });
        }

        private void ResetLoaction()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width - 5,
                                      workingArea.Bottom - Size.Height - 5);
        }

        /// <summary>
        /// 禁止关闭此form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScheduleJob_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                //应用程序要求关闭窗口
                case CloseReason.ApplicationExitCall:
                    e.Cancel = false; //不拦截，响应操作
                    break;
                //自身窗口上的关闭按钮
                case CloseReason.FormOwnerClosing:
                    e.Cancel = true;//拦截，不响应操作
                    break;
                //MDI窗体关闭事件
                case CloseReason.MdiFormClosing:
                    e.Cancel = true;//拦截，不响应操作
                    break;
                //不明原因的关闭
                case CloseReason.None:
                    break;
                //任务管理器关闭进程
                case CloseReason.TaskManagerClosing:
                    e.Cancel = false;//不拦截，响应操作
                    break;
                //用户通过UI关闭窗口或者通过Alt+F4关闭窗口
                case CloseReason.UserClosing:
                    e.Cancel = true;//拦截，不响应操作
                    break;
                //操作系统准备关机
                case CloseReason.WindowsShutDown:
                    e.Cancel = false;//不拦截，响应操作
                    break;
                default:
                    break;
            }
        }

        private void menuClear_Click(object sender, EventArgs e)
        {
            tbMessage.Text = string.Empty;
        }
    }
}
