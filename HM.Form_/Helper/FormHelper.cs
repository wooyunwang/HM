using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.AccessControl;
using System.IO;
using System.Reflection;

namespace HM.Form_
{
    public static class FormHelper
    {
        /// <summary>
        /// 在需要的情况下，开辟新的线程更新UI
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="methodInvoker"></param>
        public static void UIThread(this Control ctl, MethodInvoker methodInvoker, bool useBeginInvoke = false)
        {
            if (ctl.InvokeRequired)
            {
                if (useBeginInvoke)
                {
                    ctl.BeginInvoke(methodInvoker);
                }
                else
                {
                    ctl.Invoke(methodInvoker);
                }
            }
            else methodInvoker();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="msg"></param>
        public static void OnMessage(this HMTextBox tb, string msg)
        {
            tb.UIThread(() =>
            {
                if (tb.Text.Length > 2000) { tb.Text = ""; }
                tb.Text = DateTime.Now.ToString("hh:mm:ss") + "：" + msg + Environment.NewLine + tb.Text;
            });
        }

        /// <summary>
        /// 获取应用名称
        /// </summary>
        /// <returns></returns>
        public static string GetAppName()
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            return fvi.ProductName + " · v" + fvi.ProductVersion;
        }

        /// <summary>
        /// 是否处于设计模式下
        /// <![CDATA[
        /// 主要用途：Load的时候，处于设计模式时不执行相关代码。
        /// ]]>
        /// </summary>
        /// <returns></returns>
        public static bool IsDesignMode()
        {
            bool returnFlag = false;

#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnFlag = true;
            }
#endif
            return returnFlag;
        }

        /// <summary>
        /// 将模型的最大长度绑定到TextBox上
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="textBox"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        public static void MaxLength_<TModel>(
            this TextBox textBox,
            Expression<Func<TModel, string>> expression)
        {
            var member = expression.Body as MemberExpression;
            var stringLength = member.Member
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault();
            if (stringLength != null)
            {
                textBox.MaxLength = (stringLength as StringLengthAttribute).MaximumLength;
            }
        }
        /// <summary>
        /// 中文区域性初始化
        /// </summary>
        public static void SetZhCnCulturInfo()
        {
            CultureInfo cultureInfo = new CultureInfo("zh-CN");
            cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            cultureInfo.DateTimeFormat.LongDatePattern = "yyyy-MM-dd HH:mm:ss";
            cultureInfo.DateTimeFormat.ShortTimePattern = "HH:mm";
            cultureInfo.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            Application.CurrentCulture = cultureInfo;
        }

        /// <summary>
        /// 为指定用户组，授权目录指定完全访问权限
        /// <![CDATA[
        /// Demo:
        /// //为用户组指定对应目录的完全访问权限
        /// SetAccess("Users", Application.StartupPath);
        /// ]]>
        /// </summary>
        /// <param name="user">用户组，如Users</param>
        /// <param name="folder">实际的目录</param>
        /// <returns></returns>
        public static bool SetAccess(string user, string folder)
        {
            //定义为完全控制的权限
            const FileSystemRights Rights = FileSystemRights.FullControl;

            //添加访问规则到实际目录
            var AccessRule = new FileSystemAccessRule(user, Rights,
                InheritanceFlags.None,
                PropagationFlags.NoPropagateInherit,
                AccessControlType.Allow);

            var Info = new DirectoryInfo(folder);
            var Security = Info.GetAccessControl(AccessControlSections.Access);

            bool Result;
            Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);
            if (!Result) return false;

            //总是允许再目录上进行对象继承
            const InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

            //为继承关系添加访问规则
            AccessRule = new FileSystemAccessRule(user, Rights,
                iFlags,
                PropagationFlags.InheritOnly,
                AccessControlType.Allow);

            Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);
            if (!Result) return false;

            Info.SetAccessControl(Security);

            return true;
        }
    }
}
