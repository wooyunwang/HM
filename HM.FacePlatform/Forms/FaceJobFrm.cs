using HM.Common_;
using HM.Enum_;
using HM.Form_;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM.FacePlatform.BLL;
using HM.FacePlatform.UserControls;
using HM.FacePlatform.Model;
using System.Threading;

namespace HM.FacePlatform.Forms
{
    /// <summary>
    /// 本窗口不能使用RichTextBox，否则界面卡顿不正常
    /// </summary>
    public partial class FaceJobFrm : HMForm
    {
        MaoBLL _maoBLL = new MaoBLL();
        UserBLL _userBLL = new UserBLL();

        /// <summary>
        /// Obj在此代表是否有任务正在进行中
        /// </summary>
        ActionResult<bool> _actionResult = new ActionResult<bool>() { Obj = false };

        public FaceJobFrm()
        {
            InitializeComponent();
            //屏蔽关闭按钮
            this.ControlBox = false;
        }

        private void FaceJobFrm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 基本的检查
        /// </summary>
        /// <returns></returns>
        public ActionResult BasicCheck()
        {
            return new ActionResult()
            {
                IsSuccess = true
            };
        }
        /// <summary>
        /// 审核
        /// </summary>
        public void Review()
        {
            //string project_code = Program._Mainform._ProjectCode;

            //ClearMessage();
            //ShowMessage($"##开始修改：{ dto.user_name }", MessageType.Information);

            //int check_by = Program._Account.id;
            //User user = _userBLL.FirstOrDefault(it => it.user_uid == dto.user_uid);
            //if (user == null)
            //{
            //    ShowMessage($"##找不到用户{dto.user_name}，可能已经被删除！", MessageType.Information);
            //}
            //else if (user.is_del == IsDelType.是)
            //{
            //    ShowMessage($"##用户{dto.user_name}，已被删除！", MessageType.Information);
            //}
            //else
            //{
            //    user.change_time = DateTime.Now;

            //    var result = _maoBLL.CheckAllMao();
            //    if (result.IsSuccess)
            //    {
            //        var faces = result.Obj.Where(it => it.Value.Item1 == true)
            //            .Select(it => it.Value).Select(it => it.Item3).ToList();
            //        RegPicList(faces, files);
            //    }
            //    else
            //    {
            //        var badMaos = result.Obj.Where(it => it.Value.Item1 == false)
            //            .Select(it => it.Value).Select(it => it.Item2);
            //        foreach (var mao in badMaos)
            //        {
            //            ShowMessage($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！", MessageType.Error);
            //        }
            //    }

            //    foreach (Mao _mao in _maos)
            //    {
            //        ActionResult result = _registerBLL.Check(user, check_state, "", check_by, project_code, _mao, isFirstMao);

            //        if (result.IsSuccess)
            //        {
            //            ShowMessage("**" + _mao.mao_name + "，修改成功", MessageType.Success);
            //        }
            //        else
            //        {
            //            ShowMessage("**" + _mao.mao_name + "，修改失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

            //            MaoFailedJob job = new MaoFailedJob
            //            {
            //                register_or_user_id = user.id,
            //                mao_id = _mao.id,
            //                job_type = JobType.审核,
            //            };
            //            _maoFailedJobBLL.AddOrUpdate(job);
            //        }

            //        isFirstMao = false;
            //    }

            //    this.PagerRegister.InnerBind();

            //    #region 定位到原来的行
            //    for (int i = 0; i < DgRegister.Rows.Count; i++)
            //    {
            //        if (DgRegister.Rows[i].Cells["col_user_uid"].Value.ToString() == theSelectUserID)
            //        {
            //            DgRegister.CurrentCell = DgRegister.Rows[i].Cells[0];

            //        }
            //    }
            //    #endregion
            //}
        }
        /// <summary>
        /// 设置延迟时间
        /// </summary>
        /// <param name="isYear"></param>
        public void SetEndTime(List<RegisterManageDto> data, bool isYear)
        {
            Task.Run(() =>
            {
                try
                {
                    _actionResult.Obj = true;
                    for (int i = 0; i < 1000; i++)
                    {
                        ShowMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}现在是测试{i}", MessageType.Information);
                        Thread.Sleep(10);
                    }
                    _actionResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
                finally
                {
                    _actionResult.Obj = false;
                }
            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });


            //DateTime endTime = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            //if (isYear)
            //{
            //    endTime = endTime.AddYears(1);
            //}
            //else
            //{
            //    endTime = endTime.AddMonths(1);
            //}

            //ActionResult result = new ActionResult();
            //foreach (DataGridViewRow dr in DgvRegister.Rows)
            //{
            //    if (Convert.ToBoolean(dr.Cells["colCB"].EditedFormattedValue.ToString()))
            //    {
            //        ShowMessage("##开始修改：" + dr.Cells["col_name"].EditedFormattedValue.ToString(), MessageType.Information);

            //        bool isFirstMao = true;
            //        string _user_uid = dr.Cells["col_user_uid"].EditedFormattedValue.ToString();
            //        User _user = _userBLL.Get(new { user_uid = _user_uid });
            //        _user.change_time = DateTime.Now;
            //        foreach (Mao _mao in _maos)
            //        {
            //            result = _registerBLL.UpdateExpireDate(_user, _mao, endTime, isFirstMao, Program._Account.id);

            //            if (result.IsSuccess)
            //            {
            //                ShowMessage("**" + _mao.mao_name + "，修改成功", MessageType.Success);
            //            }
            //            else
            //            {
            //                ShowMessage("**" + _mao.mao_name + "，修改失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

            //                MaoFailedJob job = new MaoFailedJob
            //                {
            //                    register_or_user_id = _user.id,
            //                    mao_id = _mao.id,
            //                    job_type = JobType.审核,
            //                };
            //                _maoFailedJobBLL.AddOrUpdate(job);
            //            }
            //            isFirstMao = false;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="imageItem"></param>
        private void DeleteRegistedImage(ImageDetailItem imageItem)
        {

            if (HMMessageBox.Show(this, "此人脸已审核通过，确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            ClearMessage();

            //HM.FacePlatform.Model.Register _register = imageItem._register.Cast<HM.FacePlatform.Model.Register>();

            //bool isFirstMao = true;
            //ActionResult result = new ActionResult();
            //DateTime change_time = DateTime.Now;
            //_register.change_time = change_time;
            //foreach (Mao _mao in _maos)
            //{
            //    result = _registerBLL.DeleteRegistedPhoto(selectedPeopleId, _register, MainForm.picturePath
            //        , _mao, isFirstMao, Program._Account.id);

            //    if (result.IsSuccess)
            //    {
            //        ShowMessage("**" + _mao.mao_name + "，删除成功", MessageType.Success);
            //    }
            //    else
            //    {
            //        ShowMessage("**" + _mao.mao_name + "，删除失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

            //        MaoFailedJob job = new MaoFailedJob
            //        {
            //            register_or_user_id = _register.id,
            //            mao_id = _mao.id,
            //            job_type = JobType.注册,
            //        };
            //        _maoFailedJobBLL.AddOrUpdate(job);
            //    }

            //    isFirstMao = false;
            //}

            //HM.FacePlatform.Model.Register[] registers = _registerBLL.GetList(_register.user_uid);
            //if (registers.Length < 1)
            //{
            //    UserBLL _userBLL = new UserBLL();
            //    User _user = _userBLL.Get(new { user_uid = _register.user_uid });

            //    if (_user != null)
            //    {
            //        _user.check_state = CheckType.待审核;
            //        _userBLL.UpdateUserOnly(_user);
            //    }
            //}

            //BindRegInfor(theSelectUserID);
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private void ShowMessage(string message, MessageType type)
        {
            tbMessage.UIThread(() =>
            {
                tbMessage.Text = message + Environment.NewLine + tbMessage.Text;
            }, true);
        }

        private void ClearMessage()
        {
            tbMessage.UIThread(() =>
            {
                tbMessage.Text = string.Empty;
            });
        }

        private void FaceJobFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_actionResult.Obj)
            {
                this.UIThread(() =>
                {
                    HMMessageBox.Show(this, "任务还在进行中，不允许中途退出！");
                });
                e.Cancel = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (_actionResult.IsSuccess)
            {

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
