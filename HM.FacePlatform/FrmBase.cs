using HM.Form_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    public partial class FrmBase : HMForm
    {
        public FrmBase()
        {
            InitializeComponent();

            _Msm.Style = Program._Style;
        }
    }
}
