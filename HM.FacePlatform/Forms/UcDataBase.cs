using HM.Common_;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.BasicData;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Forms;
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
    public partial class UcDataBase : UcBase
    {
        VankeBalloonToolTip m_Tip;//提示
        MaoBuildingBLL _maoBuildingBLL;
        BuildingBLL _buildingBLL;
        HouseBLL _houseBLL;
        MaoBLL _maoBLL;
        UserBLL _userBLL;
        Dictionary<int, FaceVersion> _dicVersionState = new Dictionary<int, FaceVersion>();

        /// <summary>
        /// 是否分块
        /// </summary>
        bool _IsFaceSection = Config_.GetBool("IsFaceSection") ?? false;

        public UcDataBase()
        {
            InitializeComponent();

            _maoBuildingBLL = new MaoBuildingBLL();
            _buildingBLL = new BuildingBLL();
            _houseBLL = new HouseBLL();
            _maoBLL = new MaoBLL();
            _userBLL = new UserBLL();

            DgvPerson.AllowUserToAddRows = false;
            DgvPerson.AutoGenerateColumns = false;
            DgvPerson.RowHeadersVisible = false;
            m_Tip = new VankeBalloonToolTip(this);

            DgvHouse.AutoGenerateColumns = false;
            DgvBuilding.AutoGenerateColumns = false;

            if (!_IsFaceSection)
            {
                if (DgvMao.Columns.Contains("col_map_building"))
                {
                    DgvMao.Columns["col_map_building"].Visible = false;
                }
                DgvBuilding.Visible = false;
            }
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            if (HtcMain.SelectedTab != MtpMao)
            {
                HtcMain.SelectedTab = MtpMao;
            }
            else
            {
                HtcMain_SelectedIndexChanged(HtcMain, new TabControlEventArgs(MtpMao, HtcMain.TabPages.IndexOf(MtpMao), new TabControlAction()));
            }
        }

        #region 人脸一体机

        private void BtnRefreshMao_Click(object sender, EventArgs e)
        {
            _dicVersionState = new Dictionary<int, FaceVersion>();
            FacePlatformCache.ClearCache<Mao>();
            BindMao();
        }

        /// <summary>
        /// 已选中的人脸一体机ID
        /// </summary>
        int? _SelectedMaoID = null;
        /// <summary>
        /// 绑定人脸一体机
        /// </summary>
        private void BindMao()
        {
            DgvMao.DataSource = null;
            var lst = _maoBLL.Get();
            DgvMao.DataSource = lst;
        }
        /// <summary>
        /// 标签切换绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HtcMain.SelectedTab.Equals(MtpMao))
            {
                BindMao();
            }
            else if (HtcMain.SelectedTab.Equals(MtpDataBase))
            {
                LoadBuilding();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMao_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            if (hmDGV == null) return;
            if (hmDGV.Rows == null) return;
            if (hmDGV.Rows.Count < (e.RowIndex + 1)) return;
            if (hmDGV.Rows[e.RowIndex] == null) return;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            if (cells == null) return;
            Mao mao = hmDGV.Rows[e.RowIndex].DataBoundItem as Mao;
            if (mao == null) return;
            if (hmDGV.Columns.Contains("col_del"))
                cells["col_del"].Value = "删除";
            if (hmDGV.Columns.Contains("col_edit"))
                cells["col_edit"].Value = "编辑";
            if (hmDGV.Columns.Contains("col_map_building"))
                cells["col_map_building"].Value = "去设置";
            if (mao.is_init)
            {
                cells["col_init"].Value = "";
                cells["col_abandon_init"].Value = "";
            }
            else
            {
                cells["col_init"].Value = "初始化";
                cells["col_abandon_init"].Value = "放弃初始化";
            }

            var col_version = cells["col_version"];
            if (_dicVersionState.ContainsKey(mao.id))
            {
                if (_dicVersionState[mao.id] == null)
                {
                    col_version.Value = "异常";
                }
            }
            else
            {
                Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);

                Task.Run(() =>
                {
                    FaceVersion fv = face.GetFaceVersion(new TimeSpan(0, 0, 3));
                    if (!_dicVersionState.ContainsKey(mao.id))
                    {
                        _dicVersionState.Add(mao.id, fv);
                    }
                    else
                    {
                        _dicVersionState[mao.id] = fv;
                    }

                    this.UIThread(() =>
                    {
                        if (col_version != null) //异步，存在单元格被销毁的情况！
                        {
                            col_version.Value = fv == null ? "异常" : fv.version.ToString();
                        }
                    });
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMao_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvBuilding.Visible)
            {
                var hmDGV = sender as DataGridView;
                if (hmDGV == null || DgvMao.SelectedRows.Count <= 0)
                {
                    return;
                }
                else
                {
                    int rowIndex = hmDGV.SelectedRows[0].Index;
                    var cells = hmDGV.Rows[rowIndex].Cells;
                    Mao mao = hmDGV.Rows[rowIndex].DataBoundItem as Mao;
                    _SelectedMaoID = mao.id;
                    BindBuilding(mao.id);
                }
            }
        }
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            else
            {
                HMDataGridView hmDGV = (HMDataGridView)sender;
                var cells = hmDGV.Rows[e.RowIndex].Cells;
                Mao mao = hmDGV.Rows[e.RowIndex].DataBoundItem as Mao;
                if (cells[e.ColumnIndex].OwningColumn.Name == "col_del")
                {
                    if (_maoBuildingBLL.Any(it => it.mao_id == mao.id))
                    {
                        HMMessageBox.Show(this, "请先取消人脸一体机关联的楼栋信息!");
                    }
                    else
                    {
                        DialogResult dr = HMMessageBox.Show(this, "确定要删除吗?", "删除确认", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            var result = _maoBLL.Delete(it => it.id == mao.id);
                            if (result.IsSuccess)
                            {
                                FacePlatformCache.ClearCache<Mao>();
                                BindMao();
                            }
                            else
                            {
                                HMMessageBox.Show(this, result.ToAlertString());
                            }
                        }
                    }
                }
                else if (cells[e.ColumnIndex].OwningColumn.Name == "col_edit")
                {
                    RenderMao(mao);
                }
                else if (cells[e.ColumnIndex].OwningColumn.Name == "col_init")
                {
                    DialogResult dr = HMMessageBox.Show(this, "确定要初始吗?\r\n如果确定，初始化完成前请不要关闭本系统", "初始化确认", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        Mao _mao = _maoBLL.FirstOrDefault(it => it.id == mao.id);

                        bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
                        if (isFaceSection)
                        {
                            bool anyMaoBuilding = _maoBuildingBLL.Any(it => it.mao_id == mao.id && it.is_del != IsDelType.是);
                            if (!anyMaoBuilding)
                            {
                                HMMessageBox.Show(this, "系统已启用分区块功能，但您未关联楼栋，不能进行初始化！");
                                return;
                            }
                        }

                        if (_mao != null)
                        {
                            cells[e.ColumnIndex].ReadOnly = true;
                            Task.Run(() =>
                            {
                                InitJob job = new InitJob(_mao);
                                job.Execute();
                            }).ContinueWith((task) =>
                            {
                                _mao.is_init = true;
                                _maoBLL.Edit(_mao);
                                BindMao();
                            });
                        }
                    }
                }
                else if (cells[e.ColumnIndex].OwningColumn.Name == "col_abandon_init")
                {
                    DialogResult dr = HMMessageBox.Show(this, "确定放弃初始吗?", "放弃初始化确认", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        Mao _mao = _maoBLL.FirstOrDefault(it => it.id == mao.id);
                        if (_mao != null)
                        {
                            _mao.is_init = true;
                            _maoBLL.Edit(_mao);
                        }
                        BindMao();
                    }
                }
                else if (cells[e.ColumnIndex].OwningColumn.Name == "col_map_building")
                {
                    MapBuildingFrm mapBuildingFrm = new MapBuildingFrm(mao);
                    DialogResult dr = mapBuildingFrm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        BindMao();
                    }
                }
            }
        }
        /// <summary>
        /// 绑定完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvMao_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //DgvMao.ClearSelection();
            //if (DgvMao.Rows.Count > 0)
            //{
            //    int i = 0;
            //    DataGridViewRow row = DgvMao.Rows[i];
            //    row.Selected = true;
            //    DgvMao.CurrentCell = row.Cells[0];
            //    DgvMao.FirstDisplayedScrollingRowIndex = i;
            //    Mao mao = row.DataBoundItem as Mao;
            //    BindBuilding(mao.id);
            //}
        }
        /// <summary>
        /// 绑定楼栋
        /// </summary>
        /// <param name="mao_id"></param>
        private void BindBuilding(int mao_id)
        {
            DgvBuilding.DataSource = null;
            var lst = _buildingBLL.GetBuildingForMao(mao_id);
            DgvBuilding.DataSource = lst;
        }
        private void BtnCancelMao_Click(object sender, EventArgs e)
        {
            RenderMao(null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddMao_Click(object sender, EventArgs e)
        {
            try
            {
                Mao mao = null;
                if (BtnAddMao.Tag != null)
                {
                    mao = BtnAddMao.Tag as Mao;
                }
                int id = (mao?.id) ?? 0;
                string mao_name_old = (mao?.mao_name) ?? string.Empty;
                string mao_no = this.tbMaoNo.Text.Trim();
                string mao_name = this.tbMaoName.Text.Trim();
                string ip = tbIP.Text.Trim();
                string port = tbPort.Text.Trim();

                #region check
                if (string.IsNullOrWhiteSpace(mao_no))
                {
                    m_Tip.ShowItTop(tbMaoNo, "请输入人脸一体机编号");
                    return;
                }

                if (_maoBLL.Any(it => it.mao_no == mao_no && it.id != id))
                {
                    m_Tip.ShowItTop(tbMaoNo, "此人脸一体机编号已被占用");
                    return;
                }

                if (string.IsNullOrWhiteSpace(mao_name))
                {
                    m_Tip.ShowItTop(tbMaoName, "请输入人脸一体机名称");
                    return;
                }

                if (_maoBLL.Any(it => it.mao_name == mao_name_old && it.id != id))
                {
                    m_Tip.ShowItTop(tbMaoName, "此名称已存在");
                    return;
                }

                if (string.IsNullOrEmpty(ip) || ip == "http://" || ip == "https://")
                {
                    m_Tip.ShowItTop(tbIP, "请输入IP地址");
                    return;
                }
                else
                {
                    string trueIp = ip.Replace("https://", "").Replace("http://", "");
                    if (!Validate_.IsIPAddress(trueIp))
                    {
                        m_Tip.ShowItTop(tbIP, "请输入正确的IP地址");
                        return;
                    }
                }
                if (_maoBLL.Any(it => it.ip == ip && it.id != id))
                {
                    m_Tip.ShowItTop(tbIP, "此IP地址已经存在");
                    return;
                }
                if (string.IsNullOrEmpty(port))
                {
                    m_Tip.ShowItTop(tbPort, "请输入端口号");
                    return;
                }
                else if (!Validate_.IsIPPort(port))
                {
                    m_Tip.ShowItTop(tbPort, "端口号范围应为【0-65535】");
                    return;
                }

                #endregion
                if (id == 0)
                {
                    mao = new Mao()
                    {
                        ip = ip,
                        is_init = false,
                        last_pull_date = DateTime.MinValue,
                        mao_name = mao_name,
                        mao_no = mao_no,
                        port = port
                    };
                    var addResult = _maoBLL.Add(mao);
                    if (addResult != null)
                    {
                        FacePlatformCache.ClearCache<Mao>();
                        m_Tip.ShowItTop(BtnAddMao, "新建成功");
                        BindMao();
                        RenderMao(null);
                    }
                    else
                    {
                        m_Tip.ShowItTop(BtnAddMao, "新建失败");
                    }
                }
                else
                {
                    var dbMao = _maoBLL.FirstOrDefault(it => it.id == id);
                    if (dbMao != null)
                    {
                        mao = dbMao;
                        dbMao.ip = ip;
                        dbMao.mao_name = mao_name;
                        dbMao.mao_no = mao_no;
                        dbMao.port = port;
                        var editResult = _maoBLL.Edit(dbMao);
                        if (editResult.IsSuccess)
                        {
                            FacePlatformCache.ClearCache<Mao>();
                            m_Tip.ShowItTop(BtnAddMao, "修改成功");
                            BindMao();
                            RenderMao(null);
                        }
                        else
                        {
                            m_Tip.ShowItTop(BtnAddMao, editResult.ToAlertString());
                        }
                    }
                    else
                    {
                        m_Tip.ShowItTop(BtnAddMao, "此人脸一体机信息已不存在！");
                    }
                }
            }
            catch (Exception ex)
            {
                m_Tip.ShowItTop(BtnAddMao, $"操作失败:{ Exception_.GetInnerException(ex).Message }");
                LogHelper.Error(ex);
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="mao"></param>
        public void RenderMao(Mao mao)
        {
            if (mao == null)
            {
                tbMaoName.Text = string.Empty;
                tbMaoNo.Text = string.Empty;
                tbIP.Text = "http://";
                tbPort.Text = "8080";
                BtnAddMao.Text = "新增";
                BtnAddMao.Tag = null;//在Tag存放Mao对象
            }
            else
            {
                tbMaoNo.Text = mao.mao_no.ToString();
                tbMaoName.Text = mao.mao_name;
                tbIP.Text = mao.ip;
                tbPort.Text = mao.port.ToString();
                BtnAddMao.Text = "保存";
                BtnAddMao.Tag = mao;//在Tag存放Mao对象
            }
        }
        #endregion

        public void LoadBuilding()
        {
            TvBuilding.Nodes.Clear();
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

            TvBuilding.Nodes.Add(root);
            TvBuilding.ExpandAll();
            //让第一行被选中
            if (TvBuilding.Nodes.Count > 0)
            {
                if (TvBuilding.Nodes[0].Nodes.Count > 0)
                {
                    SelectNodeStyle(TvBuilding.Nodes[0].Nodes[0]);
                }
            }
        }

        /// <summary>
        /// 设置某一行的风格
        /// </summary>
        private void SelectNodeStyle(TreeNode nodeVar)
        {
            //取消选中
            TvBuilding.Nodes[0].ForeColor = Color.Black;
            TvBuilding.Nodes[0].BackColor = Color.White;
            foreach (TreeNode node in TvBuilding.Nodes[0].Nodes)
            {
                node.ForeColor = Color.Black;
                node.BackColor = Color.White;
            }

            TvBuilding.SelectedNode = nodeVar;
            nodeVar.Checked = true;
            nodeVar.ForeColor = Color.White;
            nodeVar.BackColor = Color.FromArgb(0, 174, 219);
        }

        public void LoadHouse()
        {
            try
            {
                if (TvBuilding.SelectedNode != null)
                {
                    string building_code = TvBuilding.SelectedNode.Tag as string;

                    DgvHouse.DataSource = null;
                    if (TvBuilding.SelectedNode.Parent != null)
                    {
                        var _houses = _houseBLL.Get(it => it.building_code == building_code, true, it => it.house_name);
                        if (_houses.Count > 0)
                        {
                            DgvHouse.DataSource = _houses;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void TvBuilding_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (TvBuilding.SelectedNode != null)
                {
                    string building_code = TvBuilding.SelectedNode.Tag as string;

                    SelectNodeStyle(TvBuilding.SelectedNode);

                    if (TvBuilding.SelectedNode.Parent != null)
                    {
                        LoadHouse();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="house_code"></param>
        public void LoadPerson(string house_code)
        {
            try
            {
                DgvPerson.DataSource = null;
                ActionResult<List<UserForDataBaseDto>> result = _userBLL.GetUserByHouseCode(house_code);
                if (result.IsSuccess)
                {
                    if (result.Obj != null && result.Obj.Any())
                    {
                        DgvPerson.DataSource = result.Obj;
                    }
                }
                else
                {
                    HMMessageBox.Show(this, result.ToAlertString());
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DgvHouse_SelectionChanged(object sender, EventArgs e)
        {
            BindUserData();
        }

        public void BindUserData()
        {
            try
            {
                if (DgvHouse.SelectedRows.Count <= 0)
                {
                    return;
                }
                var code = DgvHouse.SelectedRows[0].Cells["ColCode"].Value as string;
                LoadPerson(code);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            LoadHouse();
        }

        private void TbxQuery_TextChanged(object sender, EventArgs e)
        {
            TbxQuery.Text = Validate_.GetSafeString(ControlType.姓名类, TbxQuery.Text);
        }

        //private void DgvBuilding_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0) return;
        //    if (DgvBuilding.Columns[e.ColumnIndex].Name == "colCB")
        //    {
        //        MaoBuilding _mao_building = new MaoBuilding()
        //        {
        //            id = Convert.ToBoolean(DgvBuilding.Rows[e.RowIndex].Cells["colCB"].EditedFormattedValue) ? 0 : 1,
        //            mao_id = Convert.ToInt32(_SelectedMaoID),
        //            building_code = DgvBuilding.Rows[e.RowIndex].Cells["col_building_code"].Value.ToString()
        //        };
        //        _maoBuildingBLL.AddOrRemove(_mao_building);//wait
        //    }
        //}

        private void BtnLoadBuilding_Click(object sender, EventArgs e)
        {
            FrmLoadBaseData frmLoad = new FrmLoadBaseData(BaseDataTypeE.楼栋信息, this);
            frmLoad.ShowDialog();
        }

        private void BtnLoadHouse_Click(object sender, EventArgs e)
        {
            FrmLoadBaseData frmLoad = new FrmLoadBaseData(BaseDataTypeE.房屋信息, this);
            frmLoad.ShowDialog();
        }

        private void BtnLoadUser_Click(object sender, EventArgs e)
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
