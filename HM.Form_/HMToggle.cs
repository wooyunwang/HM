using MetroFramework.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HM.Form_
{
    public class HMToggle : MetroToggle
    {
        public HMToggle() : base()
        {
        }


        public string StatusOnText { get; set; }
        public string StatusOffText { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Size size = GetPreferredSize(Size.Empty);
            Rectangle textRect = new Rectangle(0, 0, size.Width, ClientRectangle.Height);
            TextRenderer.DrawText(e.Graphics, Checked ? StatusOnText : StatusOffText, base.Font, textRect, base.ForeColor);

        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StatusOnText) && string.IsNullOrWhiteSpace(StatusOffText))
                {
                    return base.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            Size preferredSize = base.GetPreferredSize(proposedSize);
            int max = Math.Max(StatusOnText.Length, StatusOffText.Length);
            if (max > 2)
            {
                preferredSize.Width = DisplayStatus ? max * 16 + 30 + 30 : max * 16 + 30;
            }
            else
            {
                preferredSize.Width = DisplayStatus ? 80 : 60;
            }
            return preferredSize;
        }
    }
}
