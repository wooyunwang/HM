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
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace HM.FacePlatform
{
    public partial class ucRegister : HMUserControl
    {

        MaoBLL _maoBLL = new MaoBLL();
        MaoFailedJobBLL _maoFailedJobBLL = new MaoFailedJobBLL();
        BuildingBLL _buildingBLL = new BuildingBLL();
        HouseBLL _houseBLL = new HouseBLL();
        UserBLL _userBLL = new UserBLL();
        RegisterBLL _registerBLL = new RegisterBLL();

        IList<Mao> _maos;
        House _propertyHouse;

        VankeBalloonToolTip m_Tip;//提示
        string theSelectBuilding_code = string.Empty;
        public string theSelectHouseCode = string.Empty;
        public string theSelectHouseName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ucRegister()
        {
            //允许线程直接访问控件
            Control.CheckForIllegalCrossThreadCalls = false;

            m_Tip = new VankeBalloonToolTip(this);

            InitializeComponent();

            dgUser.AllowUserToAddRows = false;
            dgUser.AutoGenerateColumns = false;
            dgUser.RowHeadersVisible = false;
            splitter1.BackColor = Color.FromArgb(224, 224, 224);
            FlpUser.HorizontalScroll.Maximum = 0;
            FlpUser.AutoScroll = true;

            _propertyHouse = _houseBLL.FirstOrDefault(it => it.house_code == Program._Mainform._PropertyHouseCode);

        }

        void Register_Load(object sender, EventArgs e)
        {

            LoadBuilding();
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
        void LoadMao()
        {
            _maos = _maoBLL.Get();
        }
        /// <summary>
        /// 加载楼栋
        /// </summary>
        void LoadBuilding()
        {
            this.UIThread(() =>
            {
                labProject.Text = Program._Mainform._ProjectName;
            });

            IList<Building> buildings = _buildingBLL.Get(it => it.project_code == Program._Mainform._ProjectCode);
            CreateNodes(buildings);
            //让第一行被选中
            if (treBuilding.Nodes.Count > 0)
            {
                if (treBuilding.Nodes[0].Nodes.Count > 0)
                {
                    SelectNode(treBuilding.Nodes[0].Nodes[0]);
                }
            }
        }
        /// <summary>
        /// 以项目作为根结点的树
        /// </summary>
        /// <param name="buildings"></param>
        void CreateNodes(IList<Building> buildings)
        {
            treBuilding.Nodes.Clear();
            //创建根结点
            TreeNode nodeProject = new TreeNode
            {
                Text = Program._Mainform._ProjectName,
                Tag = Program._Mainform._ProjectCode,
                ForeColor = Color.Blue,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };

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
            treBuilding.Nodes.Add(nodeProject);
            treBuilding.ExpandAll();
        }
        /// <summary>
        /// 以猫为父节点创建的树
        /// </summary>
        void CreateNodesByMao()
        {
            treBuilding.Nodes.Clear();

            foreach (Mao _mao in _maos)
            {
                TreeNode nodeMao = new TreeNode();
                nodeMao.Text = _mao.mao_name;
                nodeMao.Tag = _mao;
                nodeMao.ForeColor = Color.Blue;
                nodeMao.ImageIndex = 0;
                nodeMao.SelectedImageIndex = 0;

                IList<Building> buildings = _buildingBLL.Get(it => it.MaoBuildings.Any(mb => mb.mao_id == _mao.id));
                foreach (Building _building in buildings)
                {
                    TreeNode nodeBuilding = new TreeNode();
                    nodeBuilding.Text = _building.building_name;
                    nodeBuilding.Tag = _building;
                    nodeBuilding.ImageIndex = 0;
                    nodeBuilding.SelectedImageIndex = 0;
                    nodeMao.Nodes.Add(nodeBuilding);
                }
                treBuilding.Nodes.Add(nodeMao);
            }

            treBuilding.ExpandAll();
        }
        /// <summary>
        /// 让某一行被选中
        /// </summary>
        void SelectNode(TreeNode nodeVar)
        {
            //取消选中
            foreach (TreeNode nodeF in treBuilding.Nodes)
            {
                nodeF.ForeColor = Color.Black;
                nodeF.BackColor = Color.White;
                foreach (TreeNode node in nodeF.Nodes)
                {
                    node.ForeColor = Color.Black;
                    node.BackColor = Color.White;
                }
            }
            treBuilding.SelectedNode = nodeVar;
            nodeVar.Checked = true;
            nodeVar.ForeColor = Color.White;
            nodeVar.BackColor = Color.FromArgb(67, 152, 237);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treBuilding_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treBuilding.SelectedNode != null)
            {
                theSelectHouseCode = string.Empty;

                SelectNode(treBuilding.SelectedNode);
                txtUserName.Text = string.Empty;

                if (treBuilding.SelectedNode.Parent == null)
                {
                    theSelectBuilding_code = string.Empty;//选中的是项目
                }
                else
                {
                    theSelectBuilding_code = treBuilding.SelectedNode.Tag.ToString();//选中的是楼栋
                    Task.Run(() =>
                    {
                        pagerHouse.Bind();
                    });
                }
            }
        }
        /// <summary>
        /// 房屋列表分页
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int pagerHouse_EventPaging(EventPagingArg e)
        {
            string userName = txtUserName.Text.Trim();
            var result = _houseBLL.GetHousePageByBuildingCode(pagerHouse.PageIndex, pagerHouse.PageSize, userName);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ToAlertString());
                result.Obj = new PagerData<House>()
                {
                    pages = 0,
                    rows = new List<House>(),
                    total = 0
                };
            }
            //绑定分页控件
            pagerHouse.bsPager.DataSource = result.Obj.rows;
            pagerHouse.bnPager.BindingSource = pagerHouse.bsPager;
            //分页控件绑定DataGridView
            dgUser.DataSource = pagerHouse.bsPager;
            //返回总记录数
            return result.Obj.total;
        }

        public void btnSelect_Click(object sender, EventArgs e)
        {
            btnNewUser.Visible = false;
            pagerHouse.Bind();
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
            pagerHouse.Bind();
            foreach (DataGridViewRow row in dgUser.Rows)
            {
                House house = row.DataBoundItem as House;
                if (house.house_code == house_code)
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
        void dgUser_SelectionChanged(object sender, EventArgs e)
        {
            ClearUser();
            var dgv = (DataGridView)sender;
            if (dgv == null || dgv.SelectedRows.Count <= 0)
            {
                //
            }
            else
            {
                var row = dgv.SelectedRows[0];
                House house = (House)row.DataBoundItem;

                Task.Run(() =>
                {
                    BindHouseUser(house.house_code);
                });

                btnNewUser.Visible = !(house.house_code == _propertyHouse.house_code);
            }
        }
        /// <summary>
        /// 绑定房屋下的业主（拥有、居住等）
        /// </summary>
        /// <param name="house_code"></param>
        public void BindHouseUser(string house_code)
        {
            IList<User> lstUser = _userBLL.Get(it => it.UserHouses.Any(uh => uh.house_code == house_code && it.is_del != IsDelType.是));

            this.UIThread(() =>
            {
                FlpUser.Controls.Clear();
                if (lstUser != null && lstUser.Any())
                {
                    foreach (User user in lstUser)
                    {
                        ucFamily u1 = new ucFamily(user.UserHouses.Where(it => it.house_code == house_code).FirstOrDefault());
                        u1.UpdateAction += new Action<ucFamily>((uc_Family) =>
                        {
                            //AddOrUpdateUserFrm form = new AddOrUpdateUserFrm(this, uc_Family);
                            //form.ShowDialog();
                        });
                        FlpUser.Controls.Add(u1);
                    }
                }
                else
                {
                    ucNoData u = new ucNoData();
                    u.Note = "暂无用户数据";
                    FlpUser.Controls.Add(u);
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUser_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HMDataGridView hmDGV = (HMDataGridView)sender;
            var cells = hmDGV.Rows[e.RowIndex].Cells;
            House house = hmDGV.Rows[e.RowIndex].DataBoundItem as House;

            if (house == null) return;
            cells["col_name_"].Value = string.Join("，", house.UserHouses
                .Where(it => it.user_type == UserType.家庭成员 && it.is_del != IsDelType.是)
                .Select(it => it.User.name));
            cells["ColFamilyCount"].Value = house.UserHouses
                .Where(it => it.user_type == UserType.家庭成员 && it.is_del != IsDelType.是).Count();
            cells["ColGuestCount"].Value = house.UserHouses
                .Where(it => it.user_type == UserType.访客 && it.is_del != IsDelType.是).Count();
        }

        #region 绑定工作人员数据
        /// <summary>
        /// 工作人员数据分页绑定事件
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int pagerWorker_EventPaging(EventPagingArg e)
        {
            string workerKey = tbWorkerSelect.Text.Trim();

            bool? registeState = null;
            if (radSelectAll.Checked) registeState = null;
            else if (radSelectYes.Checked) registeState = true;
            else if (radSelectNo.Checked) registeState = false;

            var result = _userBLL.GetUserByHouseCode(pagerWorker.PageIndex, pagerWorker.PageSize, _propertyHouse.building_code, workerKey, registeState);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ToAlertString());
                result.Obj = new PagerData<User>()
                {
                    pages = 0,
                    rows = new List<User>(),
                    total = 0
                };
            }
            //绑定分页控件
            pagerWorker.bsPager.DataSource = result.Obj.rows;
            pagerWorker.bnPager.BindingSource = pagerWorker.bsPager;
            //分页控件绑定DataGridView
            dgUser.DataSource = pagerWorker.bsPager;

            PageWorkerRender(result.Obj.rows);

            //返回总记录数
            return result.Obj.total;
        }
        /// <summary>
        /// 呈现工作人员人脸信息
        /// </summary>
        /// <param name="obj"></param>
        void PageWorkerRender(List<User> user_registers)
        {
            this.UIThread(() =>
            {
                FlpWorker.Controls.Clear();
                if (user_registers != null && user_registers.Any())
                {
                    foreach (User user_register in user_registers)
                    {
                        ucFamily u1 = new ucFamily(user_register.UserHouses.Where(it => it.house_code == Program._Mainform._PropertyHouseCode).FirstOrDefault());
                        u1.Width = FlpWorker.Width / 3 - 10;
                        u1.UpdateAction += new Action<ucFamily>((uc_Family) =>
                        {
                            //AddOrUpdateUserFrm form = new AddOrUpdateUserFrm(this, uc_Family);
                            //form.ShowDialog();
                        });
                        FlpWorker.Controls.Add(u1);
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
            pagerWorker.Bind();
        }

        public void BindWorkers()
        {
            pagerWorker.Bind();
        }
        #endregion


        /// <summary>
        /// 添加工作人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAddWorker_Click(object sender, EventArgs e)
        {
            string houseCode = Program._Mainform._PropertyHouseCode;
            var house = _houseBLL.FirstOrDefault(it => it.house_code == houseCode);
            if (house != null)
            {
                AddOrUpdateWorkerFrm addOrUpdateUserFrm = new AddOrUpdateWorkerFrm(this, house);
                addOrUpdateUserFrm.ShowDialog();
            }
            else
            {
                LogHelper.Fatal($"找不到虚拟楼栋下的虚拟房屋【{houseCode}】！");
            }
        }

        /// <summary>
        /// 选项卡切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (FlpWorker.Controls.Count == 0)//没有数据，可能是第一次加载
                {
                    pagerWorker.Bind();
                }
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
            if (dgUser.SelectedRows != null && dgUser.SelectedRows.Count > 0)
            {
                House house = dgUser.SelectedRows[0].DataBoundItem as House;
                AddOrUpdateUserFrm addOrUpdateUserFrm = new AddOrUpdateUserFrm(this, house);
                addOrUpdateUserFrm.ShowDialog();
                RegCount();
            }
            else
            {
                m_Tip.ShowItTop(btnNewUser, "未选定房屋！");
            }
        }
        #endregion

        void Register_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadBuilding();
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
                m_Tip.ShowIt(tbPicUrl, "请选择照片文件路径!");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(tbPicUrl.Text.Trim());
            if (dir.Exists)
            {
                FileInfo[] fiList = dir.GetFiles();
                if (fiList != null)
                {
                    if (fiList.Length > 0)
                    {
                        tbShow.Text = string.Empty;//清空
                        Thread t2 = new Thread(() =>
                        {
                            RegPicList(fiList);
                        });
                        t2.Start();
                    }
                    else
                    {
                        m_Tip.ShowIt(tbPicUrl, "请选择包含照片文件的路径!");
                    }
                }
            }

        }

        /// <summary>
        /// 批量注册人脸
        /// </summary>
        /// <param name="fiList"></param>
        void RegPicList(FileInfo[] files)
        {
            var result = _maoBLL.CheckAllMao();
            if (result.IsSuccess)
            {
                var faces = result.Obj.Where(it => it.Value.Item1 == true)
                    .Select(it => it.Value).Select(it => it.Item3).ToList();
                RegPicList(faces, files);
            }
            else
            {
                var badMaos = result.Obj.Where(it => it.Value.Item1 == false)
                    .Select(it => it.Value).Select(it => it.Item2);
                foreach (var mao in badMaos)
                {
                    ShowMessage($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！", MessageType.Error);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="faces"></param>
        /// <param name="files"></param>
        void RegPicList(List<Face.Common_.Face> faces, FileInfo[] files)
        {
            int defaultDays = Config_.GetInt("FaceEndTime") ?? 0;
            DateTime endDate = Convert.ToDateTime(DateTime.Now.AddDays(defaultDays).ToString("yyyy-MM-dd 23:59:59"));

            Face.Common_.Face face = faces[0];

            foreach (var item in files)
            {
                try
                {
                    string fileExtension = Path.GetExtension(item.FullName);
                    if (fileExtension.ToLower() != ".jpg")
                    {
                        ShowMessage("仅支持jpg格式图片", MessageType.Warning);
                        continue; ;
                    }

                    if ((new FileInfo(item.FullName)).Length > MainForm.pictureMaxSize * 1024 * 1024)
                    {
                        ShowMessage(item.FullName + "图片大小超过 " + MainForm.pictureMaxSize + " M", MessageType.Warning);
                    }

                    string fileName = Path.GetFileNameWithoutExtension(item.FullName);
                    string[] split = fileName.Split(new Char[] { '_' });
                    if (split.Length > 0)
                    {
                        string name = split[0];
                        string index = "1";
                        if (split.Length > 1) index = split[1];
                        var getWorkerResult = _userBLL.GetWorkerByName(name);
                        if (getWorkerResult.IsSuccess)
                        {
                            var worker = getWorkerResult.Obj;

                            ShowMessage("##开始注册：" + name + " " + index, MessageType.Information);

                            string faceId = Key_.SequentialGuid();

                            var result = face.Checking(faceId, RegisterType.手动注册, item.FullName);
                            if (!result.IsSuccess)
                            {
                                ShowMessage(result.ToAlertString(), MessageType.Warning);
                                continue;
                            }

                            if (!string.IsNullOrEmpty(result.Obj.face[0]?.face_id))
                            {
                                var resultMC = face.MatchCompare1(faceId, worker.UserHouses.ToList()[0].User.Registers.ToList()[0].face_id);
                                if (!resultMC.IsSuccess)
                                {
                                    ShowMessage(result.ToAlertString(), MessageType.Warning);
                                    continue;
                                }
                            }

                            string savedPictureName = _registerBLL.FileSaveAs(item.FullName, MainForm.picturePath);//保存图片到本地
                            if (string.IsNullOrEmpty(savedPictureName))
                            {
                                ShowMessage("**图片保存失败，请稍后重试", MessageType.Error);
                                continue;
                            }

                            faceId = Key_.SequentialGuid();//faceId需要重新生成

                            Register _register = new Register
                            {
                                user_uid = worker.user_uid,
                                face_id = faceId,
                                photo_path = savedPictureName,
                                register_type = RegisterType.手动注册,
                                check_state = CheckType.审核通过,
                            };
                            var registerResult = _registerBLL.Add(_register);// 注册信息保存到数据库:register
                            if (!registerResult.IsSuccess)
                            {
                                ShowMessage("**数据库异常，请稍后重试", MessageType.Error);
                                continue;
                            }
                            else
                            {
                                _register = registerResult.Obj;
                            }

                            Parallel.ForEach(faces, faceItem =>
                            {
                                if (!faceItem.Equals(face))
                                {
                                    //var thisRegisterResult = face.Register(new Face.Common_.RegisterInput
                                    //{
                                    //    activeTime = endDate,
                                    //    Birthday = worker.birthday,
                                    //    CertificateType = Face.Common_.EyeCool.CertificateType.唯一标识,
                                    //    cNO = "",
                                    //    CRMId = worker.user_uid,
                                    //    FaceId = faceId,
                                    //    Name = worker.name,
                                    //    PeopleId = worker.people_id,
                                    //    Phone = worker.mobile,
                                    //    ProjectCode = Program._Mainform._ProjectCode,
                                    //    RegisterType = RegisterType.手动注册,
                                    //    RoomNo = _propertyHouse.roomnumber,
                                    //    Sex = worker.sex,
                                    //    UserType = "物业管理"
                                    //});

                                    //if (!result.IsSuccess)
                                    //{
                                    //    ShowMessage("**" + faceItem.mao_name + "，注册失败(稍后将自动重试)：" + result.ToAlertString(), MessageType.Error);

                                    //    MaoFailedJob job = new MaoFailedJob
                                    //    {
                                    //        register_or_user_id = _register.id,
                                    //        mao_id = _mao.id,
                                    //        job_type = JobType.注册,
                                    //    };
                                    //    _maoFailedJobBLL.AddOrUpdate(job);

                                    //    continue;
                                    //}
                                    //else
                                    //{
                                    //    ShowMessage("**" + _mao.mao_name + "，注册成功", MessageType.Success);
                                    //}

                                    ////if(string.IsNullOrEmpty(user_register.face_id))
                                    ////    user_register = _registerBLL.GetUserRegisterByUid(user_register.user_uid);
                                }
                            });
                        }
                        else
                        {
                            ShowMessage(getWorkerResult.ToAlertString(), MessageType.Error);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                };
            }

            ////同步人脸数据
            //ApiGetRegisterInVO getRegIn = new ApiGetRegisterInVO();
            //getRegIn.createTime = DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-dd HH:mm:ss");
            //getRegIn.offTime = DateTime.Now.AddMinutes(3).ToString("yyyy-MM-dd HH:mm:ss");
            //getRegIn.pid = MainForm.project_code;
            //getRegIn.token = Guid.NewGuid().ToString();
            //getRegIn.pageNumber = 1;
            //getRegIn.pageSize = 50;

            //faceBLL.LoadFaceRegData(getRegIn, MainForm.PhotoPath);//3

            // 更新窗体数据
            BindWorkers();
            RegCount();

            tbPicUrl.Text = string.Empty;
        }
        #endregion
        public delegate void DGShowMsg(string x, MessageType type);
        public void ShowMessage(string message, MessageType type)
        {
            //tbShow.ForeColor = MessageColor.GetColorByMessgaeType(type);

            if (tbShow.InvokeRequired)
            {
                DGShowMsg msgDelegate = ShowMessage;
                Invoke(msgDelegate, new object[] { message, type });
            }
            else
            {
                //tbShow.AppendText(msg + "\r\n");
                tbShow.AppendText(message + "\r\n", MessageColor.GetColorByMessgaeType(type));
            }
        }

        void radSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectAll.Checked) pagerWorker.Bind();
        }

        void radSelectYes_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectYes.Checked) pagerWorker.Bind();
        }

        void radSelectNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectNo.Checked) pagerWorker.Bind();
        }


    }
}