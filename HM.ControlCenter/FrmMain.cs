﻿using HM.Form_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.ControlCenter
{
    public partial class FrmMain : HMForm
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Text = FormHelper.GetAppName();
        }
    }
}