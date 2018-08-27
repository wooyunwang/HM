using HM.Common_;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Form_;
using HM.Form_.Old;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform.Forms
{
    public partial class AddOrUpdateWorkerFrm : Form_.HMForm
    {
        UserBLL _userBLL = new UserBLL();
        UserHouseBLL _userHouseBLL = new UserHouseBLL();

        VankeBalloonToolTip m_Tip;
        UcRegister _ucRegister;
        UserHouse _user_house;
        House _house;
        /// <summary>
        /// 是否新增
        /// </summary>
        bool IsAdd { get { return _user_house == null; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc_register"></param>
        /// <param name="userHouse">关系对象必须包含user、house</param>
        public AddOrUpdateWorkerFrm(UcRegister uc_register, UserHouse userHouse)
        {
            InitializeComponent();
            m_Tip = new VankeBalloonToolTip(this);
            _ucRegister = uc_register;
            _user_house = userHouse;
            _house = userHouse.House;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc_register"></param>
        /// <param name="house"></param>
        public AddOrUpdateWorkerFrm(UcRegister uc_register, House house)
        {
            InitializeComponent();
            m_Tip = new VankeBalloonToolTip(this);
            _ucRegister = uc_register;
            _house = house;
        }

        void AddOrUpdateWorkerFrm_Load(object sender, EventArgs e)
        {
            lblHouseName.Text = _house.house_name;
            BindHelper.EnumBind<SexType>(dropSex);
            InitForm();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        void InitForm()
        {
            if (!IsAdd)
            {
                Text = "修改工作人员信息";
                lblHouseName.Text = _house.house_name;
                tbName.Text = _user_house.User.name;
                BindHelper.EnumSelect<SexType>(dropSex, _user_house.User.sex);
                tbMoblie.Text = _user_house.User.mobile;
                tbIdNum.Text = _user_house.User.id_num;
                tbJob.Text = _user_house.User.job;
            }
            else
            {
                Text = "注册新成员";
                lblHouseName.Text = _house.house_name;
                tbName.Text = "";
                BindHelper.EnumSelect<SexType>(dropSex, null);
                tbMoblie.Text = "";
                tbIdNum.Text = "";
                tbJob.Text = "";
            }
        }
        /// <summary>
        /// 注册新工作人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnAdd_Click(object sender, EventArgs e)
        {
            #region 检查
            string name = tbName.Text.Trim();
            if (name == string.Empty)
            {
                m_Tip.ShowItTop(tbName, "请输入姓名");
                return;
            }
            if (dropSex.SelectedItem == null || dropSex.SelectedValue == null || string.IsNullOrWhiteSpace(dropSex.SelectedValue.ToString()))
            {
                m_Tip.ShowItTop(dropSex, "请选择性别");
                return;
            }
            string mobile = tbMoblie.Text.Trim();
            if (string.IsNullOrEmpty(mobile))
            {
                m_Tip.ShowItTop(tbMoblie, "请输入手机号");
                return;
            }
            else if (!Validate_.IsMobile(mobile))
            {
                m_Tip.ShowItTop(tbMoblie, "请输入正确的手机号");
                return;
            }
            else
            {
                if (IsAdd)
                {
                    if (_userBLL.Any(it => it.mobile == mobile))
                    {
                        m_Tip.ShowItTop(tbMoblie, "此手机号已被占用");
                        return;
                    }
                }
                else
                {
                    if (_userBLL.Any(it => it.mobile == mobile && it.id != _user_house.User.id))
                    {
                        m_Tip.ShowItTop(tbMoblie, "此手机号已被占用");
                        return;
                    }
                }
            }
            string id_num = tbIdNum.Text.Trim();
            if (!string.IsNullOrEmpty(id_num))
            {
                if (!Validate_.IsIDCard(id_num))
                {
                    m_Tip.ShowItTop(tbIdNum, "请输入正确的身份证号码");
                    return;
                }
                else
                {
                    if (IsAdd)
                    {
                        if (_userBLL.Any(it => it.id_num == id_num))
                        {
                            m_Tip.ShowItTop(tbIdNum, "此身份证号码已经存在");
                            return;
                        }
                    }
                    else
                    {
                        if (_userBLL.Any(it => it.id_num == id_num && it.id != _user_house.id))
                        {
                            m_Tip.ShowItTop(tbIdNum, "此身份证号码已经存在");
                            return;
                        }
                    }
                }
            }
            #endregion
            try
            {
                BtnAdd.Enabled = false;
                UserHouse uh = new UserHouse();
                if (IsAdd)
                {
                    var user_uid = Key_.SequentialGuid();

                    User user = new User()
                    {
                        name = name,
                        sex = BindHelper.EnumValue<SexType>(dropSex) ?? SexType.未知,
                        id_type = string.IsNullOrWhiteSpace(id_num) ? IdType.未知 : IdType.身份证,
                        mobile = mobile,
                        id_num = id_num,
                        job = tbJob.Text.Trim(),
                        user_uid = user_uid,
                        people_id = user_uid,
                        check_note = "",

                        #region 默认部分
                        birthday = DateTime.MinValue,
                        change_time = DateTime.Now,
                        check_by = 0,
                        check_state = CheckType.审核不通过,
                        check_time = DateTime.MinValue,
                        create_time = DateTime.Now,
                        data_from = DataFromType.手动添加,
                        end_time = DateTime.MinValue,
                        id_pic = "",
                        is_del = IsDelType.否,
                        job_number = "",
                        reg_time = DateTime.Now,
                        tel = "",
                        #endregion
                    };

                    uh.is_del = IsDelType.否;
                    uh.house_code = _house.house_code;
                    uh.user_type = UserType.工作人员;
                    uh.relation = "工作人员";
                    uh.user_uid = "user_uid";
                    user.user_houses = new List<UserHouse>();
                    user.user_houses.Add(uh);
                    var addUserResult = _userBLL.Add(user);
                    if (addUserResult.IsSuccess)
                    {
                        HMMessageBox.Show(this, "新增成功");
                        DialogResult = DialogResult.OK;
                        Task.Run(() =>
                        {
                            _ucRegister.BindHouseUser(_house.house_code);
                        });
                    }
                    else
                    {
                        m_Tip.ShowItTop(BtnAdd, addUserResult.ToAlertString());
                    }
                }
                else
                {
                    uh = _userHouseBLL.GetUserHouseWithUser(_user_house.id);
                    uh.User.name = name;
                    uh.User.sex = BindHelper.EnumValue<SexType>(dropSex) ?? SexType.未知;
                    uh.User.id_type = string.IsNullOrWhiteSpace(id_num) ? IdType.未知 : IdType.身份证;
                    uh.User.mobile = mobile;
                    uh.User.id_num = id_num;
                    uh.house_code = _house.house_code;
                    uh.user_type = UserType.工作人员;
                    uh.relation = "工作人员";
                    var editResult = _userHouseBLL.EditWithUser(uh);
                    if (editResult.IsSuccess)
                    {
                        HMMessageBox.Show(this, "修改成功");
                        DialogResult = DialogResult.OK;
                        Task.Run(() =>
                        {
                            _ucRegister.BindHouseUser(_house.house_code);
                        });
                    }
                    else
                    {
                        m_Tip.ShowItTop(BtnAdd, editResult.ToAlertString());
                    }
                }

                Task.Run(() =>
                {
                    _ucRegister.BindWorkers();
                });
            }
            catch (Exception ex)
            {
                string msg = Exception_.GetInnerException(ex).Message;
                m_Tip.ShowItTop(BtnAdd, msg);
                LogHelper.Error(msg);
            }
            finally
            {
                BtnAdd.Enabled = true;
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        void tbName_TextChanged(object sender, EventArgs e)
        {
            tbName.Text = Validate_.GetSafeString(ControlType.姓名类, tbName.Text);
        }

    }
}
