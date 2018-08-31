using HM.Form_;
using System;
using System.Windows.Forms;

namespace HM.FacePlatform.UserControls
{
    public partial class ucNoData : HMUserControl
    {
        public string Note { get; set; }


        public ucNoData()
        {
            InitializeComponent();
        }

        private void ucNoData_Load(object sender, EventArgs e)
        {
            label1.Text = Note;
        }
    }
}
