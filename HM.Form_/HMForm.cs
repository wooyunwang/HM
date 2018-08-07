using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Form_
{
    public class HMForm : MetroForm
    {
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HMForm));
            this.SuspendLayout();
            // 
            // HMForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HMForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "标题";
            this.ResumeLayout(false);

        }

        public MetroFramework.Components.MetroStyleManager _Msm { get; set; }
        public HMForm() : base()
        {
            this._Msm = new MetroFramework.Components.MetroStyleManager();
            this._Msm.Owner = this;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
    }
}
