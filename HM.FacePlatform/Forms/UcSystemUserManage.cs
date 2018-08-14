using System;
using System.Windows.Forms;
using HM.FacePlatform.Model;
using HM.FacePlatform.BLL;
using HM.Common_;
using HM.Enum_.FacePlatform;
using HM.DTO;
using HM.FacePlatform.Forms;
using System.Collections.Generic;
using HM.Utils_;
using HM.Form_;

namespace HM.FacePlatform
{
    public partial class UcSystemUserManage : UserControl
    {
        SystemUserBLL _systemUserBLL;
        DataCrypto dataCrypto;
        /// <summary>
        /// 启用
        /// </summary>
        private readonly string enableText = "启用";
        /// <summary>
        /// 禁用
        /// </summary>
        private readonly string disableText = "禁用";
        /// <summary>
        /// 重置
        /// </summary>
        private readonly string resetText = "重置";

        private readonly string defaultPassword = "123456";

        private readonly int disableIndex = 3;
        private readonly int resetIndex = 4;

        private readonly string idColumnName = "col_id";
        private readonly string disableColumnName = "col_disable";
        private readonly string resetPasswordColumnName = "col_reset_password";
        private readonly string isDelColumnName = "col_is_del";
        private readonly string isAdminColumnName = "col_is_admin";
        public UcSystemUserManage()
        {
            _systemUserBLL = new SystemUserBLL();
            dataCrypto = new DataCrypto();

            InitializeComponent();
        }

        private void SystemUserManage_Load(object sender, EventArgs e)
        {
            gvSystemUser.AutoGenerateColumns = false;
            PagerSystemManage.Bind();
        }
        public void BindData() {
            PagerSystemManage.Bind();
        }
        /// <summary>
        /// 分页绑定数据
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerSystemManage_EventPaging(Form_.EventPagingArg e)
        {
            int row = 0;
            int totalPage = 0;
            var where = Predicate_.True<SystemUser>();
            IList<SystemUser> lstSystemUser = _systemUserBLL.Get(PagerSystemManage.PageIndex, PagerSystemManage.PageSize, out row, out totalPage, where, true, it => it.user_name);

            //绑定分页控件
            PagerSystemManage.bsPager.DataSource = lstSystemUser;
            PagerSystemManage.bnPager.BindingSource = PagerSystemManage.bsPager;
            //返回总记录数
            return totalPage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvSystemUser_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            SystemUser systemUser = hmDGV.Rows[e.RowIndex].DataBoundItem as SystemUser;
            if (systemUser.is_admin != IsAdminType.是)
            {
                switch (systemUser.is_del)
                {
                    case IsDelType.否:
                        cells["colDo"].Value = disableText;
                        break;
                    case IsDelType.是:
                        cells["colDo"].Value = enableText;
                        break;
                    default:
                        break;
                }
                cells[resetPasswordColumnName].Value = resetText;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrUpdateSystemUser form = new AddOrUpdateSystemUser(this);
            form.Show();
        }

        private void gvSystemUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            SystemUser systemUser = hmDGV.Rows[e.RowIndex].DataBoundItem as SystemUser;

            if (e.ColumnIndex == disableIndex)
            {
                IsDelType isDelTypeResult;
                DialogResult dr;
                if (systemUser.is_del == IsDelType.是)
                {
                    dr = HMMessageBox.Show(this, "确定要启用吗?", "启用确认", MessageBoxButtons.OKCancel);
                    isDelTypeResult = IsDelType.否;
                }
                else
                {
                    dr = HMMessageBox.Show(this, "确定要禁用吗?", "禁用确认", MessageBoxButtons.OKCancel);
                    isDelTypeResult = IsDelType.是;
                }

                if (dr != DialogResult.OK) return;

                var dbSystemUser = _systemUserBLL.FirstOrDefault(it => it.id == systemUser.id);
                dbSystemUser.is_del = isDelTypeResult;
                bool result = _systemUserBLL.Edit(dbSystemUser);
                if (result)
                {
                    systemUser = dbSystemUser;
                    HMMessageBox.Show(this, "操作成功！");
                    PagerSystemManage.Bind();
                }
                else
                {
                    HMMessageBox.Show(this, "操作失败！");
                }
            }
            else if (e.ColumnIndex == resetIndex)
            {
                if (DialogResult.OK != HMMessageBox.Show(this, "确定要重置密码吗?", "重置确认", MessageBoxButtons.OKCancel)) return;

                var dbSystemUser = _systemUserBLL.FirstOrDefault(it => it.id == systemUser.id);
                dbSystemUser.password = dataCrypto.Encrypto(defaultPassword);
                bool result = _systemUserBLL.Edit(dbSystemUser);
                if (result)
                {
                    systemUser = dbSystemUser;
                    HMMessageBox.Show(this, "操作成功，密码重置为：" + defaultPassword);
                    PagerSystemManage.Bind();
                }
                else
                {
                    HMMessageBox.Show(this, "操作失败！");
                }
            }
        }
    }
}
