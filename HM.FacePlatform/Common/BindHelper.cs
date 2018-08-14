using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Utils_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    public class SimpleCategory<T>
    {
        public T Value { get; set; }
        public string Name { get; set; }
    }
    public class BindHelper
    {
        #region 枚举
        /// <summary>
        /// 枚举的绑定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <param name="isAll"></param>
        public static void EnumBind<T>(ComboBox cb, bool isHasAll = true, T? selectValue = null) where T : struct
        {
            var lst = EnumHelper.EnumToBind<T>(isHasAll);
            cb.DataSource = lst;
            cb.DisplayMember = "Name";
            cb.ValueMember = "Value";
            if (selectValue != null)
            {
                cb.SelectedItem = lst.Where(it => it.Value.Equals(selectValue)).FirstOrDefault();
            }
        }
        /// <summary>
        /// 选定的枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static T? EnumValue<T>(ComboBox cb)
            where T : struct
        {
            if (cb.SelectedItem == null || cb.SelectedValue == null)
            {
                return null;
            }
            else
            {
                return (cb.SelectedItem as EnumKeyValue<T?>).Value;
            }
        }


        public static void EnumSelect<T>(ComboBox cb, T? value)
            where T : struct
        {
            var data = (cb.DataSource as List<EnumKeyValue<T?>>);
            if (data != null)
            {
                cb.SelectedItem = data.Where(it => it.Value.Equals(value)).FirstOrDefault();
            }
        }
        #endregion

        #region 系统用户
        /// <summary>
        /// 系统用户的绑定
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="id"></param>
        public static void SystemUserBind(ComboBox cb, int? id = null)
        {
            var lst = FacePlatformCache.GetALL<SystemUser>().Select(it => new EnumKeyValue<int?>()
            {
                Name = it.user_name,
                Value = it.id
            }).ToList();
            lst.Insert(0, new EnumKeyValue<int?>() { Name = "全部", Value = null });
            cb.DataSource = lst;
            cb.DisplayMember = "Name";
            cb.ValueMember = "Value";

            if (id.HasValue)
            {
                cb.SelectedItem = lst.Where(it => it.Value.Equals(id.Value)).FirstOrDefault();
            }
        }

        /// <summary>
        /// 选定的系统用户
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static int? SystemUserValue(ComboBox cb)
        {
            if (cb.SelectedItem == null || cb.SelectedValue == null)
            {
                return null;
            }
            else
            {
                return (cb.SelectedItem as EnumKeyValue<int?>).Value;
            }
        }

        /// <summary>
        /// 选中某一系统用户
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="id"></param>
        public static void SystemUserSelect(ComboBox cb, int? id)
        {
            var data = (cb.DataSource as List<EnumKeyValue<int?>>);
            if (data != null)
            {
                cb.SelectedItem = data.Where(it => it.Value.Equals(id)).FirstOrDefault();
            }
        }
        #endregion
    }
}
