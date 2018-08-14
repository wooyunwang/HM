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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    public partial class UcRegisterManage : HMUserControl
    {

        MaoFailedJobBLL _maoFailedJobBLL = new MaoFailedJobBLL();
        RegisterBLL _registerBLL = new RegisterBLL();
        MaoBLL _maoBLL = new MaoBLL();
        UserBLL _userBLL = new UserBLL();
        private string selectedPeopleId = string.Empty;
        private readonly string enableText = "启用";
        private readonly string disableText = "禁用";

        Form_Loading frmLoading = new Form_Loading();
        VankeBalloonToolTip m_Tip;//提示

        public string theSelectHouseCode = string.Empty;
        public string theSelectHouseName = string.Empty;

        private string theSelectUserID = string.Empty;


        private string regTypeMag;

        //构造函数 
        public UcRegisterManage()
        {
            m_Tip = new VankeBalloonToolTip(this);

            InitializeComponent();

            DgRegister.AllowUserToAddRows = false;
            DgRegister.AutoGenerateColumns = false;
            DgRegister.RowHeadersVisible = false;

            //引许线程直接访问控件
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void RegisterManage_Load(object sender, EventArgs e)
        {
            DtpFrom.Value = DateTime.Now.AddMonths(-1);
            DtpTo.Value = DateTime.Now;
            BindHelper.EnumBind<UserType>(CbxUserType);
            BindHelper.EnumBind<RegisterType>(CbxRegisterType);
            BindHelper.EnumBind<CheckType>(CbxCheckType);

            Task.Run(() =>
            {
                PagerRegister.Bind();
            });
        }

        #region 人脸注册详细信息
        /// <summary>
        /// 人脸注册详细信息
        /// </summary>
        /// <param name="userID"></param>
        private void FlpRegisterRender(string userID)
        {
            FlpRegister.Controls.Clear();

            ActionResult<List<Register>> result = _registerBLL.GetWithUser(userID);
            if (result.IsSuccess)
            {
                foreach (Register registerWithUser in result.Obj)
                {
                    ImageDetailItem uc = new ImageDetailItem(registerWithUser);
                    FlpRegister.Controls.Add(uc);
                    uc.DeleteImageAction += new Action<ImageDetailItem>(DeleteRegistedImage);
                }
            }
            else
            {
                ucNoData u = new ucNoData();
                u.Note = "暂无人脸注册数据";
                FlpRegister.Controls.Add(u);
            }
        }

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

        #endregion

        private void HtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
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
            string user_name = Validate_.StringFilter(TxtUserName.Text);
            UserType? user_type = BindHelper.EnumValue<UserType>(CbxUserType);
            DateTime from = DtpFrom.Value;
            DateTime to = DtpTo.Value;
            RegisterType? register_type = BindHelper.EnumValue<RegisterType>(CbxRegisterType);
            CheckType? check_type = BindHelper.EnumValue<CheckType>(CbxCheckType);

            ActionResult<PagerData<Register>> result = _registerBLL.GetWithUser(PagerRegister.PageIndex, PagerRegister.PageSize, from, to, user_name, user_type, register_type, check_type);

            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<Register>()
                {
                    pages = 0,
                    rows = new List<Register>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerRegister.bsPager.DataSource = result.Obj.rows;
            PagerRegister.bnPager.BindingSource = PagerRegister.bsPager;
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private void ScrollGridViewOneRow_For(int i)
        {
            if (DgRegister.Rows.Count > 0)
            {
                DgRegister.ClearSelection();
                DgRegister.CurrentCell = DgRegister.Rows[i].Cells[0];//并且滚动条也会自动的滚动，显示选中的行省去了           
                //DgRegister.Rows[0].Selected = false;
                DgRegister.Rows[i].Selected = true;
                DgRegister.FirstDisplayedScrollingRowIndex = i;

                theSelectUserID = DgRegister.Rows[i].Cells["col_user_uid"].Value.ToString();

                selectedPeopleId = DgRegister.Rows[i].Cells["col_people_id"].Value.ToString();

                FlpRegisterRender(theSelectUserID);
            }
        }
        #region DgRegister事件
        /// <summary>
        /// 滚动到GridView的某一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgRegister_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ScrollGridViewOneRow_For(0);

            foreach (DataGridViewRow col in DgRegister.Rows)
            {
                string endtimestr = col.Cells["col_end_time"].Value.ToString();
                DateTime endtime;
                DateTime.TryParse(endtimestr, out endtime);
                if (endtime != null)
                {
                    if (DateTime.Now >= endtime)
                    {
                        //col.DefaultCellStyle.BackColor = Color.Red;
                        col.Cells["col_end_time"].Style.BackColor = Color.Red;
                    }
                    else if (DateTime.Now >= endtime.AddDays(-7))
                    {
                        //col.DefaultCellStyle.BackColor = Color.Yellow;
                        col.Cells["col_end_time"].Style.BackColor = Color.Yellow;
                    }
                }
            }
        }
        private void DgRegister_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            Register registerWithUser = hmDGV.Rows[e.RowIndex].DataBoundItem as Register;

            switch (registerWithUser.check_state)
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
        }

        private void DgRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 9)
            {
                HMDataGridView hmDGV = (HMDataGridView)sender;
                var cells = hmDGV.Rows[e.RowIndex].Cells;
                Register registerWithUser = hmDGV.Rows[e.RowIndex].DataBoundItem as Register;
                DialogResult dr;
                if (registerWithUser.check_state == CheckType.审核通过)
                {
                    dr = HMMessageBox.Show(this, "确定要禁用吗?", "禁用确认", MessageBoxButtons.OKCancel);
                }
                else
                {
                    dr = HMMessageBox.Show(this, "确定要启用吗?", "启用确认", MessageBoxButtons.OKCancel);
                }
                if (dr != DialogResult.OK) return;

                string _user_uid = DgRegister.Rows[e.RowIndex].Cells["col_user_uid"].Value.ToString();
                string people_id = DgRegister.Rows[e.RowIndex].Cells["col_people_id"].Value.ToString();
                string project_code = Program._Mainform._ProjectCode;

                //ClearMessage();
                //ShowMessage($"##开始修改：{ registerWithUser.user.name }", MessageType.Information);

                //bool isFirstMao = true;
                //int check_by = Program._Account.id;
                //User _user = _userBLL.Get(new { user_uid = _user_uid });
                //_user.change_time = DateTime.Now;
                //foreach (Mao _mao in _maos)
                //{
                //    ActionResult result = _registerBLL.Check(_user, check_state, "", check_by, project_code, _mao, isFirstMao);

                //    if (result.IsSuccess)
                //    {
                //        ShowMessage("**" + _mao.mao_name + "，修改成功", MessageType.Success);
                //    }
                //    else
                //    {
                //        ShowMessage("**" + _mao.mao_name + "，修改失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

                //        MaoFailedJob job = new MaoFailedJob
                //        {
                //            register_or_user_id = _user.id,
                //            mao_id = _mao.id,
                //            job_type = JobType.审核,
                //        };
                //        _maoFailedJobBLL.AddOrUpdate(job);
                //    }

                //    isFirstMao = false;
                //}

                //this.PagerRegister.InnerBind();

                //#region 定位到原来的行
                //for (int i = 0; i < DgRegister.Rows.Count; i++)
                //{
                //    if (DgRegister.Rows[i].Cells["col_user_uid"].Value.ToString() == theSelectUserID)
                //    {
                //        DgRegister.CurrentCell = DgRegister.Rows[i].Cells[0];

                //    }
                //}
                //#endregion
            }
        }

        private void DgRegister_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || DgRegister.SelectedRows.Count <= 0)
            {
                return;
            }

            theSelectUserID = dgv.SelectedRows[0].Cells["col_user_uid"].Value.ToString();
            FlpRegisterRender(theSelectUserID);
        }
        /// <summary>
        /// 解决 Formatted值的类型 报错的问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgRegister_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgRegister.Columns[e.ColumnIndex].Name == "colCB")
            {
                if (e.Value == null)
                    e.Value = false;
            }
        }
        #endregion

        #region 延迟
        /// <summary>
        /// 延迟一个月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextM_Click(object sender, EventArgs e)
        {
            bool isSel = false;
            foreach (DataGridViewRow dr in DgRegister.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["colCB"].EditedFormattedValue.ToString()))
                {
                    isSel = true;
                    break;
                }
            }
            if (!isSel)
            {
                m_Tip.ShowIt(btnNextM, "请选择人脸数据!");
                return;
            }

            DialogResult result = HMMessageBox.Show(this, "有效期是否延期一个月?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Task.Run(() =>
                {
                    SetEndTime(false);
                });
            }
        }
        /// <summary>
        /// 延迟一年
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextY_Click(object sender, EventArgs e)
        {
            bool isSel = false;
            foreach (DataGridViewRow dr in DgRegister.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["colCB"].EditedFormattedValue.ToString()))
                {
                    isSel = true;
                    break;
                }
            }
            if (!isSel)
            {
                m_Tip.ShowIt(btnNextY, "请选择人脸数据!");
                return;
            }

            DialogResult result = HMMessageBox.Show(this, "有效期是否延期一年?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Task.Run(() =>
                {
                    SetEndTime(true);
                });
            }
        }
        /// <summary>
        /// 设置延迟时间
        /// </summary>
        /// <param name="isYear"></param>
        private void SetEndTime(bool isYear)
        {
            ClearMessage();

            DateTime endTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            if (isYear)
            {
                endTime = endTime.AddYears(1);
            }
            else
            {
                endTime = endTime.AddMonths(1);
            }

            ActionResult result = new ActionResult();
            foreach (DataGridViewRow dr in DgRegister.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["colCB"].EditedFormattedValue.ToString()))
                {
                    //ShowMessage("##开始修改：" + dr.Cells["col_name"].EditedFormattedValue.ToString(), MessageType.Information);

                    //bool isFirstMao = true;
                    //string _user_uid = dr.Cells["col_user_uid"].EditedFormattedValue.ToString();
                    //User _user = _userBLL.Get(new { user_uid = _user_uid });
                    //_user.change_time = DateTime.Now;
                    //foreach (Mao _mao in _maos)
                    //{
                    //    result = _registerBLL.UpdateExpireDate(_user, _mao, endTime, isFirstMao, Program._Account.id);

                    //    if (result.IsSuccess)
                    //    {
                    //        ShowMessage("**" + _mao.mao_name + "，修改成功", MessageType.Success);
                    //    }
                    //    else
                    //    {
                    //        ShowMessage("**" + _mao.mao_name + "，修改失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

                    //        MaoFailedJob job = new MaoFailedJob
                    //        {
                    //            register_or_user_id = _user.id,
                    //            mao_id = _mao.id,
                    //            job_type = JobType.审核,
                    //        };
                    //        _maoFailedJobBLL.AddOrUpdate(job);
                    //    }
                    //    isFirstMao = false;
                    //}
                }
            }
        }
        #endregion

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

        private void cbEmployeeAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DgRegister.Rows.Count; i++)
            {
                DgRegister.Rows[i].Cells["colCB"].Value = CbxAll.Checked;
            }
        }


    }
}
