using HM.Common_;
using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.FacePlatform.UserControls;
using HM.Form_;
using HM.Form_.Old;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace HM.FacePlatform.Forms
{
    public partial class CheckNote : HMForm
    {
        /// <summary>
        /// 
        /// </summary>
        RegisterBLL _registerBLL;
        /// <summary>
        /// 
        /// </summary>
        MaoBLL _maoBLL;
        /// <summary>
        /// 
        /// </summary>
        MaoFailedJobBLL _maoFailedJobBLL;
        /// <summary>
        /// 提示
        /// </summary>
        VankeBalloonToolTip _Tip;
        /// <summary>
        /// 
        /// </summary>
        List<Register> _lstRegisterWithUser = new List<Register>();
        /// <summary>
        /// 
        /// </summary>
        UcCheck _usCheck = null;
        /// <summary>
        /// 注册人【注：批量审核时，需要保持为Null】
        /// </summary>
        string _userUid = null;
        /// <summary>
        /// 是否为浏览
        /// </summary>
        bool _isRead = true;
        /// <summary>
        /// 是否批量审核
        /// </summary>
        bool _isBatch { get { return _userUid != null; } }
        /// <summary>
        /// 用于单人审核
        /// </summary>
        /// <param name="ucCheck"></param>
        /// <param name="userUid"></param>
        /// <param name="isRead"></param>
        public CheckNote(UcCheck ucCheck, string userUid, bool isRead = false)
        {
            _Tip = new VankeBalloonToolTip(this);
            InitializeComponent();
            _registerBLL = new RegisterBLL();
            _maoBLL = new MaoBLL();
            _maoFailedJobBLL = new MaoFailedJobBLL();

            _usCheck = ucCheck;
            _userUid = userUid;
            _isRead = isRead;
            ActionResult<List<Register>> ar = _registerBLL.GetWithUser(userUid);
            if (ar.IsSuccess)
            {
                _lstRegisterWithUser = ar.Obj;
            }
            else
            {
                HMMessageBox.Show(this, ar.ToAlertString());
                //退出窗口
                DialogResult = DialogResult.Cancel;
            }
        }
        /// <summary>
        /// 用于批量审核
        /// </summary>
        /// <param name="ucCheck"></param>
        /// <param name="lstRegisterWithUser"></param>
        /// <param name="isRead"></param>
        public CheckNote(UcCheck ucCheck, List<Register> lstRegisterWithUser, bool isRead = false)
        {
            _Tip = new VankeBalloonToolTip(this);
            InitializeComponent();
            _registerBLL = new RegisterBLL();
            _maoBLL = new MaoBLL();
            _maoFailedJobBLL = new MaoFailedJobBLL();

            _usCheck = ucCheck;
            _lstRegisterWithUser = lstRegisterWithUser;
            _isRead = isRead;

        }

        private void CheckNote_Load(object sender, EventArgs e)
        {
            //允许线程直接访问控件
            CheckForIllegalCrossThreadCalls = false;

            if (_isBatch)
            {
                this.Text = "批量审核(只显示其中一条业主信息)";
            }
            else
            {
                this.Text = "单项审核";
            }

            Register registerWithUser = _lstRegisterWithUser[0];
            tbHouseName.Text = registerWithUser.user.user_houses.ToList()[0].House.house_name;//wait 不是这么玩的
            tbName.Text = registerWithUser.user.name;
            tbUserType.Text = Utils_.EnumHelper.GetName(registerWithUser.user.user_houses.ToList()[0].user_type);//wait 不是这么玩的
            tbRelation.Text = "";//registerWithUser.relation;//wait 不是这么玩的
            tbRegTime.Text = registerWithUser.user.end_time.ToString();
            txtNote.Text = registerWithUser.user.check_note;
            tbCheckPepole.Text = ""; //registerWithUser.check_by_name;//wait 不是这么玩的
            tbCheckTime.Text = registerWithUser.user.check_time.ToString();

            FlpRegistedRender();

            if (!_isRead)
            {
                btnOK.Visible = false;
                btnNO.Visible = false;
                this.Text = "查看审核";
                txtNote.ReadOnly = true;
                labPeople.Visible = true;
                labCheckTime.Visible = true;
                tbCheckPepole.Visible = true;
                tbCheckTime.Visible = true;
            }
            else
            {

            }
        }
        /// <summary>
        /// 呈现至FlowLayoutPanel容器
        /// </summary>
        private void FlpRegistedRender()
        {
            FlpRegisted.Controls.Clear();
            ActionResult<List<Register>> result = _registerBLL.GetWithUser(_lstRegisterWithUser[0].user_uid);
            if (result.IsSuccess)
            {
                FlpRegisted.SuspendLayout();
                foreach (Register registerWithUser in result.Obj)
                {
                    ImageItem imageItem = new ImageItem(registerWithUser);

                    if (!_isRead || _lstRegisterWithUser.Count > 1) imageItem.isShowDelete = false;
                    FlpRegisted.Controls.Add(imageItem);
                    if (imageItem.isShowDelete)
                    {
                        imageItem.DeleteImageAction += new Action<ImageItem>(DeleteRegistedImage);
                    }
                }
                FlpRegisted.ResumeLayout();
                FlpRegisted.PerformLayout();
            }
            else
            {
                HMMessageBox.Show(this, result.ToAlertString());
            }
        }

        private void DeleteRegistedImage(ImageItem imageItem)
        {
            if (HMMessageBox.Show(this, "此人脸已审核通过，确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            ClearMessage();

            var result = _maoBLL.CheckMao();
            if (result.IsSuccess)
            {
                DateTime change_time = DateTime.Now;
                imageItem._register.change_time = change_time;
                var goodMaos = result.Obj.Where(it => it.Value.Item1 == true).Select(it => it.Value);
                Parallel.ForEach(goodMaos,
                   new ParallelOptions { MaxDegreeOfParallelism = Utils_.Config_.GetInt("MaxDegreeOfParallelism") ?? 2 },
                   tplMao =>
                   {
                       Mao mao = tplMao.Item2;
                       Face.Common_.Face face = tplMao.Item3;

                       var itemResult = face.FaceDel(imageItem._register.user.people_id, new List<string>() { imageItem._register.photo_path });

                       if (itemResult.IsSuccess)
                       {
                           ShowMessage("**" + mao.mao_name + "，删除成功", MessageType.Success);
                       }

                       else
                       {
                           ShowMessage("**" + mao.mao_name + "，删除失败(稍后将自动重试)：" + itemResult.ToAlertString(), MessageType.Error);

                           MaoFailedJob job = new MaoFailedJob
                           {
                               register_or_user_id = imageItem._register.id,
                               mao_id = mao.id,
                               job_type = JobType.删除,
                           };
                           _maoFailedJobBLL.AddOrUpdate(it => new
                           {
                               it.register_or_user_id,
                               it.mao_id,
                               it.job_type
                           }, job);
                       }
                   });
            }
            else
            {
                var badMaos = result.Obj.Where(it => it.Value.Item1 == false)
                    .Select(it => it.Value).Select(it => it.Item2);
                foreach (var mao in badMaos)
                {
                    ShowMessage($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！", MessageType.Error);
                }
                ShowMessage("这将导致删除失败！", MessageType.Error);
            }

            FlpRegistedRender();

            ActionResult<List<Register>> lstRegisterWithUser = _registerBLL.GetWithUser(imageItem._register.user_uid);
            if (lstRegisterWithUser.IsSuccess)
            {
                if (!lstRegisterWithUser.Any())
                {
                    UserBLL _userBLL = new UserBLL();
                    User _user = _userBLL.FirstOrDefault(it => it.user_uid == imageItem._register.user_uid);
                    if (_user != null)
                    {
                        _user.check_state = CheckType.待审核;
                        _userBLL.Edit(_user);
                    }
                }
            }
        }
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Check(CheckType.审核通过);
        }
        /// <summary>
        /// 审核不通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNO_Click(object sender, EventArgs e)
        {
            bool result = Check(CheckType.审核不通过);
            if (result)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="checkType"></param>
        private bool Check(CheckType checkType)
        {
            ClearMessage();

            if (tbEnd.Visible)
            {
                if (Convert.ToDateTime(tbEnd.Value.ToString("yyyy-MM-dd 23:59:59")) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59")))
                {
                    _Tip.ShowItTop(tbEnd, "有效期时间不能小于当前时间");
                    return false;
                }
            }

            var result = _maoBLL.CheckMao();
            if (result.IsSuccess)
            {
                var goodMaos = result.Obj.Where(it => it.Value.Item1 == false).Select(it => it.Value);
                result.Add(Check(goodMaos, checkType));
                return result.IsSuccess;
            }
            else
            {
                var badMaos = result.Obj.Where(it => it.Value.Item1 == false)
                    .Select(it => it.Value).Select(it => it.Item2);
                foreach (var mao in badMaos)
                {
                    ShowMessage($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！", MessageType.Error);
                }
                ShowMessage("这将导致审核失败！", MessageType.Error);
                return false;
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="goodMaos"></param>
        /// <param name="checkType"></param>
        /// <returns></returns>
        private ActionResult Check(IEnumerable<Tuple<bool, Mao, Face.Common_.Face>> goodMaos, CheckType checkType)
        {
            ActionResult actionResult = new ActionResult();
            string project_code = Program._Mainform._ProjectCode;

            foreach (Register registerWithUser in _lstRegisterWithUser)
            {
                string check_note = txtNote.Text.Trim();

                ShowMessage("##开始修改：" + registerWithUser.user.name, MessageType.Information);

                int check_by = Program._Account.id;
                DateTime change_time = DateTime.Now;

                List<ActionResult> lstActionResult = new List<ActionResult>();
                List<MaoFailedJob> lstMaoFailedJob = new List<MaoFailedJob>();
                Parallel.ForEach(goodMaos,
                    new ParallelOptions { MaxDegreeOfParallelism = Utils_.Config_.GetInt("MaxDegreeOfParallelism") ?? 2 },
                    tplMao =>
                    {
                        Mao mao = tplMao.Item2;
                        Face.Common_.Face face = tplMao.Item3;

                        var result = face.Review(project_code, registerWithUser.user.people_id, registerWithUser.face_id, checkType, "客户端审核");
                        lstActionResult.Add(result);
                        if (result.IsSuccess)
                        {
                            ShowMessage($"【{ mao.mao_name }】【{registerWithUser.user.name}】的审核结果：【{ checkType }】", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage($"【{ mao.mao_name }】【{registerWithUser.user.name}】的审核失败：【{ result.ToAlertString() }】", MessageType.Error);

                            lstMaoFailedJob.Add(new MaoFailedJob
                            {
                                register_or_user_id = registerWithUser.id,
                                mao_id = mao.id,
                                job_type = checkType == CheckType.审核不通过 ? JobType.审核不通过 : JobType.审核
                            });
                        }
                    });

                if (lstActionResult.Any(it => it.IsSuccess)) //只要有一个审核成功
                {
                    registerWithUser.check_state = checkType;
                    registerWithUser.change_time = change_time;
                    _registerBLL.Edit(registerWithUser);
                    if (lstMaoFailedJob.Any())
                    {
                        _maoFailedJobBLL.AddOrUpdate(it => new
                        {
                            it.register_or_user_id,
                            it.mao_id,
                            it.job_type
                        }, lstMaoFailedJob.ToArray());
                    }
                }
                if (lstActionResult.Any(it => !it.IsSuccess)) //只要有一个审核失败，则不通过
                {
                    actionResult.IsSuccess = false;
                }
            }

            return actionResult;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 清空消息
        /// </summary>
        private void ClearMessage()
        {
            tbMessage.UIThread(() =>
            {
                tbMessage.Text = string.Empty;
            });
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
                tbMessage.AppendText(message + Environment.NewLine, MessageColor.GetColorByMessgaeType(type));
            });
        }
    }
}
