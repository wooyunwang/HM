using HM.Common_;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Form_.Old;
using HM.Utils_;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform.Forms
{
    public partial class AddOrUpdateUserFrm : Form_.HMForm
    {
        UserBLL _userBLL = new UserBLL();
        UserHouseBLL _userHouseBLL = new UserHouseBLL();

        VankeBalloonToolTip m_Tip;
        ucRegister _ucRegister;
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
        /// <param name="user_house">关系对象必须包含user、house</param>
        public AddOrUpdateUserFrm(ucRegister uc_register, UserHouse user_house)
        {
            InitializeComponent();
            m_Tip = new VankeBalloonToolTip(this);
            _ucRegister = uc_register;
            _user_house = user_house;
            _house = user_house.House;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc_register"></param>
        /// <param name="house"></param>
        public AddOrUpdateUserFrm(ucRegister uc_register, House house)
        {
            InitializeComponent();
            m_Tip = new VankeBalloonToolTip(this);
            _ucRegister = uc_register;
            _house = house;
        }

        void AddOrUpdateUserFrm_Load(object sender, EventArgs e)
        {
            lblHouseName.Text = _house.house_name;
            BindHelper.EnumBind<SexType>(dropSex);
            BindHelper.EnumBind<UserType>(dropUserType);
            InitForm();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        void InitForm()
        {
            if (!IsAdd)
            {
                Text = "修改用户信息";
                lblHouseName.Text = _house.house_name;
                tbName.Text = _user_house.User.name;
                BindHelper.EnumSelect<SexType>(dropSex, _user_house.User.sex);
                BindHelper.EnumSelect<UserType>(dropUserType, _user_house.user_type);
                tbMoblie.Text = _user_house.User.mobile;
                tbIdNum.Text = _user_house.User.id_num;
                tbRelation.Text = _user_house.relation;
            }
            else
            {
                Text = "注册新成员";
                lblHouseName.Text = _house.house_name;
                tbName.Text = "";
                BindHelper.EnumSelect<SexType>(dropSex, null);
                BindHelper.EnumSelect<UserType>(dropUserType, null);
                tbMoblie.Text = "";
                tbIdNum.Text = "";
                tbRelation.Text = "";
            }
        }
        /// <summary>
        /// 注册新成员
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
            if (dropUserType.SelectedItem == null || dropUserType.SelectedValue == null || string.IsNullOrWhiteSpace(dropUserType.SelectedValue.ToString()))
            {
                m_Tip.ShowItTop(dropSex, "请选择用户类型");
                return;
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
                    uh.House = _house;
                    uh.User = new User()
                    {
                        name = name,
                        sex = BindHelper.EnumValue<SexType>(dropSex) ?? SexType.未知,
                        id_type = string.IsNullOrWhiteSpace(id_num) ? IdType.未知 : IdType.身份证,
                        mobile = mobile,
                        id_num = id_num,

                        #region 默认部分
                        birthday = DateTime.MinValue,
                        change_time = DateTime.Now,
                        check_by = 0,
                        check_note = "",
                        check_state = CheckType.待审核,
                        check_time = DateTime.MinValue,
                        create_time = DateTime.Now,
                        data_from = DataFromType.手动添加,
                        end_time = DateTime.MinValue,
                        id_pic = "",
                        is_del = IsDelType.否,
                        people_id = "",
                        reg_time = DateTime.Now,
                        tel = "",
                        user_uid = ""
                        #endregion
                    };

                    uh.is_del = IsDelType.否;
                    uh.house_code = _house.house_code;
                    uh.user_type = BindHelper.EnumValue<UserType>(dropUserType) ?? UserType.未知;
                    uh.relation = tbRelation.Text.Trim();
                    uh.user_uid = "";
                    var result = _userHouseBLL.Add(_user_house);
                    if (result != null)
                    {
                        _user_house = result;
                        m_Tip.ShowItTop(BtnAdd, "新增成功");
                    }
                }
                else
                {
                    uh = _userHouseBLL.FirstOrDefault(it => it.id == _user_house.id);
                    uh.User.name = name;
                    uh.User.sex = BindHelper.EnumValue<SexType>(dropSex) ?? SexType.未知;
                    uh.User.id_type = string.IsNullOrWhiteSpace(id_num) ? IdType.未知 : IdType.身份证;
                    uh.User.mobile = mobile;
                    uh.User.id_num = id_num;
                    uh.house_code = _house.house_code;
                    uh.user_type = BindHelper.EnumValue<UserType>(dropUserType) ?? UserType.未知;
                    uh.relation = tbRelation.Text.Trim();
                    bool result = _userHouseBLL.Edit(_user_house);
                    if (result)
                    {
                        m_Tip.ShowItTop(BtnAdd, "修改成功");
                    }
                }

                Task.Run(() =>
                {
                    _ucRegister.BindHouseUser(_house.house_code);
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
