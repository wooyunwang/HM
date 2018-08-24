using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
namespace HM.AutoUpdate.Writer
{
    partial class FrmAutoUpdateConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoUpdateConfig));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPublish = new System.Windows.Forms.Button();
            this.prbProd = new System.Windows.Forms.ProgressBar();
            this.btnProduce = new System.Windows.Forms.Button();
            this.lblHostUrl = new System.Windows.Forms.Label();
            this.lblSrc = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.chkAllow = new System.Windows.Forms.CheckBox();
            this.txtHostUrl = new System.Windows.Forms.TextBox();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.lblExclude = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveExclude = new System.Windows.Forms.Button();
            this.dgvExclude = new System.Windows.Forms.DataGridView();
            this.colExcludeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpressionComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lstMsg = new System.Windows.Forms.TextBox();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclude)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPublish);
            this.pnlBottom.Controls.Add(this.prbProd);
            this.pnlBottom.Controls.Add(this.btnProduce);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 467);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1182, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnPublish
            // 
            this.btnPublish.Enabled = false;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPublish.Location = new System.Drawing.Point(1084, 10);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(85, 21);
            this.btnPublish.TabIndex = 23;
            this.btnPublish.Text = "发布(&P)";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // prbProd
            // 
            this.prbProd.Location = new System.Drawing.Point(7, 9);
            this.prbProd.Name = "prbProd";
            this.prbProd.Size = new System.Drawing.Size(885, 23);
            this.prbProd.TabIndex = 2;
            this.prbProd.Visible = false;
            // 
            // btnProduce
            // 
            this.btnProduce.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProduce.Location = new System.Drawing.Point(898, 9);
            this.btnProduce.Name = "btnProduce";
            this.btnProduce.Size = new System.Drawing.Size(180, 23);
            this.btnProduce.TabIndex = 0;
            this.btnProduce.Text = "生成并自动批量改名(&G)";
            this.btnProduce.UseVisualStyleBackColor = true;
            this.btnProduce.Click += new System.EventHandler(this.btnProduce_Click);
            // 
            // lblHostUrl
            // 
            this.lblHostUrl.AutoSize = true;
            this.lblHostUrl.Location = new System.Drawing.Point(9, 29);
            this.lblHostUrl.Name = "lblHostUrl";
            this.lblHostUrl.Size = new System.Drawing.Size(75, 15);
            this.lblHostUrl.TabIndex = 9;
            this.lblHostUrl.Text = "主机网址:";
            // 
            // lblSrc
            // 
            this.lblSrc.AutoSize = true;
            this.lblSrc.Location = new System.Drawing.Point(9, 61);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.Size = new System.Drawing.Size(75, 15);
            this.lblSrc.TabIndex = 0;
            this.lblSrc.Text = "程序类型:";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(12, 368);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(538, 91);
            this.txtMemo.TabIndex = 11;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(9, 341);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(75, 15);
            this.lblMemo.TabIndex = 12;
            this.lblMemo.Text = "更新说明:";
            // 
            // chkAllow
            // 
            this.chkAllow.AutoSize = true;
            this.chkAllow.Location = new System.Drawing.Point(461, 60);
            this.chkAllow.Name = "chkAllow";
            this.chkAllow.Size = new System.Drawing.Size(89, 19);
            this.chkAllow.TabIndex = 14;
            this.chkAllow.Text = "强制更新";
            this.chkAllow.UseVisualStyleBackColor = true;
            // 
            // txtHostUrl
            // 
            this.txtHostUrl.Enabled = false;
            this.txtHostUrl.Location = new System.Drawing.Point(97, 24);
            this.txtHostUrl.Name = "txtHostUrl";
            this.txtHostUrl.ReadOnly = true;
            this.txtHostUrl.Size = new System.Drawing.Size(453, 25);
            this.txtHostUrl.TabIndex = 4;
            // 
            // cbxSource
            // 
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(97, 58);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(358, 23);
            this.cbxSource.TabIndex = 15;
            this.cbxSource.SelectedIndexChanged += new System.EventHandler(this.cbxSource_SelectedIndexChanged);
            // 
            // lblExclude
            // 
            this.lblExclude.AutoSize = true;
            this.lblExclude.Location = new System.Drawing.Point(9, 90);
            this.lblExclude.Name = "lblExclude";
            this.lblExclude.Size = new System.Drawing.Size(75, 15);
            this.lblExclude.TabIndex = 17;
            this.lblExclude.Text = "排除信息:";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(97, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 21);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Location = new System.Drawing.Point(188, 87);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 21);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(279, 87);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 21);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "删除(&S)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveExclude
            // 
            this.btnSaveExclude.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveExclude.Location = new System.Drawing.Point(370, 87);
            this.btnSaveExclude.Name = "btnSaveExclude";
            this.btnSaveExclude.Size = new System.Drawing.Size(85, 21);
            this.btnSaveExclude.TabIndex = 22;
            this.btnSaveExclude.Text = "保存(&S)";
            this.btnSaveExclude.UseVisualStyleBackColor = true;
            this.btnSaveExclude.Click += new System.EventHandler(this.btnSaveExclude_Click);
            // 
            // dgvExclude
            // 
            this.dgvExclude.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExclude.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExcludeType,
            this.colExpressionComment,
            this.colExpression});
            this.dgvExclude.Location = new System.Drawing.Point(12, 117);
            this.dgvExclude.Name = "dgvExclude";
            this.dgvExclude.RowTemplate.Height = 27;
            this.dgvExclude.Size = new System.Drawing.Size(538, 215);
            this.dgvExclude.TabIndex = 23;
            // 
            // colExcludeType
            // 
            this.colExcludeType.DataPropertyName = "ExcludeType";
            this.colExcludeType.HeaderText = "排除类型";
            this.colExcludeType.Name = "colExcludeType";
            // 
            // colExpressionComment
            // 
            this.colExpressionComment.DataPropertyName = "ExpressionComment";
            this.colExpressionComment.HeaderText = "表达式说明";
            this.colExpressionComment.Name = "colExpressionComment";
            this.colExpressionComment.Width = 150;
            // 
            // colExpression
            // 
            this.colExpression.DataPropertyName = "Expression";
            this.colExpression.HeaderText = "排除表达式";
            this.colExpression.Name = "colExpression";
            this.colExpression.Width = 250;
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(585, 24);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(25, 81);
            this.lblMsg.TabIndex = 25;
            this.lblMsg.Text = "输出信息";
            // 
            // lstMsg
            // 
            this.lstMsg.Location = new System.Drawing.Point(617, 24);
            this.lstMsg.Multiline = true;
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(552, 435);
            this.lstMsg.TabIndex = 26;
            // 
            // FrmAutoUpdateConfig
            // 
            this.ClientSize = new System.Drawing.Size(1182, 507);
            this.Controls.Add(this.lstMsg);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.dgvExclude);
            this.Controls.Add(this.btnSaveExclude);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblExclude);
            this.Controls.Add(this.cbxSource);
            this.Controls.Add(this.chkAllow);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lblHostUrl);
            this.Controls.Add(this.lblSrc);
            this.Controls.Add(this.txtHostUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutoUpdateConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动生成更新配置文件";
            this.Load += new System.EventHandler(this.FrmAutoUpdateConfig_Load);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclude)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Label lblMemo;
        private Label lblSrc;
        private Label lblHostUrl;
        private Panel pnlBottom;
        private ProgressBar prbProd;
        private TextBox txtMemo;
        private Button btnProduce;
        private CheckBox chkAllow;
        private TextBox txtHostUrl;
        private ComboBox cbxSource;
        private Label lblExclude;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSaveExclude;
        private Label lblMsg;
        private TextBox lstMsg;
        private DataGridView dgvExclude;
        private DataGridViewTextBoxColumn colExcludeType;
        private DataGridViewTextBoxColumn colExpressionComment;
        private DataGridViewTextBoxColumn colExpression;
        private Button btnPublish;
    }
}