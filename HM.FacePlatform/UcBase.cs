using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HM.Form_;

namespace HM.FacePlatform
{
    public partial class UcBase : HMUserControl
    {
        public UcBase()
        {
            InitializeComponent();
            _Msm.Style = Program._Style;
        }
    }
}
