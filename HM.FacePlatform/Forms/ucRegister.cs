﻿using HM.Common_;
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
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform
{
    public partial class UcRegister : UcBase
    {
        MaoBLL _maoBLL = new MaoBLL();
        MaoFailedJobBLL _maoFailedJobBLL = new MaoFailedJobBLL();
        BuildingBLL _buildingBLL = new BuildingBLL();
        HouseBLL _houseBLL = new HouseBLL();
        UserBLL _userBLL = new UserBLL();
        RegisterBLL _registerBLL = new RegisterBLL();
        UserHouseBLL _userHouseBLL = new UserHouseBLL();
        string _propertyHouseCode;

        VankeBalloonToolTip _Tip;//提示
        TreeNode _selectedTreeNode = null;

        /// <summary>
        /// 
        /// </summary>
        public UcRegister()
        {
            //允许线程直接访问控件
            Control.CheckForIllegalCrossThreadCalls = false;

            _Tip = new VankeBalloonToolTip(this);

            InitializeComponent();

            DgvHouse.AllowUserToAddRows = false;
            DgvHouse.AutoGenerateColumns = false;
            DgvHouse.RowHeadersVisible = false;
            splitter1.BackColor = Color.FromArgb(224, 224, 224);
            FlpUser.HorizontalScroll.Maximum = 0;
            FlpUser.AutoScroll = true;

            _propertyHouseCode = Program._Mainform._PropertyHouseCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UcRegister_Load(object sender, EventArgs e)
        {
            if (HtcMain.SelectedTab != MtpUser)
            {
                HtcMain.SelectedTab = MtpUser;
            }
            else
            {
                HtcMain_SelectedIndexChanged(HtcMain, new TabControlEventArgs(MtpUser, HtcMain.TabPages.IndexOf(MtpUser), new TabControlAction()));
            }
            Task.Run(() =>
            {
                while (true)
                {
                    RegCount();
                    Thread.Sleep(60 * 1000);
                }
            });
        }

        /// <summary>
        /// 选项卡切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HtcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HtcMain.SelectedTab.Equals(MtpUser))
            {
                LoadBuilding();
            }
            else if (HtcMain.SelectedTab.Equals(MtpWorker))
            {
                PagerWorker.Bind();
            }
            else
            {
                throw new Exception("添加一个Tab,请在此方法添加对应的处理！");
            }
        }

        /// <summary>
        /// 获取注册人靓比例
        /// </summary>
        void RegCount()
        {
            var result = _registerBLL.GetRegistedAndUserCount();
            if (result.IsSuccess)
            {
                this.UIThread(() =>
                {
                    labRegCount.Text = result.Obj.Item2 + "/" + result.Obj.Item1;
                });
            }
        }
        #region 
        /// <summary>
        /// 切换显示方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogTree_CheckedChanged(object sender, EventArgs e)
        {
            LoadBuilding();
        }
        /// <summary>
        /// 加载楼栋
        /// </summary>
        void LoadBuilding()
        {
            labProject.Text = Program._Mainform._ProjectName;

            if (TogTree.Checked)
            {
                CreateNodes();
            }
            else
            {
                CreateNodesByMao();
            }
            //让第一行被选中
            if (TvBuilding.Nodes.Count > 0)
            {
                if (TvBuilding.Nodes[0].Nodes.Count > 0)
                {
                    TvBuilding.SelectedNode = TvBuilding.Nodes[0].Nodes[0];
                }
            }
        }
        /// <summary>
        /// 以项目作为根结点的树
        /// </summary>
        /// <param name="buildings"></param>
        void CreateNodes()
        {
            TvBuilding.Nodes.Clear();
            //创建根结点
            TreeNode nodeProject = new TreeNode
            {
                Text = Program._Mainform._ProjectName,
                Tag = Program._Mainform._ProjectCode,
                ForeColor = Color.Blue,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };

            IList<Building> buildings = _buildingBLL.Get(it => it.project_code == Program._Mainform._ProjectCode);

            foreach (Building _building in buildings)
            {
                TreeNode nodeBuilding = new TreeNode
                {
                    Text = _building.building_name,
                    Tag = _building,
                    ImageIndex = 0,
                    SelectedImageIndex = 0
                };
                nodeProject.Nodes.Add(nodeBuilding);
            }
            TvBuilding.Nodes.Add(nodeProject);
            TvBuilding.ExpandAll();
        }
        /// <summary>
        /// 以猫为父节点创建的树
        /// </summary>
        void CreateNodesByMao()
        {
            TvBuilding.Nodes.Clear();
            var lstMao = FacePlatformCache.GetALL<Mao>();
            foreach (Mao mao in lstMao)
            {
                TreeNode nodeMao = new TreeNode();
                nodeMao.Text = mao.mao_name;
                nodeMao.Tag = mao;
                nodeMao.ForeColor = Color.Blue;
                nodeMao.ImageIndex = 0;
                nodeMao.SelectedImageIndex = 0;

                IList<Building> buildings = _buildingBLL.Get(it => it.MaoBuildings.Any(mb => mb.mao_id == mao.id));
                foreach (Building _building in buildings)
                {
                    TreeNode nodeBuilding = new TreeNode();
                    nodeBuilding.Text = _building.building_name;
                    nodeBuilding.Tag = _building;
                    nodeBuilding.ImageIndex = 0;
                    nodeBuilding.SelectedImageIndex = 0;
                    nodeMao.Nodes.Add(nodeBuilding);
                }
                TvBuilding.Nodes.Add(nodeMao);
            }

            TvBuilding.ExpandAll();
        }
        /// <summary>
        /// 让某一行被选中
        /// </summary>
        /// <param name="treeNode"></param>
        void SelectNodeStyle(TreeView treeView, TreeNodeCollection nodes, TreeNode treeNodeSelected)
        {
            foreach (TreeNode nodeItem in nodes)
            {
                nodeItem.ForeColor = Color.Black;
                nodeItem.BackColor = Color.White;
                if (nodeItem.Nodes != null && nodeItem.Nodes.Count > 0)
                {
                    SelectNodeStyle(treeView, nodeItem.Nodes, treeNodeSelected);
                }
                if (nodeItem == treeNodeSelected)
                {
                    //treeNodeSelected.Checked = true;
                    treeNodeSelected.ForeColor = Color.White;
                    treeNodeSelected.BackColor = Color.FromArgb(67, 152, 237);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TvBuilding_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TvBuilding.SelectedNode != null)
            {
                SelectNodeStyle(TvBuilding, TvBuilding.Nodes, TvBuilding.SelectedNode);
                txtUserName.Text = string.Empty;

                if (TvBuilding.SelectedNode.Tag is Building)
                {
                    _selectedTreeNode = TvBuilding.SelectedNode;
                }
                else
                {
                    _selectedTreeNode = null;
                }
                PagerHouse.Bind();
            }
        }
        /// <summary>
        /// 房屋列表分页
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerHouse_EventPaging(EventPagingArg e)
        {
            DgvHouse.ClearSelection();
            DgvHouse.DataSource = null;
            ActionResult<PagerData<HouseForRegisterDto>> result = null;
            if (_selectedTreeNode == null)
            {
                result = new ActionResult<PagerData<HouseForRegisterDto>>()
                {
                    IsSuccess = false
                };
            }
            else
            {
                string userName = txtUserName.Text.Trim();
                var building = _selectedTreeNode.Tag as Building;
                result = _houseBLL.GetPageHouseForRegisterDto(PagerHouse.PageIndex, PagerHouse.PageSize, building.building_code, userName);
            }
            if (!result.IsSuccess)
            {
                if (_selectedTreeNode != null)
                {
                    HMMessageBox.Show(this, result.ToAlertString());
                }
                result.Obj = new PagerData<HouseForRegisterDto>()
                {
                    pages = 0,
                    rows = new List<HouseForRegisterDto>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerHouse.bsPager.DataSource = result.Obj.rows;
            PagerHouse.bnPager.BindingSource = PagerHouse.bsPager;
            //分页控件绑定DataGridView
            DgvHouse.DataSource = PagerHouse.bsPager;
            //返回总记录数
            return result.Obj.total;
        }

        public void BtnSearchHouse_Click(object sender, EventArgs e)
        {
            btnNewUser.Visible = false;
            PagerHouse.Bind();
            btnNewUser.Visible = true;
        }
        /// <summary>
        /// 清除用户面板
        /// </summary>
        public void ClearUser()
        {
            FlpUser.Controls.Clear();
        }
        /// <summary>
        /// 绑定房屋
        /// </summary>
        /// <param name="house_code"></param>
        public void BindHouse(string house_code)
        {
            btnNewUser.Visible = false;
            PagerHouse.Bind();
            foreach (DataGridViewRow row in DgvHouse.Rows)
            {
                HouseForRegisterDto houseForRegisterDto = row.DataBoundItem as HouseForRegisterDto;
                if (houseForRegisterDto.house_code == house_code)
                {
                    row.Selected = true;
                }
            }
            btnNewUser.Visible = true;
        }
        /// <summary>
        /// 选中某项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DgvHouse_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ClearUser();
                HMDataGridView hmDGV = (HMDataGridView)sender;
                if (hmDGV != null && hmDGV.Rows.Count > 0 && hmDGV.SelectedRows.Count > 0)
                {
                    HouseForRegisterDto houseForRegisterDto = hmDGV.SelectedRows[0].DataBoundItem as HouseForRegisterDto;
                    Task.Run(() =>
                    {
                        BindHouseUser(houseForRegisterDto.house_code);
                    });
                    btnNewUser.Visible = !(houseForRegisterDto.house_code == _propertyHouseCode);
                }
            }
            catch (Exception ex)
            {

            }

        }
        /// <summary>
        /// 绑定房屋下的业主（拥有、居住等）
        /// </summary>
        /// <param name="house_code"></param>
        public void BindHouseUser(string house_code)
        {
            ActionResult<List<UserHouse>> result = _houseBLL.GetUserHouseWithUserAndHouse(house_code);
            if (result.IsSuccess)
            {
                this.UIThread(() =>
                {
                    FlpUser.Controls.Clear();
                    if (result.Obj != null && result.Obj.Any())
                    {
                        foreach (UserHouse userHouse in result.Obj)
                        {
                            UcFamily ucFamily = new UcFamily(userHouse);
                            ucFamily.UpdateAction = (uc_Family) =>
                            {
                                AddOrUpdateUserFrm frm = new AddOrUpdateUserFrm(this, userHouse);
                                frm.ShowDialog();
                            };
                            ucFamily.DeleteAction = () =>
                            {
                                BindHouseUser(house_code);
                            };
                            FlpUser.Controls.Add(ucFamily);
                        }
                    }
                    else
                    {
                        ucNoData uc = new ucNoData();
                        uc.Note = "暂无用户数据";
                        FlpUser.Controls.Add(uc);
                    }
                });
            }
            else
            {
                this.UIThread(() =>
                {
                    HMMessageBox.Show(this, result.ToAlertString());
                });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvHouse_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //HMDataGridView hmDGV = (HMDataGridView)sender;
            //var cells = hmDGV.Rows[e.RowIndex].Cells;
            //HouseForRegisterDto houseForRegisterDto = hmDGV.Rows[e.RowIndex].DataBoundItem as HouseForRegisterDto;

            //if (houseForRegisterDto == null) return;
        }

        #region 绑定工作人员数据
        /// <summary>
        /// 工作人员数据分页绑定事件
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int PagerWorker_EventPaging(EventPagingArg e)
        {
            string workerKey = tbWorkerSelect.Text.Trim();

            bool? registeState = null;
            if (radSelectAll.Checked) registeState = null;
            else if (radSelectYes.Checked) registeState = true;
            else if (radSelectNo.Checked) registeState = false;

            var result = _userBLL.GetWorkerUserForRegister(PagerWorker.PageIndex, PagerWorker.PageSize, _propertyHouseCode, workerKey, registeState);
            if (!result.IsSuccess)
            {
                HMMessageBox.Show(this, result.ToAlertString());
                result.Obj = new PagerData<User>()
                {
                    pages = 0,
                    rows = new List<User>(),
                    total = 0
                };
            }
            //绑定分页控件
            PagerWorker.bsPager.DataSource = result.Obj.rows;
            PagerWorker.bnPager.BindingSource = PagerWorker.bsPager;
            //分页控件绑定DataGridView
            PageWorkerRender(result.Obj.rows);
            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 呈现工作人员人脸信息
        /// </summary>
        /// <param name="obj"></param>
        void PageWorkerRender(List<User> userWithRelations)
        {
            this.UIThread(() =>
            {
                FlpWorker.Controls.Clear();
                if (userWithRelations != null && userWithRelations.Any())
                {
                    foreach (User userWithRelation in userWithRelations)
                    {
                        var userHouse = _userHouseBLL.GetUserHouseWithUserAndHouse(userWithRelation.user_uid, _propertyHouseCode);

                        if (userHouse != null)
                        {
                            UcFamily ucFamily = new UcFamily(userHouse);
                            ucFamily.Width = FlpWorker.Width / 3 - 10;
                            ucFamily.UpdateAction = (uc_Family) =>
                            {
                                AddOrUpdateUserFrm form = new AddOrUpdateUserFrm(this, userHouse);
                                form.ShowDialog();
                            };
                            ucFamily.DeleteAction = () =>
                            {
                                BindWorkers();
                            };
                            FlpWorker.Controls.Add(ucFamily);
                        }
                    }
                }
                else
                {
                    ucNoData u = new ucNoData();
                    u.Note = "暂无工作人员数据";
                    FlpWorker.Controls.Add(u);
                }
            });
        }
        /// <summary>
        /// 查询工作人员人脸信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnWorkerSelect_Click(object sender, EventArgs e)
        {
            PagerWorker.Bind();
        }

        public void BindWorkers()
        {
            PagerWorker.Bind();
        }
        #endregion


        /// <summary>
        /// 添加工作人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddWorker_Click(object sender, EventArgs e)
        {
            var house = _houseBLL.FirstOrDefault(it => it.house_code == _propertyHouseCode);
            if (house != null)
            {
                AddOrUpdateWorkerFrm addOrUpdateUserFrm = new AddOrUpdateWorkerFrm(this, house);
                addOrUpdateUserFrm.ShowDialog();
            }
            else
            {
                LogHelper.Fatal($"找不到虚拟楼栋下的虚拟房屋【{_propertyHouseCode}】！");
            }
        }


        void tbSelect_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text = Validate_.GetSafeString(ControlType.姓名类, txtUserName.Text);
        }

        void tbWorkerSelect_TextChanged(object sender, EventArgs e)
        {
            tbWorkerSelect.Text = Validate_.GetSafeString(ControlType.姓名类, tbWorkerSelect.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnNewUser_Click(object sender, EventArgs e)
        {
            if (DgvHouse.SelectedRows != null && DgvHouse.SelectedRows.Count > 0)
            {
                HouseForRegisterDto houseForRegisterDto = DgvHouse.SelectedRows[0].DataBoundItem as HouseForRegisterDto;
                var house = _houseBLL.FirstOrDefault(it => it.house_code == houseForRegisterDto.house_code);
                if (house != null)
                {
                    AddOrUpdateUserFrm addOrUpdateUserFrm = new AddOrUpdateUserFrm(this, house);
                    DialogResult dr = addOrUpdateUserFrm.ShowDialog();
                    if (dr != DialogResult.Cancel)
                    {
                        RegCount();
                    }
                }
                else
                {
                    _Tip.ShowItTop(btnNewUser, "房屋信息已无效！");
                }
            }
            else
            {
                _Tip.ShowItTop(btnNewUser, "未选定房屋！");
            }
        }
        #endregion

        void Register_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //LoadBuilding();
            }
        }


        #region 批量注册工作人员照片
        void lbtnSelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择照片文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPicUrl.Text = dialog.SelectedPath;
            }
        }

        void btnRegS_Click(object sender, EventArgs e)
        {
            if (tbPicUrl.Text.Trim() == string.Empty)
            {
                _Tip.ShowIt(tbPicUrl, "请选择照片文件路径!");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(tbPicUrl.Text.Trim());
            if (dir.Exists)
            {
                FileInfo[] arrFileInfo = dir.GetFiles();
                if (arrFileInfo != null && arrFileInfo.Length > 0)
                {
                    FaceJobFrm faceJobFrm = new FaceJobFrm();
                    var result = faceJobFrm.BasicCheck(house_code: _propertyHouseCode);
                    if (result.IsSuccess)
                    {
                        faceJobFrm.RegisterPictures(result.Obj, arrFileInfo);
                        var dr = faceJobFrm.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            tbPicUrl.Text = string.Empty;
                            btnWorkerSelect_Click(btnWorkerSelect, null);
                        }
                    }
                }
                else
                {
                    _Tip.ShowIt(tbPicUrl, "请选择包含照片文件的路径!");
                }
            }
        }
        #endregion

        void radSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectAll.Checked) PagerWorker.Bind();
        }

        void radSelectYes_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectYes.Checked) PagerWorker.Bind();
        }

        void radSelectNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectNo.Checked) PagerWorker.Bind();
        }


    }
}