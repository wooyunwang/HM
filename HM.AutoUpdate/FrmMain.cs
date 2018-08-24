using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.AutoUpdate
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 是否正在更新
        /// </summary>
        bool _thisIsUpdating { get; set; }
        /// <summary>
        /// 是否正在更新
        /// </summary>
        bool _IsUpdating
        {
            get
            {
                return _thisIsUpdating;
            }
            set
            {
                UIThread(() =>
                {
                    btnFinish.Enabled = !value;
                    btnCancel.Enabled = !value;
                    btnNext.Enabled = !value;
                });
                _thisIsUpdating = value;
            }
        }
        int _Number = 4;
        UpdateHelper _UpdateHelper = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _UpdateHelper = new UpdateHelper
            {
                _OnError = OnError,
                _OnProgress = OnProgress,
                _OnPercent = OnPercent
            };
            _UpdateHelper.Init();
        }
        /// <summary>
        /// 错误事件
        /// </summary>
        /// <param name="error"></param>
        void OnError(string error)
        {
            UIThread(() =>
            {
                MessageBox.Show(error, "异常提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maximum"></param>
        void OnProgress(int value, int maximum)
        {
            UIThread(() =>
            {
                pbDownFile.Value = value;
                pbDownFile.Maximum = maximum;
            });
        }
        /// <summary>
        /// 处理事件
        /// </summary>
        void OnPercent(string key, int percent)
        {
            UIThread(() =>
            {
                foreach (ListViewItem item in this.lvUpdateList.Items)
                {
                    if (item.SubItems[1].Text == key)
                    {
                        item.SubItems[2].Text = percent + "%";
                        break;
                    }
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Shown(object sender, EventArgs e)
        {
            Lazy<bool> lz = new Lazy<bool>(InitUpdateList);
            _IsUpdating = false;
            btnFinish.Visible = false;
            btnNext.Visible = lz.Value;
        }
        private bool InitUpdateList()
        {
            List<ZipFileInfo> lstZipFileInfo = _UpdateHelper.CheckForUpdate();
            if (lstZipFileInfo.Any())
            {
                foreach (var zipFileInfo in lstZipFileInfo)
                {
                    lvUpdateList.Items.Add(new ListViewItem(
                        new string[] {
                        zipFileInfo.Name?.Replace(AutoUpdate.UpdateHelper._ZipSuffix, ""),
                        zipFileInfo.Key,
                        zipFileInfo.Size
                    }));
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this._IsUpdating == true)
            {
                if (MessageBox.Show("系统正在更新中，你确认要退出系统吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    this.timer1.Enabled = false;
                    this.timer1.Stop();
                    this.timer1.Dispose();
                    Application.ExitThread();
                    Application.Exit();
                }
            }
            else
            {
                this.timer1.Enabled = false;
                this.timer1.Stop();
                this.timer1.Dispose();
                Application.ExitThread();
                Application.Exit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!_IsUpdating)
            {
                try
                {
                    this.timer1.Enabled = false;
                    this.timer1.Stop();
                    _UpdateHelper.FinishUpdate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Close();
                    this.Dispose();
                    Application.ExitThread();
                    Application.Exit();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_IsUpdating)
            {
                Task.Run(() =>
                {
                    if (lvUpdateList.Items.Count > 0)
                    {
                        _IsUpdating = true;
                        var lstMsg = _UpdateHelper.DownUpdateFile();
                        if (lstMsg.Any())
                        {
                            UIThread(() =>
                            {
                                string msg = string.Join(Environment.NewLine, lstMsg.Select(it => it.Message).Distinct().ToArray());
                                MessageBox.Show("更新文件下载失败：" + Environment.NewLine + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            });
                            InvalidateControl(false);
                        }
                        else
                        {
                            InvalidateControl(true);
                        }
                    }
                    else
                    {
                        UIThread(() =>
                        {
                            MessageBox.Show("没有可用的更新!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                });
            }
        }
        /// <summary>
        /// 重新绘制窗体部分控件属性
        /// </summary>
        private void InvalidateControl(bool isOK)
        {
            _IsUpdating = false;
            if (isOK)
            {
                UIThread(() =>
                {
                    btnNext.Visible = false;
                    btnCancel.Visible = false;
                    btnFinish.Location = btnCancel.Location;
                    btnFinish.Visible = true;
                    timer1.Enabled = true;
                    timer1.Start();
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_IsUpdating)
            {
                return;
            }
            this.Close();
            Application.ExitThread();
            Application.Exit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            _Number--;
            this.btnFinish.Text = "完成(" + _Number + "s)";
            if (_Number < 1)
            {
                btnFinish_Click(sender, e);
            }
        }

        /// <summary>
        /// 在需要的情况下，开辟新的线程更新UI
        /// </summary>
        /// <param name="methodInvoker"></param>
        public void UIThread(MethodInvoker methodInvoker)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(methodInvoker);
            }
            else methodInvoker();
        }
    }
}
