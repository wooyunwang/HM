using HM.Common_;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Forms;
using HM.FacePlatform.Model;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform
{

    public delegate void closingHandler();

    public partial class MainForm : Form
    {

        public string _ProjectCode;
        public string _ProjectName;

        public string _PropertyHouseCode;
        public string _VirtualHouseCode;

        public static string picturePath;
        public static string capturePath;
        public static int pictureMaxSize;
        ScheduleJob scheduleJob;

        public static int maxRetryTime;

        ProjectBLL _projectBLL;

        private Button activeButton;

        private Color activeColor = Color.FromArgb(255, 67, 152, 237);
        private Color unActiveColor = SystemColors.ActiveCaptionText;

        public static Hashtable htControl = new Hashtable();

        public event closingHandler closingHandler;

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            _projectBLL = new ProjectBLL();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (Program.IsAdmin()) btnUserManage.Visible = true;

            picturePath = Utils_.Config_.GetString("PicturePath");
            capturePath = Utils_.Config_.GetString("CapturePath");
            pictureMaxSize = Utils_.Config_.GetInt("PictureMaxSize") ?? 0;
            maxRetryTime = Utils_.Config_.GetInt("MaxRetryTime") ?? 0;

            Task.Run(() =>
            {
                try
                {
                    if (!Directory.Exists(picturePath)) Directory.CreateDirectory(picturePath);

                    if (!Directory.Exists(capturePath)) Directory.CreateDirectory(capturePath);
                }
                catch (Exception ex)
                {
                    LogHelper.Error("创建文件夹失败：" + ex.Message);
                }
            });

            activeButton = btnRegister;
            activeButton.BackColor = activeColor;
            btnRegister.PerformClick();
        }


        private void setActiveButton(Button button)
        {
            if (activeButton != button)
            {
                activeButton.BackColor = unActiveColor;
                activeButton = button;
                activeButton.BackColor = activeColor;
            }
        }

        private void setMouseLeaveButton(Button button)
        {
            if (activeButton != button)
            {
                button.BackColor = unActiveColor;
            }
        }

        private void setMouseEnterButton(Button button)
        {
            if (activeButton != button)
            {
                button.BackColor = activeColor;
            }
        }


        private void NavigationButtonClick(object sender, EventArgs e)
        {
            try
            {
                Button btnMenu = sender as Button;

                setActiveButton((Button)sender);
                pnlBottom.Height = this.Height - this.statusTip.Height - this.pnlTop.Height;
                pnlBottom.Width = this.Width - 15;


                if (btnMenu.Tag.ToString() == string.Empty)
                {
                    MessageBox.Show("该菜单未配置页面，请联系管理员！");
                    return;
                }
                if (htControl.Contains(btnMenu.Tag.ToString()))
                {
                    foreach (Control ctrl in pnlBottom.Controls)
                    {
                        if (ctrl.GetType().ToString() != btnMenu.Tag.ToString())
                        {
                            ctrl.Visible = false;
                        }
                        else
                        {
                            if (btnMenu.Tag.ToString() == "HM.FacePlatform.Check")
                            {
                                if (((Check)ctrl).HtcMain.SelectedIndex == 0)
                                {
                                    ((Check)ctrl).LoadData();
                                }
                            }
                            else if (btnMenu.Tag.ToString() == "HM.FacePlatform.Register")
                            {
                                ((ucRegister)ctrl).BindWorkers();
                            }
                            //else
                            //if (btnMenu.Tag.ToString() == "HM.FacePlatform.Count")//统计的
                            //{
                            //    if (((FacePlatform.Count)ctrl).tabControl1.SelectedIndex == 0)
                            //    {
                            //        ((FacePlatform.Count)ctrl).btnThisMonth_Click(sender, e);
                            //    }
                            //    else
                            //    {
                            //        ((FacePlatform.Count)ctrl).btnThisMonthB_Click(sender, e);
                            //    }
                            //}
                            ctrl.Visible = true;
                        }
                    }
                }
                else
                {
                    string executablePath = Path.GetFileName(Application.ExecutablePath);
                    Assembly a = Assembly.LoadFrom(executablePath);
                    Type type = a.GetType(btnMenu.Tag.ToString());
                    UserControl UCObj = Activator.CreateInstance(type) as UserControl;


                    if (UCObj != null)
                    {
                        UCObj.Width = this.Width;
                        UCObj.Height = this.Height - this.statusTip.Height - this.pnlTop.Height;
                        UCObj.AutoScroll = true;
                        UCObj.Dock = DockStyle.Fill;
                        if (htControl[btnMenu.Tag.ToString()] == null)
                        {
                            htControl.Add(btnMenu.Tag.ToString(), UCObj);
                        }
                        this.pnlBottom.Controls.Add(UCObj);
                        foreach (Control ctrl in pnlBottom.Controls)
                        {
                            if (ctrl.GetType().ToString() != UCObj.ToString())
                            {
                                ctrl.Visible = false; ;
                            }
                        }
                    }
                }


                if (scheduleJob == null)
                {
                    scheduleJob = new ScheduleJob();
                }
                scheduleJob.Show();
            }
            catch (System.Exception ex)
            {
                LogHelper.Error("NavigationButtonClick()函数错误: " + ex.ToString());
            }

        }

        private void ButtonEnter(object sender, EventArgs e)
        {
            setMouseEnterButton((Button)sender);
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            setMouseLeaveButton((Button)sender);
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出程序？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process p = Process.GetCurrentProcess();
                if (p != null)
                {
                    p.Kill();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出程序？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process p = Process.GetCurrentProcess();
                if (p != null)
                {
                    p.Kill();
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ResetPassword form = new ResetPassword();
            form.Show();
        }

    }
}
