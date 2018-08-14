using System.Drawing;
using System.Windows.Forms;

namespace HM.FacePlatform
{
    public partial class ucPanel : UserControl
    {
        public ucPanel()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Panel)sender).ClientRectangle, Color.FromArgb(224, 224, 224), ButtonBorderStyle.Solid);
        }
    }
}
