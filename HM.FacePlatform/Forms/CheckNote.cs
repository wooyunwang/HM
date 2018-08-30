using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.FacePlatform.UserControls;
using HM.Form_;
using HM.Form_.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
        /// 
        /// </summary>
        HouseBLL _houseBLL;
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
            _houseBLL = new HouseBLL();

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

            Init();
        }

        private void Init()
        {
            if (_lstRegisterWithUser.Any())
            {
                Register registerWithUser = _lstRegisterWithUser[0];
                CheckNoteDto checkNoteDto = new UserHouseBLL().GetForCheckNote(registerWithUser.user_uid);
                if (checkNoteDto != null)
                {
                    tbHouseName.Text = checkNoteDto.house_name;
                    tbUserType.Text = Utils_.EnumHelper.GetName(checkNoteDto.user_type);
                    tbRelation.Text = checkNoteDto.relation;
                    tbName.Text = checkNoteDto.user_name;
                    tbRegTime.Text = checkNoteDto.reg_time.ToString("yyyy-MM-dd HH:mm:ss");
                    txtNote.Text = checkNoteDto.check_note;
                    tbCheckPepole.Text = checkNoteDto.check_by_name;
                    tbCheckTime.Text = checkNoteDto.check_time.ToString("yyyy-MM-dd HH:mm:ss");
                }

                FlpRegistedRender();

                if (_isRead)
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
            }
            else
            {
                throw new Exception("进入审核界面，需要传入待审核的人脸信息");
            }
        }

        /// <summary>
        /// 呈现至FlowLayoutPanel容器
        /// </summary>
        private void FlpRegistedRender()
        {
            ActionResult<List<Register>> result = _registerBLL.GetWithUser(_lstRegisterWithUser[0].user_uid);
            this.UIThread(() =>
            {
                FlpRegisted.Controls.Clear();
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
                            imageItem.DeleteImageAction = new Action<ImageItem>(DeleteRegistedImage);
                        }
                    }
                    FlpRegisted.ResumeLayout();
                    FlpRegisted.PerformLayout();
                }
                else
                {
                    HMMessageBox.Show(this, result.ToAlertString());
                }
            });
        }

        private void DeleteRegistedImage(ImageItem imageItem)
        {
            if (HMMessageBox.Show(this, "此人脸已审核通过，确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck(true);
            if (checkResult.IsSuccess)
            {
                faceJobFrm.DeleteRegistedImage(checkResult.Obj, imageItem._register.user, imageItem, () =>
                {
                    FlpRegistedRender();
                });
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
            Check(CheckType.审核不通过);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="checkType"></param>
        private void Check(CheckType checkType)
        {
            if (tbEnd.Visible)
            {
                if (Convert.ToDateTime(tbEnd.Value.ToString("yyyy-MM-dd 23:59:59")) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59")))
                {
                    _Tip.ShowItTop(tbEnd, "有效期时间不能小于当前时间");
                    return;
                }
            }
            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck();
            if (checkResult.IsSuccess)
            {
                faceJobFrm.Review(_lstRegisterWithUser, checkType,
                    txtNote.Text.Trim(),
                    (actionResult) =>
                    {
                        if (actionResult.IsSuccess)
                        {
                            Init();
                        }
                    });
                this.DialogResult = faceJobFrm.ShowDialog();
                if (this.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
