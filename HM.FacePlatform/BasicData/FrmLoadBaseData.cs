using HM.Common_;
using HM.FacePlatform.BLL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HM.FacePlatform.Model;
using HM.Utils_;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.Form_;

namespace HM.FacePlatform.BasicData
{
    public partial class FrmLoadBaseData : Form
    {
        private BaseDataTypeE baseDataType;
        private UcDataBase _ucDataBase;

        Regex regex = new Regex("^" + Program._Mainform._ProjectCode + ".*");

        BuildingBLL _buildingBLL = new BuildingBLL();
        HouseBLL _houseBLL = new HouseBLL();
        UserBLL _userBLL = new UserBLL();

        public FrmLoadBaseData(BaseDataTypeE baseDataTypeVar, UcDataBase ucDataBase)
        {
            baseDataType = baseDataTypeVar;
            _ucDataBase = ucDataBase;

            InitializeComponent();
        }

        private void FrmLoadBaseData_Load(object sender, EventArgs e)
        {
            if (baseDataType == BaseDataTypeE.楼栋信息)
            {
                lbtnLoadTempt.Text = "点击下载楼栋信息导入模板";
                this.Text = "导入楼栋信息";
            }
            else if (baseDataType == BaseDataTypeE.房屋信息)
            {
                lbtnLoadTempt.Text = "点击下载房屋信息导入模板";
                this.Text = "导入房屋信息";
            }
            else
            {
                lbtnLoadTempt.Text = "点击下载用户信息导入模板";
                this.Text = "导入用户信息";
            }
            //tbShow.Text = "aa\r\n\nbb";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }

        #region 下载导入的模板
        private void lbtnLoadTempt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string firstName = "导入楼栋信息的模板";
            string urlStr = Application.StartupPath + @"\PrintTemp\导入楼栋信息的模板.xls";

            if (baseDataType == BaseDataTypeE.楼栋信息)
            {
                firstName = "导入楼栋信息的模板";
                urlStr = Application.StartupPath + @"\PrintTemp\导入楼栋信息的模板.xls";
            }
            else if (baseDataType == BaseDataTypeE.房屋信息)
            {
                firstName = "导入房屋信息的模板";
                urlStr = Application.StartupPath + @"\PrintTemp\导入房屋信息的模板.xls";
            }
            else
            {
                firstName = "导入用户信息的模板";
                urlStr = Application.StartupPath + @"\PrintTemp\导入用户信息的模板.xls";
            }

            string lastName = "xls";
            string dirStr = "";
            saveFileDialog1.FileName = firstName;
            saveFileDialog1.DefaultExt = lastName;
            saveFileDialog1.Filter = lastName + "(*." + lastName + ")|*." + lastName + "|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dirStr = saveFileDialog1.FileName;
                System.Net.WebClient client = new System.Net.WebClient();
                try
                {
                    System.Net.WebRequest myre = System.Net.WebRequest.Create(urlStr);
                }
                catch (Exception exp)
                {
                    HMMessageBox.Show(this, exp.Message, "Error");
                    return;
                }

                try
                {
                    client.DownloadFile(urlStr, dirStr);

                }
                catch (System.Net.WebException exp)
                {
                    HMMessageBox.Show(this, "请关闭当前打开的此文档!" + exp.Message);
                    return;
                }
                catch (Exception exp)
                {
                    HMMessageBox.Show(this, exp.Message, "Error");
                    return;
                }

                DialogResult result;
                result = HMMessageBox.Show(this, "下载完成\n请确认是否现在打开此文件?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        if (System.IO.File.Exists(dirStr)) System.Diagnostics.Process.Start(dirStr); //打开EXCEL
                    }
                    catch
                    {
                        HMMessageBox.Show(this, "不能直接打开此文件,但已保存至本地目录!");
                    }
                }
            }
        }
        #endregion

        #region 选择导入的文件
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.ExecutablePath;
            openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            //图像文件(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf|所有文件(*.*)|*.*
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPicUrl.Text = openFileDialog1.FileName;
            }
        }
        #endregion

        #region 开始导入

        private void btnStarLoad_Click(object sender, EventArgs e)
        {
            if (this.tbPicUrl.Text.Trim() != String.Empty)
            {
                tbShow.Text = string.Empty;//清空

                if (baseDataType == BaseDataTypeE.楼栋信息)
                {
                    Thread td = new Thread(new ParameterizedThreadStart(ImportBuilding));
                    td.Start(this.tbPicUrl.Text.Trim());
                }
                else if (baseDataType == BaseDataTypeE.房屋信息)
                {
                    Thread td = new Thread(new ParameterizedThreadStart(ImportHouse));
                    td.Start(this.tbPicUrl.Text.Trim());
                }
                else
                {
                    Thread td = new Thread(new ParameterizedThreadStart(ImportUser));
                    td.Start(this.tbPicUrl.Text.Trim());
                }
            }
            else
            {
                ShowMessage("请选择要导入的文件", MessageType.Warning); return;
            }
        }

        private void ImportBuilding(object obj)
        {
            string filename = obj as string;
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook book = new HSSFWorkbook(fs);
                    {
                        string strError = "";
                        int loadCount = 0;
                        string building_code;
                        string building_name;

                        //for (int j = 0; j < book.NumberOfSheets; j++)
                        //{
                        //ISheet sheet = book.GetSheetAt(j);
                        ISheet sheet = book.GetSheetAt(0);

                        loadCount = sheet.PhysicalNumberOfRows;
                        this.UIThread(() =>
                        {
                            progressBar1.Maximum = loadCount;
                            progressBar1.Value = 0;
                            progressBar1.Visible = true;

                            btnStarLoad.Enabled = false;
                        });

                        #region check
                        IRow row1 = sheet.GetRow(0);
                        string t1 = ExcelHelper.ReadStringCell(0, row1);
                        if (t1 != "楼栋编码")
                        {
                            strError = strError + "表格头不正确" + "\r\n";
                        }

                        string t2 = ExcelHelper.ReadStringCell(1, row1);
                        if (t2 != "楼栋名称")
                        {
                            strError = strError + "表格头不正确" + "\r\n";
                        }

                        int checkIndex = 1;
                        for (int i = 1; i < loadCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            building_code = ExcelHelper.ReadStringCell(0, row).Trim();
                            building_name = ExcelHelper.ReadStringCell(1, row).Trim();

                            checkIndex++;

                            if (ExcelHelper.ReadStringCell(0, row).Trim() == "" && ExcelHelper.ReadStringCell(1, row).Trim() == "")
                            {
                                continue;
                            }

                            if (building_code == "")
                            {
                                strError = strError + "第" + checkIndex + "行 楼栋编码不能为空" + "\r\n";
                            }

                            if (building_name == "")
                            {
                                strError = strError + "第" + checkIndex + "行 楼栋名称不能为空" + "\r\n";
                            }

                            // 验证楼栋编码以项目编码开头
                            if (!regex.IsMatch(building_code))
                            {
                                strError = strError + "第" + checkIndex + "行 楼栋编码必须以项目编码:" + Program._Mainform._ProjectCode + "开头" + "\r\n";
                            }
                            if (building_code.Length > 50)
                            {
                                strError = strError + "第" + checkIndex + "行 楼栋编码为:" + building_code + "的长度不要超过50" + "\r\n";
                            }
                            if (building_name.Length > 100)
                            {
                                strError = strError + "第" + checkIndex + "行 楼栋名称为:" + building_name + "的长度不要超过100" + "\r\n";
                            }

                            if (_buildingBLL.Any(it => it.building_code == building_code))
                            {
                                strError = strError + "第" + checkIndex + "行 已存在楼栋编码为:" + building_code + "的楼栋信息" + "\r\n";
                            }

                            if (_buildingBLL.Any(it => it.building_name == building_name))
                            {
                                strError = strError + "第" + checkIndex + "行 已存在楼栋名称为:" + building_name + "的楼栋信息" + "\r\n";
                            }

                        }

                        if (strError != "")
                        {
                            if (strError.Length < 300)
                            {
                                ShowMessage(strError, MessageType.Warning);
                            }
                            else
                            {
                                HMMessageBox.Show(this, strError.Substring(0, 280));
                            }

                            this.UIThread(() =>
                            {
                                btnStarLoad.Enabled = true;
                                progressBar1.Visible = false;
                            });
                            return;
                        }
                        #endregion


                        int ok = 0;
                        for (int i = 1; i < loadCount; i++)
                        {
                            try
                            {
                                this.UIThread(() =>
                                {
                                    progressBar1.Value++;
                                });

                                IRow row = sheet.GetRow(i);

                                if (ExcelHelper.ReadStringCell(0, row).Trim() == "" && ExcelHelper.ReadStringCell(1, row).Trim() == "")
                                {
                                    continue;
                                }

                                Building _building = new Building();
                                _building.building_code = ExcelHelper.ReadStringCell(0, row).Trim();
                                _building.building_name = ExcelHelper.ReadStringCell(1, row).Trim();
                                _building.project_code = Program._Mainform._ProjectCode;

                                if (_buildingBLL.Any(it => it.building_code == _building.building_code))
                                {
                                    ShowMessage("第" + i + "行 已存在楼栋编码为:" + _building.building_code + "的楼栋信息", MessageType.Warning);
                                    continue;
                                }

                                if (_buildingBLL.Any(it => it.building_name == _building.building_name))
                                {
                                    ShowMessage("第" + i + "行 已存在楼栋名称为:" + _building.building_name + "的楼栋信息", MessageType.Warning);
                                    continue;
                                }

                                _buildingBLL.Add(_building);

                                ShowMessage("导入" + _building.building_name + "成功... ", MessageType.Success);
                                ok++;
                            }
                            catch (Exception ex)
                            {
                                //LoggingService.Debug(ex.Message);
                                ShowMessage(ex.Message, MessageType.Error);
                            }
                        }

                        ShowMessage("导入完毕，共导入" + ok.ToString() + "条楼栋数据", MessageType.Information);

                        this.UIThread(() =>
                        {
                            btnStarLoad.Enabled = true;
                            progressBar1.Visible = false;
                            _ucDataBase.LoadBuilding();
                        });
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void ImportHouse(object obj)
        {
            string filename = obj as string;
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook book = new HSSFWorkbook(fs);
                    {
                        string strError = "";
                        int loadCount = 0;
                        string house_code;
                        string house_name;
                        string unit;
                        string floor;
                        string roomnumber;
                        string building_code;

                        //for (int j = 0; j < book.NumberOfSheets; j++)
                        //{
                        //ISheet sheet = book.GetSheetAt(j);
                        ISheet sheet = book.GetSheetAt(0);

                        loadCount = sheet.PhysicalNumberOfRows;
                        this.UIThread(() =>
                        {
                            progressBar1.Maximum = loadCount;
                            progressBar1.Value = 0;
                            progressBar1.Visible = true;

                            btnStarLoad.Enabled = false;
                        });

                        #region check
                        IRow row1 = sheet.GetRow(0);

                        if (ExcelHelper.ReadStringCell(0, row1) != "房屋编码")
                        {
                            strError = strError + "表头第1个单元格必须为房屋编码" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(1, row1) != "房屋名称")
                        {
                            strError = strError + "表头第2个单元格必须为房屋名称" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(2, row1) != "单元")
                        {
                            strError = strError + "表头第3个单元格必须为单元" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(3, row1) != "楼层")
                        {
                            strError = strError + "表头第4个单元格必须为楼层" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(4, row1) != "房号")
                        {
                            strError = strError + "表头第5个单元格必须为房号" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(5, row1) != "所属楼栋编码")
                        {
                            strError = strError + "表头第6个单元格必须为所属楼栋编码" + "\r\n";
                        }

                        int checkIndex = 1;
                        for (int i = 1; i < loadCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            house_code = ExcelHelper.ReadStringCell(0, row).Trim();
                            house_name = ExcelHelper.ReadStringCell(1, row).Trim();
                            unit = ExcelHelper.ReadStringCell(2, row).Trim();
                            floor = ExcelHelper.ReadStringCell(3, row).Trim();
                            roomnumber = ExcelHelper.ReadStringCell(4, row).Trim();
                            building_code = ExcelHelper.ReadStringCell(5, row).Trim();

                            checkIndex++;

                            if (ExcelHelper.ReadStringCell(0, row).Trim() == "" && ExcelHelper.ReadStringCell(1, row).Trim() == "" && ExcelHelper.ReadStringCell(2, row).Trim() == "" && ExcelHelper.ReadStringCell(3, row).Trim() == "" && ExcelHelper.ReadStringCell(4, row).Trim() == "" && ExcelHelper.ReadStringCell(5, row).Trim() == "")
                            {
                                continue;
                            }

                            if (house_code == "")
                            {
                                strError = strError + "第" + checkIndex + "行 房屋编码不能为空" + "\r\n";
                            }
                            if (house_name == "")
                            {
                                strError = strError + "第" + checkIndex + "行 房屋名称不能为空" + "\r\n";
                            }
                            if (building_code == "")
                            {
                                strError = strError + "第" + checkIndex + "行 所属楼栋编码不能为空" + "\r\n";
                            }

                            //验证房屋编码以项目编码开头                        
                            if (!regex.IsMatch(house_code))
                            {
                                strError = strError + "第" + checkIndex + "行 房屋编码必须以项目编码:" + Program._Mainform._ProjectCode + "开头" + "\r\n";
                            }

                            if (house_code.Length > 50)
                            {
                                strError = strError + "第" + checkIndex + "行 房屋编码为:" + house_code + "的长度不要超过50" + "\r\n";
                            }
                            if (house_name.Length > 50)
                            {
                                strError = strError + "第" + checkIndex + "行 房屋名称为:" + house_name + "的长度不要超过50" + "\r\n";
                            }
                            if (unit.Length > 10)
                            {
                                strError = strError + "第" + checkIndex + "行 单元为:" + unit + "的长度不要超过10" + "\r\n";
                            }
                            if (floor.Length > 20)
                            {
                                strError = strError + "第" + checkIndex + "行 楼层为:" + floor + "的长度不要超过20" + "\r\n";
                            }
                            if (roomnumber.Length > 20)
                            {
                                strError = strError + "第" + checkIndex + "行 房号为:" + roomnumber + "的长度不要超过20" + "\r\n";
                            }
                            if (building_code.Length > 50)
                            {
                                strError = strError + "第" + checkIndex + "行 所属楼栋编码为:" + building_code + "的长度不要超过50" + "\r\n";
                            }

                            if (_houseBLL.Any(it => it.house_code == house_code))
                            {
                                strError = strError + "第" + checkIndex + "行 已存在房屋编码为:" + house_code + "的房屋信息" + "\r\n";
                            }

                            if (_houseBLL.Any(it => it.house_name == house_name))
                            {
                                strError = strError + "第" + checkIndex + "行 已存在房屋名称为:" + house_name + "的房屋信息" + "\r\n";
                            }
                        }

                        if (strError != "")
                        {
                            if (strError.Length < 600)
                            {
                                ShowMessage(strError, MessageType.Warning);
                            }
                            else
                            {
                                HMMessageBox.Show(this, strError.Substring(0, 598));
                            }

                            this.UIThread(() =>
                            {
                                btnStarLoad.Enabled = true;
                                progressBar1.Visible = false;
                            });
                            return;
                        }
                        #endregion


                        int ok = 0;
                        for (int i = 1; i < loadCount; i++)
                        {
                            try
                            {
                                this.UIThread(() =>
                                {
                                    progressBar1.Value++;
                                });

                                IRow row = sheet.GetRow(i);

                                if (ExcelHelper.ReadStringCell(0, row).Trim() == "" && ExcelHelper.ReadStringCell(1, row).Trim() == "" && ExcelHelper.ReadStringCell(2, row).Trim() == "" && ExcelHelper.ReadStringCell(3, row).Trim() == "" && ExcelHelper.ReadStringCell(4, row).Trim() == "" && ExcelHelper.ReadStringCell(5, row).Trim() == "")
                                {
                                    continue;
                                }

                                House _house = new House();
                                _house.house_code = ExcelHelper.ReadStringCell(0, row).Trim();
                                _house.house_name = ExcelHelper.ReadStringCell(1, row).Trim();
                                _house.unit = ExcelHelper.ReadStringCell(2, row).Trim();
                                _house.floor = ExcelHelper.ReadStringCell(3, row).Trim();
                                _house.roomnumber = ExcelHelper.ReadStringCell(4, row).Trim();
                                _house.building_code = ExcelHelper.ReadStringCell(5, row).Trim();


                                if (_houseBLL.Any(it => it.building_code == _house.house_code))
                                {
                                    ShowMessage("第" + i + "行 已存在房屋编码为:" + _house.house_code + "的房屋信息", MessageType.Warning);
                                    continue;
                                }

                                if (_houseBLL.Any(it => it.house_name == _house.house_name))
                                {
                                    ShowMessage("第" + i + "行 已存在房屋名称为:" + _house.house_name + "的房屋信息", MessageType.Warning);
                                    continue;
                                }

                                _houseBLL.Add(_house);

                                ShowMessage("导入" + _house.house_name + "成功... ", MessageType.Success);
                                ok++;
                            }
                            catch (Exception ex)
                            {
                                //LoggingService.Debug(ex.Message);
                                ShowMessage(ex.Message, MessageType.Error);
                            }
                        }

                        ShowMessage("导入完毕，共导入" + ok + "条房屋数据", MessageType.Information);

                        this.UIThread(() =>
                        {
                            btnStarLoad.Enabled = true;
                            progressBar1.Visible = false;
                            _ucDataBase.LoadHouse();
                        });
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }

        private void ImportUser(object obj)
        {
            string filename = obj as string;
            string[] user_types = new string[] { "拥有", "居住", "家庭成员", "访客", "工作人员" };

            House propertyHouse = _houseBLL.FirstOrDefault(it => it.house_code == Program._Mainform._PropertyHouseCode);
            if (string.IsNullOrEmpty(propertyHouse.house_code))
            {
                ShowMessage("数据库未初始化", MessageType.Error);
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook book = new HSSFWorkbook(fs);
                    {
                        string strError = "";
                        int loadCount = 0;

                        string name;
                        string sex;
                        string user_type;
                        string id_num;
                        string mobile;
                        string job;
                        string house_code;

                        ISheet sheet = book.GetSheetAt(0);

                        loadCount = sheet.PhysicalNumberOfRows;
                        this.UIThread(() =>
                        {
                            progressBar1.Maximum = loadCount;
                            progressBar1.Value = 0;
                            progressBar1.Visible = true;

                            btnStarLoad.Enabled = false;
                        });

                        #region check
                        IRow row1 = sheet.GetRow(0);

                        if (ExcelHelper.ReadStringCell(0, row1) != "姓名")
                        {
                            strError = strError + "表头第1个单元格必须为姓名" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(1, row1) != "性别")
                        {
                            strError = strError + "表头第2个单元格必须为性别" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(2, row1) != "用户类型")
                        {
                            strError = strError + "表头第3个单元格必须为用户类型" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(3, row1) != "身份证号")
                        {
                            strError = strError + "表头第4个单元格必须为身份证号" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(4, row1) != "手机号")
                        {
                            strError = strError + "表头第5个单元格必须为手机号" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(5, row1) != "职位")
                        {
                            strError = strError + "表头第6个单元格必须为职位" + "\r\n";
                        }

                        if (ExcelHelper.ReadStringCell(6, row1) != "所属房屋编码")
                        {
                            strError = strError + "表头第7个单元格必须为所属房屋编码" + "\r\n";
                        }

                        int checkIndex = 1;
                        for (int i = 1; i < loadCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            name = ExcelHelper.ReadStringCell(0, row).Trim();
                            sex = ExcelHelper.ReadStringCell(1, row).Trim();
                            user_type = ExcelHelper.ReadStringCell(2, row).Trim();
                            id_num = ExcelHelper.ReadStringCell(3, row).Trim();
                            mobile = ExcelHelper.ReadStringCell(4, row).Trim();
                            job = ExcelHelper.ReadStringCell(5, row).Trim();
                            house_code = ExcelHelper.ReadStringCell(6, row).Trim();

                            checkIndex++;

                            if (ExcelHelper.ReadStringCell(0, row).Trim() == "" && ExcelHelper.ReadStringCell(1, row).Trim() == ""
                                && ExcelHelper.ReadStringCell(2, row).Trim() == "" && ExcelHelper.ReadStringCell(3, row).Trim() == ""
                                && ExcelHelper.ReadStringCell(4, row).Trim() == "" && ExcelHelper.ReadStringCell(5, row).Trim() == ""
                                && ExcelHelper.ReadStringCell(6, row).Trim() == "")
                            {
                                continue;
                            }

                            if (name == "")
                            {
                                strError = strError + "第" + checkIndex + "行 姓名不能为空" + "\r\n";
                            }
                            if (name.Length > 20)
                            {
                                strError = strError + "第" + checkIndex + "行 姓名长度不要超过20" + "\r\n";
                            }
                            if (sex == "")
                            {
                                strError = strError + "第" + checkIndex + "行 性别不能为空" + "\r\n";
                            }
                            if (user_type == "")
                            {
                                strError = strError + "第" + checkIndex + "行 用户类型不能为空" + "\r\n";
                            }
                            if (house_code == "" && user_type != "工作人员")
                            {
                                strError = strError + "第" + checkIndex + "行 所属房屋编码不能为空" + "\r\n";
                            }

                            if (sex != "男" && sex != "女")
                            {
                                strError = strError + "第" + checkIndex + "行 性别必须为 男 或 女" + "\r\n";
                            }
                            if (!user_types.Contains(user_type))
                            {
                                strError = strError + "第" + checkIndex + "行 用户类型不正确" + "\r\n";
                            }
                            if (mobile != string.Empty)
                            {
                                //^1[3|4|5|7|8]\d{9}$
                                if (!Regex.IsMatch(mobile, @"^1[0|1|2|3|4|5|6|7|8|9]\d{9}$", RegexOptions.IgnoreCase))
                                {
                                    strError = strError + "第" + checkIndex + "行姓名为:" + name + "手机号格式不正确" + "\r\n";
                                }
                                else
                                {
                                    User _user = _userBLL.FirstOrDefault(it => it.mobile == mobile && it.is_del != IsDelType.是);
                                    if (_user != null)
                                    {
                                        strError = strError + "第" + checkIndex + "行的手机号" + mobile + "已被" + _user.name + "占用\r\n";
                                    }
                                }
                            }

                            if (id_num != string.Empty)
                            {
                                if (!Validate_.IsIDCard(id_num))
                                {
                                    strError = strError + "第" + checkIndex + "行姓名为:" + name + "身份证号格式不正确" + "\r\n";
                                }
                                else
                                {// 身份证唯一性检测
                                    User _user = _userBLL.FirstOrDefault(it => it.id_num == id_num && it.is_del != IsDelType.是);
                                    if (_user != null)
                                    {
                                        strError = strError + "第" + checkIndex + "行的身份证号" + _user.id_num + "," + _user.name + "已存在\r\n";
                                    }
                                }
                            }

                            if (user_type != "工作人员" && !_houseBLL.Any(it => it.house_code == house_code))
                            {
                                strError = strError + "第" + checkIndex.ToString() + "行 房屋编码:" + house_code + " 不存在" + "\r\n";
                            }

                        }

                        if (strError != "")
                        {
                            if (strError.Length < 300)
                            {
                                ShowMessage(strError, MessageType.Warning);
                            }
                            else
                            {
                                HMMessageBox.Show(this, strError.Substring(0, 290));
                            }

                            this.UIThread(() =>
                            {
                                btnStarLoad.Enabled = true;
                                progressBar1.Visible = false;
                            });
                            return;
                        }
                        #endregion


                        int ok = 0;
                        for (int i = 1; i < loadCount; i++)
                        {
                            try
                            {
                                this.UIThread(() =>
                                {
                                    progressBar1.Value++;
                                });

                                IRow row = sheet.GetRow(i);

                                if (ExcelHelper.ReadStringCell(0, row).Trim() == "" && ExcelHelper.ReadStringCell(1, row).Trim() == "" && ExcelHelper.ReadStringCell(2, row).Trim() == "" && ExcelHelper.ReadStringCell(3, row).Trim() == "" && ExcelHelper.ReadStringCell(4, row).Trim() == "" && ExcelHelper.ReadStringCell(5, row).Trim() == "")
                                {
                                    continue;
                                }

                                User _user = new User();
                                _user.name = ExcelHelper.ReadStringCell(0, row).Trim();
                                _user.sex = ExcelHelper.ReadStringCell(1, row).Trim() == "男" ? SexType.男 : SexType.女;
                                _user.id_num = ExcelHelper.ReadStringCell(3, row).Trim();
                                _user.mobile = ExcelHelper.ReadStringCell(4, row).Trim();
                                //_user.job = ExcelHelper.ReadStringCell(5, row).Trim(); //wait 怎么处理工作人员？
                                _user.data_from = DataFromType.导入;

                                UserHouse _user_house = new UserHouse();
                                _user_house.user_uid = _user.user_uid;
                                _user_house.house_code = ExcelHelper.ReadStringCell(6, row).Trim();

                                switch (ExcelHelper.ReadStringCell(2, row).Trim())
                                {
                                    case "拥有": _user_house.user_type = UserType.业主_拥有; break;
                                    case "居住": _user_house.user_type = UserType.业主_居住; break;
                                    case "家庭成员": _user_house.user_type = UserType.家庭成员; break;
                                    case "访客": _user_house.user_type = UserType.访客; break;
                                    case "工作人员": _user_house.user_type = UserType.工作人员; break;
                                }
                                if (_user_house.user_type == UserType.工作人员)
                                {
                                    _user_house.house_code = propertyHouse.house_code;
                                }

                                if (!string.IsNullOrEmpty(_user.mobile))
                                {
                                    User temp_user = _userBLL.FirstOrDefault(it => it.mobile == _user.mobile && it.is_del != IsDelType.是);
                                    if (temp_user != null)
                                    {
                                        ShowMessage("第" + i + "行的手机号" + temp_user.mobile + "已被" + temp_user.name + "占用", MessageType.Warning);
                                        continue;
                                    }
                                }
                                if (!string.IsNullOrEmpty(_user.id_num))
                                {
                                    User temp_user = _userBLL.FirstOrDefault(it => it.id_num == _user.id_num && it.is_del != IsDelType.是);
                                    if (temp_user != null)
                                    {
                                        ShowMessage("第" + i + "行的身份证号" + temp_user.id_num + "," + temp_user.name + "已存在", MessageType.Warning);
                                        continue;
                                    }
                                }

                                //wait
                                //if (_userBLL.Add(_user, _user_house, Program._Account.id, "批量导入"))
                                //{
                                //    ShowMessage("导入" + _user.name + "成功... ", MessageType.Success);
                                //}
                                //else
                                //{
                                //    ShowMessage("导入" + _user.name + "失败(数据库异常)", MessageType.Error);
                                //}

                                ok++;
                            }
                            catch (Exception ex)
                            {
                                //LoggingService.Debug(ex.Message);
                                ShowMessage(ex.Message, MessageType.Error);
                            }
                        }

                        ShowMessage("导入完毕，共导入" + ok + "条用户数据", MessageType.Information);

                        this.UIThread(() =>
                        {
                            btnStarLoad.Enabled = true;
                            progressBar1.Visible = false;
                            _ucDataBase.BindUserData();
                        });
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
        }
        #endregion

        #region 向页面显示信息
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
                tbShow.AppendText(message + "\r\n", MessageColor.GetColorByMessgaeType(type));
            }
        }
        #endregion

    }
}
