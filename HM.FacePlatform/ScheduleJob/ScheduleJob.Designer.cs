namespace HM.FacePlatform
{
    partial class ScheduleJob
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleJob));
            this.pnHead = new System.Windows.Forms.Panel();
            this.pnButton = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.pnProcess = new System.Windows.Forms.Panel();
            this.pbProcess = new HM.Form_.Old.ProgressBar();
            this.pnMessage = new System.Windows.Forms.Panel();
            this.tbMessage = new System.Windows.Forms.RichTextBox();
            this.menuMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.pnHead.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.pnProcess.SuspendLayout();
            this.pnMessage.SuspendLayout();
            this.menuMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHead
            // 
            this.pnHead.BackColor = System.Drawing.SystemColors.Window;
            this.pnHead.Controls.Add(this.pnButton);
            this.pnHead.Controls.Add(this.pnProcess);
            this.pnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHead.Location = new System.Drawing.Point(0, 0);
            this.pnHead.Name = "pnHead";
            this.pnHead.Size = new System.Drawing.Size(398, 26);
            this.pnHead.TabIndex = 0;
            // 
            // pnButton
            // 
            this.pnButton.BackColor = System.Drawing.SystemColors.Window;
            this.pnButton.Controls.Add(this.btnMin);
            this.pnButton.Controls.Add(this.btnMax);
            this.pnButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnButton.Location = new System.Drawing.Point(318, 0);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(80, 26);
            this.pnButton.TabIndex = 118;
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMin.BackgroundImage = global::HM.FacePlatform.Properties.Resources.Minimum;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMin.Location = new System.Drawing.Point(3, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(24, 26);
            this.btnMin.TabIndex = 31;
            this.btnMin.Tag = "1";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMax.BackgroundImage = global::HM.FacePlatform.Properties.Resources.Maximum;
            this.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMax.Location = new System.Drawing.Point(45, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(24, 26);
            this.btnMax.TabIndex = 1;
            this.btnMax.Tag = "0";
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // pnProcess
            // 
            this.pnProcess.BackColor = System.Drawing.SystemColors.Window;
            this.pnProcess.Controls.Add(this.pbProcess);
            this.pnProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProcess.Location = new System.Drawing.Point(0, 0);
            this.pnProcess.Name = "pnProcess";
            this.pnProcess.Size = new System.Drawing.Size(398, 26);
            this.pnProcess.TabIndex = 117;
            // 
            // pbProcess
            // 
            this.pbProcess.BackgroundColor = System.Drawing.SystemColors.Window;
            this.pbProcess.BorderColor = System.Drawing.SystemColors.Window;
            this.pbProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProcess.Location = new System.Drawing.Point(0, 0);
            this.pbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.pbProcess.Maximum = 10;
            this.pbProcess.Minimum = 0;
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(398, 26);
            this.pbProcess.TabIndex = 116;
            this.pbProcess.Value = 0;
            this.pbProcess.ValueColor = System.Drawing.Color.Lime;
            // 
            // pnMessage
            // 
            this.pnMessage.Controls.Add(this.tbMessage);
            this.pnMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMessage.Location = new System.Drawing.Point(0, 26);
            this.pnMessage.Name = "pnMessage";
            this.pnMessage.Size = new System.Drawing.Size(398, 205);
            this.pnMessage.TabIndex = 1;
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.White;
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMessage.ContextMenuStrip = this.menuMessage;
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMessage.HideSelection = false;
            this.tbMessage.Location = new System.Drawing.Point(0, 0);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(398, 205);
            this.tbMessage.TabIndex = 30;
            this.tbMessage.Text = "";
            // 
            // menuMessage
            // 
            this.menuMessage.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClear});
            this.menuMessage.Name = "menuMessage";
            this.menuMessage.Size = new System.Drawing.Size(153, 32);
            // 
            // menuClear
            // 
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(152, 28);
            this.menuClear.Text = "清除信息";
            this.menuClear.Click += new System.EventHandler(this.menuClear_Click);
            // 
            // ScheduleJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 231);
            this.Controls.Add(this.pnMessage);
            this.Controls.Add(this.pnHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScheduleJob";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleJob_FormClosing);
            this.Load += new System.EventHandler(this.ScheduleJob_Load);
            this.pnHead.ResumeLayout(false);
            this.pnButton.ResumeLayout(false);
            this.pnProcess.ResumeLayout(false);
            this.pnMessage.ResumeLayout(false);
            this.menuMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHead;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Panel pnMessage;
        private System.Windows.Forms.RichTextBox tbMessage;
        private HM.Form_.Old.ProgressBar pbProcess;
        private System.Windows.Forms.Panel pnButton;
        private System.Windows.Forms.Panel pnProcess;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.ContextMenuStrip menuMessage;
        private System.Windows.Forms.ToolStripMenuItem menuClear;

    }
}