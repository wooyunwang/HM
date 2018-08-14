using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.Form_
{
    public static class HMMessageBox
    {
        public static DialogResult Show(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message);
        }

        public static DialogResult Show(IWin32Window owner, string message, string title)
        {
            return MessageBox.Show(owner, message, title);
        }
        public static DialogResult Show(IWin32Window owner, string message, string title, MessageBoxButtons buttons)
        {
            return MessageBox.Show(owner, message, title, buttons);
        }
        public static DialogResult Show(IWin32Window owner, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(owner, message, title, buttons, icon);
        }
        public static DialogResult Show(IWin32Window owner, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            return MessageBox.Show(owner, message, title, buttons, icon, defaultbutton);
        }
    }
}
