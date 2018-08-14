using HM.Common_;
using HM.FacePlatform.BasicData;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
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
    public partial class UcDataBase : HMUserControl
    {
        public delegate void ThreadDelegate();

        private VankeBalloonToolTip m_Tip;//提示

        private string theSelectBuilding_code = string.Empty;

        private readonly int indexDeleteColumn = 0;
        private readonly int indexEditColumn = 1;
        private readonly int indexInitColumn = 2;
        private readonly int indexAbandonColumn = 3;
        private readonly int indexBuildingCheckColumn = 0;
        MaoBuildingBLL _maoBuildingBLL;
        BuildingBLL _buildingBLL;
        HouseBLL _houseBLL;
        MaoBLL _maoBLL;

        public UcDataBase()
        {
            InitializeComponent();

            _maoBuildingBLL = new MaoBuildingBLL();
            _buildingBLL = new BuildingBLL();
            _houseBLL = new HouseBLL();
            _maoBLL = new MaoBLL();

            dgvPerson.AllowUserToAddRows = false;
            dgvPerson.AutoGenerateColumns = false;
            dgvPerson.RowHeadersVisible = false;
            m_Tip = new VankeBalloonToolTip(this);

            dgvHouse.AutoGenerateColumns = false;
            dgBuilding.AutoGenerateColumns = false;
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            LoadBuilding();

            ListMao();

            tbLastPullDate.Text = DateTime.MinValue.ToString();
        }

        public void LoadBuilding()
        {
            tvBuilding.Nodes.Clear();
            var root = new TreeNode();
            root.Text = Program._Mainform._ProjectName;
            root.Tag = Program._Mainform._ProjectCode;
            var _buildings = _buildingBLL.Get(it => it.project_code == Program._Mainform._ProjectCode, true, it => it.building_name);
            if (_buildings != null && _buildings.Any())
            {
                foreach (var building in _buildings)
                {
                    var node = new TreeNode
                    {
                        Text = building.building_name,
                        Tag = building.building_code
                    };
                    root.Nodes.Add(node);
                }
            }

            tvBuilding.Nodes.Add(root);
            tvBuilding.ExpandAll();
            //让第一行被选中
            if (tvBuilding.Nodes.Count > 0)
            {
                if (tvBuilding.Nodes[0].Nodes.Count > 0)
                {
                    SelectNodeStly(tvBuilding.Nodes[0].Nodes[0]);
                }
            }
        }

        /// <summary>
        /// 让某一行被选中
        /// </summary>
        private void SelectNodeStly(TreeNode nodeVar)
        {
            //取消选中
            tvBuilding.Nodes[0].ForeColor = Color.Black;
            tvBuilding.Nodes[0].BackColor = Color.White;
            foreach (TreeNode node in tvBuilding.Nodes[0].Nodes)
            {
                node.ForeColor = Color.Black;
                node.BackColor = Color.White;
            }

            tvBuilding.SelectedNode = nodeVar;
            nodeVar.Checked = true;
            nodeVar.ForeColor = Color.White;
            nodeVar.BackColor = Color.FromArgb(67, 152, 237);
        }

        public void LoadHouse()
        {
            if (tvBuilding.SelectedNode != null)
            {
                dgvHouse.DataSource = null;
                var _houses = _houseBLL.Get(it => it.building_code == theSelectBuilding_code, true, it => it.house_name);
                if (_houses.Count > 0)
                {
                    for (int i = 0; i < _houses.Count; i++)
                    {
                        _houses[i].id = i + 1;
                    }
                    dgvHouse.DataSource = _houses;
                }
            }
        }

        private void tvBuilding_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvBuilding.SelectedNode != null)
            {
                SelectNodeStly(tvBuilding.SelectedNode);

                if (tvBuilding.SelectedNode.Parent == null)
                {
                    theSelectBuilding_code = string.Empty;//选中的是项目
                }
                else
                {
                    theSelectBuilding_code = tvBuilding.SelectedNode.Tag.ToString();//选中的是楼栋
                    LoadHouse();
                }
            }
        }

        public void LoadPerson(string house_code)
        {
            dgvPerson.DataSource = null;
            List<User> _users = _houseBLL.GetUserByHouseCode(house_code);
            if (_users != null && _users.Any())
            {
                for (int i = 0; i < _users.Count; i++)
                {
                    _users[i].id = i + 1;
                }
                dgvPerson.DataSource = _users;
            }
        }


        private void dgvHouse_SelectionChanged(object sender, EventArgs e)
        {
            BindUserData();
        }

        public void BindUserData()
        {

            if (dgvHouse.SelectedRows.Count <= 0)
            {
                return;
            }
            var code = dgvHouse.SelectedRows[0].Cells["ColCode"].Value as string;
            LoadPerson(code);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadHouse();
        }

        private void tbxQuery_TextChanged(object sender, EventArgs e)
        {
            tbxQuery.Text = Validate_.GetSafeString(ControlType.姓名类, tbxQuery.Text);
        }

        #region 猫
        string theSelectMaoID = string.Empty;
        private void ListMao()
        {
            dgMao.DataSource = _maoBLL.Get();
        }

        private void dgMao_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgMao.SelectedRows.Count <= 0)
            {
                return;
            }

            theSelectMaoID = dgv.SelectedRows[0].Cells["col_mao_id"].Value.ToString();
            BindBuilding();
        }

        private void dgMao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == indexDeleteColumn)
                {
                    int id = Convert.ToInt32(dgMao.Rows[e.RowIndex].Cells["col_mao_id"].Value);

                    if (_maoBuildingBLL.Any(it => it.mao_id == id))
                    {
                        HMMessageBox.Show(this, "请先取消猫对应的楼栋信息!");
                    }
                    else
                    {
                        DialogResult dr = HMMessageBox.Show(this, "确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)//如果点击“确定”按钮
                        {
                            _maoBLL.Delete(it => it.id == id);
                            ListMao();
                        }
                    }
                }
                else if (e.ColumnIndex == indexEditColumn)
                {
                    var i = dgMao.CurrentCell.RowIndex;
                    tbId.Text = dgMao.Rows[i].Cells["col_mao_id"].Value.ToString();
                    tbMaoNo.Text = dgMao.Rows[i].Cells["col_mao_no"].Value.ToString();
                    tbMaoName.Text = dgMao.Rows[i].Cells["col_mao_name"].Value.ToString();
                    tbIP.Text = dgMao.Rows[i].Cells["col_ip"].Value.ToString();
                    tbPort.Text = dgMao.Rows[i].Cells["col_port"].Value.ToString();
                    tbIsInit.Text = dgMao.Rows[i].Cells["col_is_init"].Value.ToString();
                    tbLastPullDate.Text = dgMao.Rows[i].Cells["col_last_pull_date"].Value.ToString();
                    btnAddMao.Text = "保存修改";
                }
                else if (e.ColumnIndex == indexInitColumn)
                {
                    DialogResult dr = HMMessageBox.Show(this, "确定要初始吗?\r\n如果确定，初始化完成前请不要关闭本系统", "初始化确认", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        int mao_id = Convert.ToInt32(dgMao.Rows[dgMao.CurrentCell.RowIndex].Cells["col_mao_id"].Value);

                        Mao _mao = _maoBLL.FirstOrDefault(it => it.id == mao_id);
                        if (_mao != null)
                        {
                            _mao.is_init = true;
                            _maoBLL.Edit(_mao);

                            Task.Run(() =>
                            {
                                InitJob job = new InitJob(_mao);
                                job.Execute();
                            });
                        }

                        ListMao();
                    }
                }
                else if (e.ColumnIndex == indexAbandonColumn)
                {
                    DialogResult dr = HMMessageBox.Show(this, "确定放弃初始吗?", "放弃初始化确认", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        int mao_id = Convert.ToInt32(dgMao.Rows[dgMao.CurrentCell.RowIndex].Cells["col_mao_id"].Value);
                        Mao _mao = _maoBLL.FirstOrDefault(it => it.id == mao_id);
                        if (_mao != null)
                        {
                            _mao.is_init = true;
                            _maoBLL.Edit(_mao);
                        }

                        ListMao();
                    }
                }
            }
        }

        private void dgMao_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ScrollGridViewOneRow_For(0);
        }
        private void ScrollGridViewOneRow_For(int i)
        {
            if (dgMao.Rows.Count > 0)
            {
                dgMao.ClearSelection();
                dgMao.CurrentCell = dgMao.Rows[i].Cells[0];//并且滚动条也会自动的滚动，显示选中的行省去了           

                dgMao.Rows[i].Selected = true;
                dgMao.FirstDisplayedScrollingRowIndex = i;

                theSelectMaoID = dgMao.SelectedRows[0].Cells["col_mao_id"].Value.ToString();

                BindBuilding();
            }
        }

        private void dgMao_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgMao.Rows[e.RowIndex].Cells["colDo"].Value = "删除";
            dgMao.Rows[e.RowIndex].Cells["colEdit"].Value = "编辑";

            if (dgMao.Rows[e.RowIndex].Cells["col_is_init"].Value.ToBool_() ?? false)
            {
                dgMao.Rows[e.RowIndex].Cells["col_init"].Value = "";
                dgMao.Rows[e.RowIndex].Cells["col_abandon_init"].Value = "";
            }
            else
            {
                dgMao.Rows[e.RowIndex].Cells["col_init"].Value = "初始化";
                dgMao.Rows[e.RowIndex].Cells["col_abandon_init"].Value = "放弃初始化";
            }
        }

        private void btnAddMao_Click(object sender, EventArgs e)
        {
            Mao _mao = new Mao()
            {
                id = tbId.Text.ToInt_() ?? 0,
                mao_no = this.tbMaoNo.Text.Trim(),
                mao_name = this.tbMaoName.Text.Trim(),
                ip = tbIP.Text.Trim(),
                port = tbPort.Text.Trim(),
                is_init = false,
                last_pull_date = DateTime.MinValue,
            };

            try
            {
                #region check
                if (string.IsNullOrWhiteSpace(_mao.mao_no))
                {
                    m_Tip.ShowItTop(tbMaoNo, "请输入猫编号");
                    return;
                }
                if (string.IsNullOrWhiteSpace(_mao.mao_name))
                {
                    m_Tip.ShowItTop(tbMaoName, "请输入猫名称");
                    return;
                }

                if (_maoBLL.Any(it => it.mao_no == _mao.mao_no && it.id != _mao.id))
                {
                    m_Tip.ShowItTop(tbMaoNo, "此猫编号已被占用");
                    return;
                }

                if (_maoBLL.Any(it => it.mao_name == _mao.mao_name && it.id != _mao.id))
                {
                    m_Tip.ShowItTop(tbMaoName, "此猫名称已存在");
                    return;
                }

                if (string.IsNullOrEmpty(_mao.ip) || _mao.ip == "http://" || _mao.ip == "https://")
                {
                    m_Tip.ShowItTop(tbIP, "请输入猫IP地址");
                    return;
                }
                if (_maoBLL.Any(it => it.ip == _mao.ip && it.id != _mao.id))
                {
                    m_Tip.ShowItTop(tbIP, "此IP地址已经存在");
                    return;
                }
                if (string.IsNullOrEmpty(_mao.port))
                {
                    m_Tip.ShowItTop(tbPort, "请输入猫端口号");
                    return;
                }
                else if (!Validate_.IsIPPort(_mao.port))
                {
                    m_Tip.ShowItTop(tbPort, "猫端口号长度不能超过5位");
                    return;
                }

                #endregion

                _maoBLL.AddOrUpdate(it => it.id == _mao.id, _mao);

                ListMao();

                dgMao.ClearSelection();
                dgMao.Rows[dgMao.Rows.Count - 1].Selected = true;

                m_Tip.ShowItTop(btnAddMao, "操作成功");

                tbId.Text = "0";
                tbMaoName.Text = string.Empty;
                tbMaoNo.Text = string.Empty;
                tbIP.Text = "http://";
                tbPort.Text = "8080";
                tbIsInit.Text = "0";
                tbLastPullDate.Text = DateTime.MinValue.ToString();
                btnAddMao.Text = "新增猫";
            }
            catch (Exception ex)
            {
                m_Tip.ShowItTop(btnAddMao, $"操作失败:{ Exception_.GetInnerException(ex).Message }");
                LogHelper.Error(ex);
            }
        }

        private void BindBuilding()
        {
            dgBuilding.DataSource = _buildingBLL.GetBuildingForMao(Convert.ToInt32(theSelectMaoID));
        }
        #endregion


        private void dgBuilding_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == indexBuildingCheckColumn)
            {
                MaoBuilding _mao_building = new MaoBuilding()
                {
                    id = Convert.ToBoolean(dgBuilding.Rows[e.RowIndex].Cells["colCB"].EditedFormattedValue) ? 0 : 1,
                    mao_id = Convert.ToInt32(theSelectMaoID),
                    building_code = dgBuilding.Rows[e.RowIndex].Cells["col_building_code"].Value.ToString()
                };
                _maoBuildingBLL.AddOrRemove(_mao_building);//wait
            }
        }

        private void btnLoadBuilding_Click(object sender, EventArgs e)
        {
            FrmLoadBaseData frmLoad = new FrmLoadBaseData(BaseDataTypeE.楼栋信息, this);
            frmLoad.ShowDialog();
        }

        private void btnLoadHouse_Click(object sender, EventArgs e)
        {
            FrmLoadBaseData frmLoad = new FrmLoadBaseData(BaseDataTypeE.房屋信息, this);
            frmLoad.ShowDialog();
        }

        private void btnLoadUser_Click(object sender, EventArgs e)
        {
            FrmLoadBaseData frmLoad = new FrmLoadBaseData(BaseDataTypeE.业主信息, this);
            frmLoad.ShowDialog();
        }
    }

    public enum BaseDataTypeE
    {
        楼栋信息 = 0,
        房屋信息 = 1,
        业主信息 = 2
    }
}
