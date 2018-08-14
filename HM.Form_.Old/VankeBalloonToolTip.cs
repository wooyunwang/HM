using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HM.Form_.Old
{
    /// <summary>
    /// 单独编写的Vanke软件的气球显示工具
    /// </summary>
    public class VankeBalloonToolTip
    {
        /// <summary>
        /// 是否已经给父窗体指定关闭事件
        /// 要让父窗体关闭时，同时关闭气球显示
        /// </summary>
        //  private bool m_IfAutoCloseSetted = false;
        /// <summary>
        /// 父窗体
        /// </summary>
        private Form m_ParentForm = null;
        private UserControl m_ParentControl = null;
        private BalloonToolTip m_Tip;

        public VankeBalloonToolTip(Form parentForm)
        {
            this.m_ParentForm = parentForm;

            Ini();
            this.m_ParentForm.FormClosing += new FormClosingEventHandler(m_ParentForm_FormClosing);
        }

        public VankeBalloonToolTip(Form parentForm, TooltipIcon Icon)
        {
            Ini();
            m_Tip.Icon = Icon;
            this.m_ParentForm = parentForm;

            this.m_ParentForm.FormClosing += new FormClosingEventHandler(m_ParentForm_FormClosing);
        }

        public VankeBalloonToolTip(UserControl parentControl)
        {
            this.m_ParentControl = parentControl;

            Ini();

            this.m_ParentControl.Leave += new EventHandler(m_ParentControl_ControlLeave);
        }

        public void Hide()
        {
            m_Tip.Hide();
        }
        void m_ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Tip.Hide();
        }
        void m_ParentControl_ControlLeave(object sender, EventArgs e)
        {
            m_Tip.Hide();
        }
        //void m_ParentControl_ControlRemoved(object sender, ControlEventArgs e)
        //{
        //    m_Tip.Hide();
        //}

        private void Ini()
        {
            if (m_Tip != null)
            {
                m_Tip.Hide();
                m_Tip.Destroy();
            }
            m_Tip = new BalloonToolTip();
            m_Tip.Icon = TooltipIcon.Info;
            m_Tip.VisibleTime = 3000;
            m_Tip.PopupOnDemand = true;
        }
        /// <summary>
        /// 初始化带Vanke文字的气球控件
        /// </summary>
        public VankeBalloonToolTip()
        {
            Ini();

        }
        public VankeBalloonToolTip(TooltipIcon Icon)
        {
            Ini();
            m_Tip.Icon = Icon;
        }
        /// <summary>
        /// 用于指定显示位置及文字的一次性方法，简单好用
        /// </summary>
        /// <param name="c"></param>
        /// <param name="content"></param>
        /// <param name="align"></param>
        public void ShowIt(Control c, string content, BalloonAlignment align)
        {
            try
            {
                Ini();

                m_Tip.CreateToolTip(c.Handle.ToInt32());
                m_Tip.Title = content;
                m_Tip.TipText = "    ";
                m_Tip.Show(align);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void ShowIt(Control c, string content, TooltipIcon icon)
        {

            m_Tip.Icon = icon;
            ShowIt(c, content, BalloonAlignment.RightMiddle);

        }
        public void ShowIt(Control c, string content, TooltipIcon icon, BalloonAlignment align)
        {

            m_Tip.Icon = icon;
            ShowIt(c, content, align);
            m_Tip.Icon = TooltipIcon.Info;
        }


        /// <summary>
        /// 用于指定显示位置及文字的一次性方法，简单好用
        /// 这里默认是在控件的中右方显示
        /// </summary>
        /// <param name="c"></param>
        /// <param name="content"></param>
        public void ShowIt(Control c, string content)
        {

            m_Tip.Icon = TooltipIcon.Info;
            ShowIt(c, content, BalloonAlignment.RightMiddle);
        }

        /// <summary>
        /// 用于指定显示位置及文字的一次性方法，简单好用
        /// 这里默认是在控件的中右方显示
        /// </summary>
        /// <param name="c"></param>
        /// <param name="content"></param>
        public void ShowItTop(Control c, string content)
        {

            m_Tip.Icon = TooltipIcon.Info;
            ShowIt(c, content, BalloonAlignment.RightMiddle);
        }

        void TianchiDataPropertyGrid_DataGridView_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Tip.Hide();
        }
    }
}
