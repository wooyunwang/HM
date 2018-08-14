
using System; 
using System.ComponentModel; 
using System.Collections; 
using System.Diagnostics; 
using System.Windows.Forms; 
using System.Drawing; 
using System.Drawing.Drawing2D;

namespace HM.Form_.Old
{

    [ToolboxItem(true)] 
    public class PanelXP : System.Windows.Forms.Panel 
    { 
        /// <summary> 
        /// 获得当前进程，以便重绘控件 
        /// </summary> 
        /// <param name="hWnd"></param> 
        /// <returns></returns> 
        [System.Runtime.InteropServices.DllImport("user32.dll")] 
        static extern IntPtr GetWindowDC(IntPtr hWnd); 
        [System.Runtime.InteropServices.DllImport("user32.dll")] 
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);



        /// <summary> 
        /// 边框颜色 
        /// </summary> 
        private Color _BorderColor = Color.FromArgb(0xA7,0xA6,0xAA);


         
        #region 属性 

        /// <summary> 
        /// 边框颜色 
        /// </summary> 
        [ Category("外观"), 
        Description("获得或设置控件的边框颜色"), 
        DefaultValue(typeof(Color),"#A7A6AA")] 
        public Color BorderColor 
        { 
            get 
            { 
                return this._BorderColor; 
            } 
            set 
            { 
                this._BorderColor = value; 
                this.Invalidate(); 
            } 
        }    

        #endregion 属性

        /// <summary> 
        /// 
        /// </summary> 
        public PanelXP()
            : base() 
        {             
        }

 

        /// <summary> 
        /// 获得操作系统消息 
        /// </summary> 
        /// <param name="m"></param> 
        protected override void WndProc(ref Message m) 
        {

            try
            {
                if (m.Msg == 0xf || m.Msg == 0x133)
                {
                    IntPtr hDC = GetWindowDC(m.HWnd);
                    if (hDC.ToInt32() == 0)
                    {
                        return;
                    }

                    //只有在边框样式为FixedSingle时自定义边框样式才有效 
                    if (this.BorderStyle == BorderStyle.FixedSingle)
                    {
                        //边框Width为1个像素 
                        System.Drawing.Pen pen = new Pen(this._BorderColor, 1); ;
                        //绘制边框 
                        System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                        pen.Dispose();
                    }
                    //返回结果 
                    m.Result = IntPtr.Zero;
                    //释放 
                    ReleaseDC(m.HWnd, hDC);
                }
                base.WndProc(ref m);
            }catch(Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

    } 
}