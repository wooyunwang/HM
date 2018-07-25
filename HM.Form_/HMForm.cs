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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HMForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "HMForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "标题";
            this.ResumeLayout(false);

        }
    }
}
