using HM.Common_;
using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Forms;
using HM.FacePlatform.Model;
using HM.FacePlatform.UserControls;
using HM.Form_;
using HM.Form_.Old;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    public partial class UcRegisterManage : UcBase
    {
        RegisterBLL _registerBLL = new RegisterBLL();
        readonly string enableText = "启用";
        readonly string disableText = "禁用";


        VankeBalloonToolTip _Tip;//提示
        //构造函数 
        public UcRegisterManage()
        {
            _Tip = new VankeBalloonToolTip(this);

            InitializeComponent();

            DgvRegister.AllowUserToAddRows = false;
            DgvRegister.AutoGenerateColumns = false;
            DgvRegister.RowHeadersVisible = false;

            //引许线程直接访问控件
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void RegisterManage_Load(object sender, EventArgs e)
        {
            DtpFrom.Value = DateTime.Now.Date.AddMonths(-1);
            DtpTo.Value = DateTime.Now.Date;
            BindHelper.EnumBind<UserType>(CbxUserType);
            BindHelper.EnumBind<RegisterType>(CbxRegisterType);
            BindHelper.EnumBind<CheckType>(CbxCheckType);

            PagerRegister.Bind();
        }

        private void HtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #region 人脸注册详细信息
        /// <summary>
        /// 人脸注册详细信息
        /// </summary>
        /// <param name="userID"></param>
        private void FlpRegisterRender(string userID)
        {
            (this).UIThread(() =>
            {
                FlpRegister.Controls.Clear();

                ActionResult<List<Register>> result = _registerBLL.GetWithUser(userID);
                if (result.IsSuccess)
                {
                    foreach (Register registerWithUser in result.Obj)
                    {
                        ImageDetailItem uc = new ImageDetailItem(registerWithUser);
                        FlpRegister.Controls.Add(uc);
                        uc.DeleteImageAction = DeleteRegistedImage;
                    }
                }
                else
                {
                    ucNoData uc = new ucNoData();
                    uc.Note = "暂无人脸注册数据";
                    FlpRegister.Controls.Add(uc);
                }
            });
        }

        private void DeleteRegistedImage(ImageDetailItem imageDetailItem)
        {
            if (HMMessageBox.Show(this, "此人脸已审核通过，确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            FaceJobFrm faceJobFrm = new FaceJobFrm();
            ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck(true);
            if (checkResult.IsSuccess)
            {
                faceJobFrm.DeleteRegistedImage(checkResult.Obj, imageDetailItem._registerWithUser.user, imageDetailItem._registerWithUser, () =>
                {
                    if (FlpRegister.Controls.Count > 1)
                    {
                        FlpRegisterRender(imageDetailItem._registerWithUser.user.user_uid);
                    }
                    else
                    {
                        BtnSelectRegister_Click(BtnSelectRegister, null);
                    }
                });
            }
        }
        #endregion


        private void BtnSelectRegister_Click(object sender, EventArgs e)
        {
            FlpRegister.Controls.Clear();
            PagerRegister.Bind();
        }

        /// <summary>
        /// 分页绑定事件
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerRegister_EventPaging(Form_.EventPagingArg e)
        {
            DateTime from = DtpFrom.Value.Date;
            DateTime to = DtpTo.Value.Date;
            string user_name = Validate_.StringFilter(TxtUserName.Text);
            UserType? user_type = BindHelper.EnumValue<UserType>(CbxUserType);
            RegisterType? register_type = BindHelper.EnumValue<RegisterType>(CbxRegisterType);
            CheckType? check_type = BindHelper.EnumValue<CheckType>(CbxCheckType);

            ActionResult<PagerData<RegisterManageDto>> result = _registerBLL.GetForRegisterManage(PagerRegister.PageIndex, PagerRegister.PageSize, from, to, user_name, user_type, register_type, check_type);

            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<RegisterManageDto>()
                {
                    pages = 0,
                    rows = new List<RegisterManageDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerRegister.bsPager.DataSource = result.Obj.rows;
            PagerRegister.bnPager.BindingSource = PagerRegister.bsPager;
            //分页控件绑定DataGridView
            DgvRegister.DataSource = PagerRegister.bsPager;
            //返回总记录数
            return result.Obj.total;
        }

        #region DgvRegister事件
        private void DgvRegister_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            RegisterManageDto dto = hmDGV.Rows[e.RowIndex].DataBoundItem as RegisterManageDto;

            switch (dto.check_state)
            {
                case CheckType.审核不通过:
                    cells["colDo"].Value = enableText;
                    break;
                case CheckType.审核通过:
                    cells["colDo"].Value = disableText;
                    break;
                case CheckType.待审核:
                    cells["colDo"].Value = enableText;
                    break;
                default:
                    break;
            }

            if (dto.end_time != null)
            {
                if (DateTime.Now >= dto.end_time)
                {
                    cells["colEndTime"].Style.BackColor = Color.Red;
                }
                else if (DateTime.Now >= dto.end_time.AddDays(-7))
                {
                    cells["colEndTime"].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void DgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            if (hmDGV.Columns[e.ColumnIndex].Name == "colDo")
            {
                var cells = hmDGV.Rows[e.RowIndex].Cells;
                RegisterManageDto dto = hmDGV.Rows[e.RowIndex].DataBoundItem as RegisterManageDto;
                DialogResult dr;
                CheckType targteCheckType;
                if (dto.check_state == CheckType.审核通过)
                {
                    dr = HMMessageBox.Show(this, "确定要禁用吗?", "禁用确认", MessageBoxButtons.OKCancel);
                    targteCheckType = CheckType.审核不通过;
                }
                else
                {
                    dr = HMMessageBox.Show(this, "确定要启用吗?", "启用确认", MessageBoxButtons.OKCancel);
                    targteCheckType = CheckType.审核通过;
                }
                if (dr == DialogResult.OK)
                {
                    FaceJobFrm faceJobFrm = new FaceJobFrm();
                    ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck();
                    if (checkResult.IsSuccess)
                    {
                        var getResult = _registerBLL.GetWithUser(dto.user_uid);
                        if (getResult.IsSuccess)
                        {
                            faceJobFrm.Review(getResult.Obj,
                            targteCheckType,
                            "",
                            (actionResult) =>
                            {
                                if (actionResult.IsSuccess)
                                {
                                    PagerRegister.Bind();
                                }
                            });
                            faceJobFrm.ShowDialog();
                        }
                        else
                        {
                            HMMessageBox.Show(this, getResult.ToAlertString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvRegister_SelectionChanged(object sender, EventArgs e)
        {
            HMDataGridView hmDGV = (HMDataGridView)sender;
            if (hmDGV != null && hmDGV.Rows.Count > 0 && hmDGV.SelectedRows.Count > 0)
            {
                RegisterManageDto dto = hmDGV.SelectedRows[0].DataBoundItem as RegisterManageDto;
                Task.Run(() =>
                {
                    FlpRegisterRender(dto.user_uid);
                });
            }
        }
        /// <summary>
        /// 解决 Formatted值的类型 报错的问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvRegister_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvRegister.Columns[e.ColumnIndex].Name == "colCB")
            {
                if (e.Value == null)
                    e.Value = false;
            }
        }
        #endregion

        #region 延迟
        /// <summary>
        /// 获取勾选行的数据
        /// </summary>
        /// <returns></returns>
        List<RegisterManageDto> GetCheckedRowData()
        {
            DgvRegister.EndEdit();
            var data = new List<RegisterManageDto>();
            foreach (DataGridViewRow row in DgvRegister.Rows)
            {
                if (row.Cells["colCB"].EditedFormattedValue.ToBool_() ?? false)
                {
                    data.Add(row.DataBoundItem as RegisterManageDto);
                }
            }
            return data;
        }
        /// <summary>
        /// 延迟一个月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextM_Click(object sender, EventArgs e)
        {
            List<RegisterManageDto> data = GetCheckedRowData();
            if (!data.Any())
            {
                _Tip.ShowIt(btnNextM, "请勾选人脸数据!");
            }
            else
            {
                DialogResult result = HMMessageBox.Show(this, $"共{data.Count}人的人脸有效期需延期一个月，请确认！", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    FaceJobFrm faceJobFrm = new FaceJobFrm();
                    faceJobFrm.SetEndTime(data, false);
                    result = faceJobFrm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        PagerRegister.Bind(); //重新绑定
                    }
                }
            }
        }
        /// <summary>
        /// 延迟一年
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextY_Click(object sender, EventArgs e)
        {
            List<RegisterManageDto> data = GetCheckedRowData();
            if (!data.Any())
            {
                _Tip.ShowIt(btnNextM, "请勾选人脸数据!");
            }
            else
            {
                DialogResult result = HMMessageBox.Show(this, $"共{data.Count}人的人脸有效期需延期一个年，请确认！", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    FaceJobFrm faceJobFrm = new FaceJobFrm();
                    ActionResult<MaoCheckResult> checkResult = faceJobFrm.BasicCheck();
                    if (checkResult.IsSuccess)
                    {
                        faceJobFrm.SetEndTime(data, true);
                        result = faceJobFrm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            PagerRegister.Bind(); //重新绑定
                        }
                    }
                }
            }
        }

        #endregion


        private void cbEmployeeAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DgvRegister.Rows.Count; i++)
            {
                DgvRegister.Rows[i].Cells["colCB"].Value = CbxAll.Checked;
            }
        }
    }
}
