namespace HM.FacePlatform.Forms
{
    partial class AddOrUpdateUserFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrUpdateUserFrm));
            this.tbMoblie = new HM.Form_.HMTextBox();
            this.tbIdNum = new HM.Form_.HMTextBox();
            this.tbName = new HM.Form_.HMTextBox();
            this.lblMobile = new HM.Form_.HMLabel();
            this.lblIdNum = new HM.Form_.HMLabel();
            this.lbl_Name = new HM.Form_.HMLabel();
            this.lbl_HouseName = new HM.Form_.HMLabel();
            this.lblRelation = new HM.Form_.HMLabel();
            this.BtnAdd = new HM.Form_.HMTile();
            this.BtnCancel = new HM.Form_.HMTile();
            this.lblHouseName = new HM.Form_.HMLabel();
            this.lblSex = new HM.Form_.HMLabel();
            this.dropSex = new HM.Form_.HMComboBox();
            this.dropUserType = new HM.Form_.HMComboBox();
            this.lblUserType = new HM.Form_.HMLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRelation = new HM.Form_.HMTextBox();
            this.SuspendLayout();
            // 
            // tbMoblie
            // 
            this.tbMoblie.Location = new System.Drawing.Point(133, 238);
            this.tbMoblie.MaxLength = 11;
            this.tbMoblie.Name = "tbMoblie";
            this.tbMoblie.Size = new System.Drawing.Size(156, 30);
            this.tbMoblie.TabIndex = 5;
            // 
            // tbIdNum
            // 
            this.tbIdNum.Location = new System.Drawing.Point(133, 282);
            this.tbIdNum.MaxLength = 18;
            this.tbIdNum.Name = "tbIdNum";
            this.tbIdNum.Size = new System.Drawing.Size(156, 30);
            this.tbIdNum.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(133, 108);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(156, 30);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.BackColor = System.Drawing.Color.Transparent;
            this.lblMobile.ForeColor = System.Drawing.Color.Black;
            this.lblMobile.Location = new System.Drawing.Point(47, 247);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(54, 19);
            this.lblMobile.TabIndex = 100;
            this.lblMobile.Text = "手机号:";
            // 
            // lblIdNum
            // 
            this.lblIdNum.AutoSize = true;
            this.lblIdNum.BackColor = System.Drawing.Color.Transparent;
            this.lblIdNum.ForeColor = System.Drawing.Color.Black;
            this.lblIdNum.Location = new System.Drawing.Point(47, 290);
            this.lblIdNum.Name = "lblIdNum";
            this.lblIdNum.Size = new System.Drawing.Size(68, 19);
            this.lblIdNum.TabIndex = 100;
            this.lblIdNum.Text = "身份证号:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_Name.Location = new System.Drawing.Point(47, 118);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(40, 19);
            this.lbl_Name.TabIndex = 100;
            this.lbl_Name.Text = "姓名:";
            // 
            // lbl_HouseName
            // 
            this.lbl_HouseName.AutoSize = true;
            this.lbl_HouseName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_HouseName.ForeColor = System.Drawing.Color.Black;
            this.lbl_HouseName.Location = new System.Drawing.Point(47, 75);
            this.lbl_HouseName.Name = "lbl_HouseName";
            this.lbl_HouseName.Size = new System.Drawing.Size(40, 19);
            this.lbl_HouseName.TabIndex = 100;
            this.lbl_HouseName.Text = "房号:";
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.BackColor = System.Drawing.Color.Transparent;
            this.lblRelation.ForeColor = System.Drawing.Color.Black;
            this.lblRelation.Location = new System.Drawing.Point(47, 333);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(40, 19);
            this.lblRelation.TabIndex = 100;
            this.lblRelation.Text = "关系:";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.BtnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnAdd.Location = new System.Drawing.Point(196, 383);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(76, 25);
            this.BtnAdd.TabIndex = 7;
            this.BtnAdd.Text = "保存";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(152)))), ((int)(((byte)(237)))));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancel.Location = new System.Drawing.Point(76, 383);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(76, 25);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Location = new System.Drawing.Point(133, 75);
            this.lblHouseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(95, 19);
            this.lblHouseName.TabIndex = 105;
            this.lblHouseName.Text = "lblHouseName";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.ForeColor = System.Drawing.Color.Black;
            this.lblSex.Location = new System.Drawing.Point(47, 161);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(40, 19);
            this.lblSex.TabIndex = 106;
            this.lblSex.Text = "性别:";
            // 
            // dropSex
            // 
            this.dropSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dropSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropSex.FormattingEnabled = true;
            this.dropSex.ItemHeight = 23;
            this.dropSex.Location = new System.Drawing.Point(133, 152);
            this.dropSex.Name = "dropSex";
            this.dropSex.Size = new System.Drawing.Size(156, 29);
            this.dropSex.TabIndex = 4;
            // 
            // dropUserType
            // 
            this.dropUserType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dropUserType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropUserType.FormattingEnabled = true;
            this.dropUserType.ItemHeight = 23;
            this.dropUserType.Location = new System.Drawing.Point(133, 195);
            this.dropUserType.Name = "dropUserType";
            this.dropUserType.Size = new System.Drawing.Size(156, 29);
            this.dropUserType.TabIndex = 4;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.Transparent;
            this.lblUserType.ForeColor = System.Drawing.Color.Black;
            this.lblUserType.Location = new System.Drawing.Point(47, 204);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(68, 19);
            this.lblUserType.TabIndex = 109;
            this.lblUserType.Text = "用户类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 115;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(31, 211);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 116;
            this.label1.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(31, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(31, 247);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 118;
            this.label5.Text = "*";
            // 
            // tbRelation
            // 
            this.tbRelation.Location = new System.Drawing.Point(133, 326);
            this.tbRelation.Name = "tbRelation";
            this.tbRelation.Size = new System.Drawing.Size(156, 30);
            this.tbRelation.TabIndex = 110;
            // 
            // AddOrUpdateUserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 434);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dropSex);
            this.Controls.Add(this.dropUserType);
            this.Controls.Add(this.tbRelation);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblHouseName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.lblRelation);
            this.Controls.Add(this.tbMoblie);
            this.Controls.Add(this.tbIdNum);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.lblIdNum);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_HouseName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrUpdateUserFrm";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Resizable = false;
            this.Text = "注册新成员";
            this.Load += new System.EventHandler(this.AddOrUpdateUserFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HM.Form_.HMTextBox tbMoblie;
        private HM.Form_.HMTextBox tbIdNum;
        private HM.Form_.HMTextBox tbName;
        private HM.Form_.HMLabel lblMobile;
        private HM.Form_.HMLabel lblIdNum;
        private HM.Form_.HMLabel lbl_Name;
        private HM.Form_.HMLabel lbl_HouseName;
        private HM.Form_.HMLabel lblRelation;
        private HM.Form_.HMTile BtnAdd;
        private HM.Form_.HMTile BtnCancel;
        private HM.Form_.HMLabel lblHouseName;
        private HM.Form_.HMLabel lblSex;
        private HM.Form_.HMLabel lblUserType;
        private HM.Form_.HMComboBox dropSex;
        private HM.Form_.HMComboBox dropUserType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Form_.HMTextBox tbRelation;
    }
}