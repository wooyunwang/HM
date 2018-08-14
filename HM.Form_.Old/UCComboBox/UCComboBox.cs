using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Drawing;

namespace HM.Form_.Old
{
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    public partial class UCComboBox : ComboBox
    {

        #region support readonly property
        private bool readOnly;
        private ContextMenu cmnuEmpty;
        private ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDown;

        // ReadOnly property
        [Description("Read only"), Category("Behavior"), DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    readOnly = value;
                    if (value)
                    {
                        this.ContextMenu = cmnuEmpty;
                        base.DropDownStyle = ComboBoxStyle.Simple;
                        base.Height = 21;
                        base.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        this.ContextMenu = null;
                        base.DropDownStyle = dropDownStyle;
                        base.BackColor = SystemColors.ActiveCaptionText;
                    }
                }
            }
        }

        new public ComboBoxStyle DropDownStyle
        {
            get
            {
                return dropDownStyle;
            }
            set
            {
                if (dropDownStyle != value)
                {
                    dropDownStyle = value;
                    if (!this.ReadOnly) base.DropDownStyle = value;
                }
            }
        }



        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.ReadOnly && !copy)
                e.Handled = true;
            else
            {
                base.OnKeyPress(e);
                copy = false;
            }
        }
        bool copy = false;
        protected override bool ProcessCmdKey(ref   Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.C))
            {
                copy = true;
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else if (readOnly)
            {
                return true;
            }
            else
            {
                copy = false;
                return base.ProcessCmdKey(ref msg, keyData);
            }

        }

        #endregion

        #region search
        private System.Windows.Forms.DataGridView lbMain;
        private System.Windows.Forms.Panel lPanel;
        private int _totalWith = 0;
        private bool acceptInput;

        [Description("是否接受用户输入"), Category("Behavior"), DefaultValue(true)]
        public bool AcceptInput
        {
            get { return acceptInput; }
            set { acceptInput = value; }
        }
        private string _DisplayMembersWidth = "";
        [Description("是否接受用户输入 如：70,100 说明第一列宽度为70，第二列为100"), Category("必须的选项")]
        public string DisplayMembersWidth
        {
            get
            {
                if (_DisplayMembersWidth == "")
                    return string.Format("{0},{0}", this.Width / 2);
                else
                    return _DisplayMembersWidth;
            }
            set { _DisplayMembersWidth = value; }
        }
        private string _DisplayMembers = string.Empty;
        [Description("是否接受用户输入 如：id,name "), Category("必须的选项")]
        public string DisplayMembers
        {
            get { return _DisplayMembers; }
            set { _DisplayMembers = value; }
        }
        public UCComboBox()
        {

            cmnuEmpty = new ContextMenu();
            //lbMain = new ListBox();
            lbMain = new DataGridView();
            lbMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            lbMain.AllowUserToAddRows = false;
            lbMain.AllowUserToDeleteRows = false;
            lbMain.AllowUserToOrderColumns = false;
            lbMain.RowHeadersVisible = false;
            lbMain.ColumnHeadersVisible = false;
            lbMain.MultiSelect = false;
            lbMain.ReadOnly = true;
            lbMain.AllowUserToResizeColumns = false;
            lbMain.AllowUserToResizeRows = false;
            lbMain.AutoGenerateColumns = false;
            lbMain.BackgroundColor = Color.White;
            lPanel = new System.Windows.Forms.Panel();
            lbMain.Click += new EventHandler(lbMain_Click);

            lbMain.KeyDown += new KeyEventHandler(lbMain_KeyDown);
            lPanel.Visible = false;

            lbMain.Click += new EventHandler(lPanel_Click);

        }



        public UCComboBox(IContainer container)
            : this()
        {
            container.Add(this);
        }


        private object _SelectedItem = null;
        public new object SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

        }

        public new object SelectedValue
        {
            get
            {

                if (_SelectedItem == null)
                    return null;
                else
                    return ((DataRowView)_SelectedItem)[this.ValueMember];
            }

        }

        private void lPanel_Click(object sender, System.EventArgs e)
        {
            dropDown = false;
            lPanel.Visible = false;
        }


        public new string SelectedText
        {
            get
            {
                if (_SelectedItem == null)
                    return null;
                else
                    return ((DataRowView)_SelectedItem)[this.DisplayMember].ToString();
            }

        }
        /// <summary>
        /// 选择改变的事件,已经重写
        /// </summary>
        public new event EventHandler SelectedValueChanged;
        private void lbMain_Click(object sender, System.EventArgs e)
        {

            object OldSelectedItem = this.SelectedItem;
            if (lbMain.SelectedRows.Count == 0)
            {
                _SelectedItem = null;

            }
            else
            {
                _SelectedItem = lbMain.SelectedRows[0].DataBoundItem;
                dropDown = true;
                this.Text = SelectedText;
                dropDown = false;
                lPanel.Visible = false;

            }
            #region 值改变事件

            if (SelectedValueChanged != null)
            {
                if (!object.ReferenceEquals(OldSelectedItem, _SelectedItem))
                {
                    if (OldSelectedItem != null && _SelectedItem != null)
                    {
                        if (((DataRowView)OldSelectedItem)[this.ValueMember].ToString() ==
                            ((DataRowView)_SelectedItem)[this.ValueMember].ToString())
                        {
                            return;
                        }
                    }
                    SelectedValueChanged(this, EventArgs.Empty);
                }
            }
            #endregion
        }


        private void InitData()
        {


            string[] strWidths = this.DisplayMembersWidth.Split(',', ';', '，', ':');
            string[] strMems = this.DisplayMembers.Split(',', ';', '，', ':');
            int sum = 0;
            int w = 0;

            for (int i = 0; i < strWidths.Length; i++)
            {
                w = int.Parse(strWidths[i]);
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = strMems[i];
                col.DataPropertyName = strMems[i];
                col.Width = w;
                if (!this.lbMain.Columns.Contains(strMems[i]))
                    this.lbMain.Columns.Add(col);
                sum += w;
                if (!ColumnAndWidth.Contains(this._colAndWidth, strMems[i]))
                    _colAndWidth.Add(new ColumnAndWidth(w, strMems[i]));

            }
            this._totalWith = sum + 20;


            lbMain.DataSource = this._DataViewSource;

            SetlbMainLocation();
        }

        #region 绑定数据源


        private DataView _DataViewSource = null;
        public new object DataSource
        {
            get
            {
                return _DataViewSource;
            }
            set
            {
                if (value == null) return;
                if (this.DisplayMembers.Trim() == "" || this.DisplayMembersWidth.Trim() == "")
                {
                    throw new Exception("请设置DisplayMembers 和 DisplayMembersWidth");
                }

                if (value is DataView)
                {
                    _DataViewSource = (DataView)value;
                    InitData();//初始化数据

                }
                else
                {
                    throw new Exception("请绑定到DataView");
                }
            }
        }
        #endregion

        /// <summary>
        /// 列名和宽度列表

        /// </summary>
        List<ColumnAndWidth> _colAndWidth = new List<ColumnAndWidth>();
        public class ColumnAndWidth
        {
            public ColumnAndWidth(int w, string c)
            {
                this.width = w;
                this.columnName = c;
            }
            int width = 100;

            public int Width
            {
                get { return width; }
                set { width = value; }
            }
            string columnName = "";

            public string ColumnName
            {
                get { return columnName; }
                set { columnName = value; }
            }
            public static bool Contains(List<ColumnAndWidth> list, string columnName)
            {
                foreach (ColumnAndWidth item in list)
                {
                    if (item.ColumnName == columnName)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (Text == "")
                    {

                        lPanel.Visible = false;
                        _SelectedItem = null;
                        if (SelectedValueChanged != null)
                        {
                            SelectedValueChanged(this, EventArgs.Empty);
                        }
                        //return;
                    }
                    //if (!dropDown)
                    //{
                    if (this._DataViewSource != null)
                        this._DataViewSource.RowFilter = SearchRowFilter(Text.Trim());

                    if (!lPanel.Visible && this.Focused)
                        lPanel.Visible = true;
                    //}
                }
                dropDown = false;
                base.OnTextChanged(e);
            }
            catch (Exception ex)
            {
                //VMS.Util.WriteLog.SetString("下拉用户控件:" + ex.Message);
            }
        }

        private string _LikeString = "";

        public string LikeString
        {
            get { return _LikeString; }
            set { _LikeString = value; }
        }
        private string SearchRowFilter(string txt)
        {
            if (txt == "") return "";
            txt = txt.Replace(",", "''");
            string filer = "";
            foreach (ColumnAndWidth var in this._colAndWidth)
            {
                if (this._DataViewSource.Table.Columns[var.ColumnName].DataType.FullName == "System.String")
                {
                    if (filer == "")
                        filer += string.Format(" {0} like '{2}{1}%'", var.ColumnName, txt, LikeString);
                    else
                        filer += string.Format(" or {0} like '{2}{1}%'", var.ColumnName, txt, LikeString);
                }
            }
            return filer;
        }

        private Point getPoint(Control col)
        {
            Point p = new Point(0, 0);
            Control ctr = gteParentForm(this);
            if (ctr == null) return p;
            p.X += col.Left;
            p.Y += col.Top;
            while (col != ctr)
            {
                col = col.Parent;
                p.X += col.Left;
                p.Y += col.Top;
            }
            return p;
        }



        private Control gteParentForm(Control col)
        {
            while (col != null && col.GetType().BaseType.FullName != "System.Windows.Forms.Form")
            {
                col = col.Parent;
            }
            return col;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (lbMain != null)
                {
                    SetlbMainLocation();
                }
            }
        }

        private void SetlbMainLocation()
        {
            lPanel.Visible = false;
            lPanel.Width = this._totalWith;
            lPanel.Height = 100;
            Control parent = gteParentForm(this);
            lPanel.Parent = parent; // TopLevelControl; //this.Parent;
            Point p = getPoint(this);
            if (parent != null)
            {
                lPanel.Top = p.Y - parent.Top + this.Height + 1;
                lPanel.Left = p.X - parent.Left;
            }
            lbMain.Parent = lPanel;
            lbMain.Dock = DockStyle.Fill;
            lPanel.BringToFront();
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!DesignMode)
            {
                if (!lbMain.Focused && !this.Focused)
                    if (this.SelectedIndex == -1 && !acceptInput)
                    {
                        this.Focus();
                    }
                    else
                    {
                        lPanel.Visible = false;
                        dropDown = false;
                    }
            }
            base.OnLeave(e);
        }

        private bool dropDown = false;
        protected override void OnDropDown(EventArgs e)
        {
            lPanel.Visible = false;
            dropDown = true;
            base.OnDropDown(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                if (!this.Visible)
                {
                    if (lbMain != null)
                    {
                        lPanel.Visible = false;
                        dropDown = false;
                    }
                }
            }
            base.OnVisibleChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            #region readonly
            if (this.ReadOnly && (
                    e.KeyCode == Keys.Up ||
                    e.KeyCode == Keys.Down ||
                    e.KeyCode == Keys.Delete))
                e.Handled = true;
            else
                base.OnKeyDown(e);
            #endregion

            if (lbMain.Visible)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left ||
                     e.KeyCode == Keys.Right || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
                {
                    lbMain_KeyDown(lbMain, e);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    lbMain_Click(lbMain, e);
                    e.Handled = true;
                }
            }
            base.OnKeyDown(e);
        }




        private void lbMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 13)//回车
            {
                lbMain_Click(lbMain, EventArgs.Empty);

            }
            else
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.PageUp)
                {
                    //if (lbMain.SelectedIndex > 0)
                    //    lbMain.SelectedIndex = lbMain.SelectedIndex - 1;
                    //if(lbMain.CurrentRow.Index>0)
                    //    lbMain.Rows[this.lbMain.CurrentRow.Index - 1].Selected = true; 


                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.PageDown)
                {
                    if (lbMain.SelectedRows.Count > 0)
                    {
                        lbMain.Focus();
                    }
                    //if (lbMain.SelectedIndex < lbMain.Items.Count - 1)
                    //    lbMain.SelectedIndex = lbMain.SelectedIndex + 1;
                    ////xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    //if (lbMain.CurrentRow.Index < lbMain.Rows.Count - 1)
                    //    lbMain.Rows[this.lbMain.CurrentRow.Index + 1].Selected = true; 
                }
        }

        private void UComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!DesignMode)
            {
                lPanel.Visible = false;
                dropDown = false;
            }
        }


        #endregion

        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                if (dropDown)
                {
                    dropDown = false;
                }
                else
                {
                    dropDown = true;
                }
                if (dropDown)
                {
                    if (this._DataViewSource != null)
                        this._DataViewSource.RowFilter = SearchRowFilter(Text);
                    this.lPanel.Visible = true;
                }
                else
                {
                    this.lPanel.Visible = false;
                }
                return;
            }
            base.WndProc(ref m);
        }
        public void Reset()
        {
            this._DataViewSource.RowFilter = "";
            this.Text = "";
            this._SelectedItem = null;
        }
    }


}
