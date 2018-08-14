using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace HM.Form_.Old
{
    /// <summary>
    ///The Balloons class let's you use balloon-like tooltips in your C# apps.
    ///I think they only work on WinXP/2000 (Comclt32.dll version 6.0)
    /// </summary>
    public class BalloonToolTip
    {
        /// <summary>
        /// This event is thrown when the timer (if used) interval has elapsed.
        /// </summary>
        public event EventHandler timerElapsed;

        #region Private Vars

        /// <summary>
        /// Timer used for this class to remove the Balloon after its interval has elapsed
        /// </summary>
        private System.Timers.Timer timer;
        /// <summary>
        /// Text maximum Width
        /// </summary>
        /// <remarks>
        /// The units are not clear, if used make some tests
        /// </remarks>
        private int mvarmaxWidth;
        /// <summary>
        /// The Balloon's background color, in the format RGB 0xXXXXXX
        /// </summary>
        /// <remarks>
        /// Use the property BackColor to make the changes
        /// </remarks>
        private int mvarBackColor;
        /// <summary>
        /// The Balloon's text color, in the format RGB 0xXXXXXX
        /// </summary>
        /// <remarks>
        /// Use the property ForeColor to make the changes
        /// </remarks>
        private int mvarForeColor;
        /// <summary>
        /// Time (milliseconds) that the BalloonTip will be shown
        /// </summary>
        private int mvarVisibleTime;
        /// <summary>
        /// Delay time (milliseconds) that the BalloonTip will wait to display
        /// </summary>
        private int mvarDelayTime;
        /// <summary>
        /// BalloonTip String title
        /// </summary>
        /// <remarks>
        /// Use the Title property
        /// Does not accept \n
        /// </remarks>
        private string mvarTitle;
        /// <summary>
        /// BalloonTip Text
        /// </summary>
        /// <remarks>
        /// Use the TipText property
        /// Does not accept \n
        /// </remarks>
        private string mvarTipText;
        /// <summary>
        /// BalloonTip Icon asociated
        /// </summary>
        private TooltipIcon mvarIcon;
        /// <summary>
        /// BalloonTip Style
        /// </summary>
        /// <remarks>
        /// There are 2 posible styles:
        /// TTStandard - Shows a square window
        /// TTBalloon - Shows the balloon as you know it.
        /// </remarks>
        private Styles mvarStyle;
        /// <summary>
        /// Alignment to the parents forms.
        /// </summary>
        private BalloonAlignment mvarAlign;
        /// <summary>
        /// ???
        /// </summary>
        /// <remarks>
        /// Combining flags mvarPopupOnDemand, mvarCentered and mvarABSPosn
        /// you get different behavoirs
        /// </remarks>
        private bool mvarPopupOnDemand;
        /// <summary>
        /// Sets the BalloonTip pointer in it's the center.
        /// </summary>
        /// <remarks>
        /// Combining flags mvarPopupOnDemand, mvarCentered and mvarABSPosn
        /// you get different behavoirs
        /// </remarks>
        private bool mvarCentered;
        /// <summary>
        /// ???
        /// </summary>
        /// <remarks>
        /// I didnt see any real change in behavoir when this flags was triggered
        /// Combining flags mvarPopupOnDemand, mvarCentered and mvarABSPosn
        /// you get different behavoirs
        /// </remarks>
        private bool mvarABSPosn;
        /// <summary>
        /// Font that the BalloonTip will use
        /// </summary>
        private System.Drawing.Font mvarFont;
        /// <summary>
        /// ToolTip position in the screen
        /// </summary>
        private POINTAPI mvarPos;
        /// <summary>
        /// ToolTip hanlde
        /// </summary>
        private int m_lTTHwnd;
        /// <summary>
        /// Tooltip parents window handle
        /// </summary>
        private int m_lParentHwnd;
        /// <summary>
        /// TOOL needed to send messages
        /// </summary>
        private TOOLINFO ti;

        #endregion

        #region Public Properties

        /// <summary>
        /// Text maximum Width
        /// </summary>
        /// <remarks>
        /// The units are not clear, if used make some tests
        /// </remarks>
        public int MaxWidth
        {
            get
            {
                return mvarmaxWidth;
            }
            set
            {
                mvarmaxWidth = value;
                if (m_lTTHwnd != 0)
                {
                    SendMessage(m_lTTHwnd, TTM_SETMAXTIPWIDTH, 0, mvarmaxWidth);
                }
            }


        }
        /// <summary>
        /// The Balloon's background color
        /// </summary>
        public Color BackColor
        {
            get
            {
                return Color.FromArgb(mvarBackColor);
            }
            set
            {
                mvarBackColor = value.ToArgb();
                mvarBackColor &= 0x00FFFFFF; //We remove the alfa 
                if (m_lTTHwnd != 0)
                {
                    SendMessage(m_lTTHwnd, TTM_SETTIPBKCOLOR, mvarBackColor, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// The Balloon's text color
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return Color.FromArgb(mvarForeColor);
            }
            set
            {
                mvarForeColor = value.ToArgb();
                mvarForeColor &= 0x00FFFFFF; //We remove the alfa 
                if (m_lTTHwnd != 0)
                {
                    SendMessage(m_lTTHwnd, TTM_SETTIPTEXTCOLOR, mvarForeColor, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// Time (milliseconds) that the BalloonTip will be shown
        /// </summary>
        public int VisibleTime
        {
            get
            {
                return mvarVisibleTime;
            }
            set
            {
                mvarVisibleTime = value;
                if (mvarVisibleTime > 0)
                    timer.Interval = value;
            }
        }

        /// <summary>
        /// Delay time (milliseconds) that the BalloonTip will wait to display
        /// </summary>
        public int DelayTime
        {
            get
            {
                return mvarDelayTime;
            }
            set
            {
                mvarDelayTime = value;
            }
        }

        /// <summary>
        /// BalloonTip String title
        /// </summary>
        /// <remarks>
        /// Does not accept \n
        /// </remarks>
        public string Title
        {
            get
            {
                return mvarTitle;
            }
            set
            {
                mvarTitle = value;
                if (m_lTTHwnd != 0 && mvarTitle != string.Empty)
                {
                    SendMessage(m_lTTHwnd, TTM_SETTITLE, (int)mvarIcon, Marshal.StringToHGlobalAuto(mvarTitle));
                }
            }
        }

        /// <summary>
        /// BalloonTip String title
        /// </summary>
        /// <remarks>
        /// Does not accept \n
        /// </remarks>
        public string TipText
        {
            get
            {
                return mvarTipText;
            }
            set
            {
                if (value != null)
                {
                    mvarTipText = value;
                    ti.lpStr = value;
                    if (m_lTTHwnd != 0)
                    {
                        for (int i = 0; i <= 10; i++)
                        {
                            try
                            {
                                IntPtr ptrStruct = Marshal.AllocHGlobal(32 * Marshal.SizeOf(ti));
                                Marshal.StructureToPtr(ti, ptrStruct, false);
                                SendMessage(m_lTTHwnd, TTM_UPDATETIPTEXTA, 0, ptrStruct);
                                Marshal.FreeHGlobal(ptrStruct);
                                break;
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BalloonTip Icon asociated
        /// </summary>
        public TooltipIcon Icon
        {
            get
            {
                return mvarIcon;
            }
            set
            {
                mvarIcon = value;
                if (m_lTTHwnd != 0 && mvarTitle != string.Empty)
                {
                    SendMessage(m_lTTHwnd, TTM_SETTITLE, (int)mvarIcon, Marshal.StringToHGlobalAuto(mvarTitle));
                }
            }
        }

        /// <summary>
        /// BalloonTip Style
        /// </summary>
        /// <remarks>
        /// There are 2 posible styles:
        /// TTStandard - Shows a square window
        /// TTBalloon - Shows the balloon as you know it.
        /// </remarks>
        public Styles Style
        {
            get
            {
                return mvarStyle;
            }
            set
            {
                mvarStyle = value;
            }
        }

        /// <summary>
        /// Alignment to the parents forms.
        /// </summary>
        public BalloonAlignment Alignment
        {
            get
            {
                return mvarAlign;
            }
            set
            {
                if (ti.hwnd != 0)
                {
                    Point pt = new Point();
                    GetClientRect(ti.hwnd, ref ti.lprect);
                    ClientToScreen(ti.hwnd, ref ti.lprect);
                    switch (value)
                    {
                        default:
                        case BalloonAlignment.TopLeft:
                            pt.X = ti.lprect.left - 3;
                            pt.Y = ti.lprect.top;
                            break;
                        case BalloonAlignment.TopMiddle:
                            pt.X = ti.lprect.left + (ti.lprect.right / 2);
                            pt.Y = ti.lprect.top;
                            break;
                        case BalloonAlignment.TopRight:
                            pt.X = ti.lprect.left + ti.lprect.right + 3;
                            pt.Y = ti.lprect.top;
                            break;
                        case BalloonAlignment.LeftMiddle:
                            pt.X = ti.lprect.left - 1;
                            pt.Y = ti.lprect.top + (ti.lprect.bottom / 2);
                            break;
                        case BalloonAlignment.RightMiddle:
                            pt.X = ti.lprect.left + ti.lprect.right + 3;
                            pt.Y = ti.lprect.top + (ti.lprect.bottom / 2);
                            break;
                        case BalloonAlignment.BottomLeft:
                            pt.X = ti.lprect.left;
                            pt.Y = ti.lprect.top + ti.lprect.bottom - 3;
                            break;
                        case BalloonAlignment.BottomMiddle:
                            pt.X = ti.lprect.left + (ti.lprect.right / 2);
                            pt.Y = ti.lprect.top + ti.lprect.bottom;
                            break;
                        case BalloonAlignment.BottomRight:
                            pt.X = ti.lprect.left + ti.lprect.right + 3;
                            pt.Y = ti.lprect.top + ti.lprect.bottom;
                            break;
                    }
                    Position = pt;
                    mvarAlign = value; //Do not move this from here.		
                }
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <remarks>
        /// Combining flags mvarPopupOnDemand, mvarCentered and mvarABSPosn
        /// you get different behavoirs
        /// </remarks>
        public bool PopupOnDemand
        {
            get
            {
                return mvarPopupOnDemand;
            }
            set
            {
                mvarPopupOnDemand = value;
            }
        }

        /// <summary>
        /// Sets the BalloonTip pointer in it's the center.
        /// </summary>
        /// <remarks>
        /// Combining flags mvarPopupOnDemand, mvarCentered and mvarABSPosn
        /// you get different behavoirs
        /// </remarks>
        public bool Centered
        {
            get
            {
                return mvarCentered;
            }
            set
            {
                mvarCentered = value;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <remarks>
        /// I didnt see any real change in behavoir when this flags was triggered
        /// Combining flags mvarPopupOnDemand, mvarCentered and mvarABSPosn
        /// you get different behavoirs
        /// </remarks>
        public bool AbsolutePositioning
        {
            get
            {
                return mvarABSPosn;
            }
            set
            {
                mvarABSPosn = value;
                if (mvarABSPosn)
                    ti.lFlags |= TTF_ABSOLUTE;
                else
                    ti.lFlags ^= TTF_ABSOLUTE;


            }
        }

        /// <summary>
        /// Font that the BalloonTip will use
        /// </summary>
        public System.Drawing.Font TipFont
        {
            get
            {
                return mvarFont;
            }
            set
            {
                mvarFont = value;
                if (m_lTTHwnd != 0)
                {
                    SendMessage(m_lTTHwnd, WM_SETFONT, mvarFont.ToHfont().ToInt32(), 1);
                }
            }
        }

        /// <summary>
        /// ToolTip position in the screen
        /// </summary>
        public Point Position
        {
            get
            {
                return new Point(mvarPos.X, mvarPos.Y);
            }
            set
            {
                mvarPos = new POINTAPI(value.X, value.Y);
                mvarAlign = BalloonAlignment.Custom;
                //TTM_TRACKPOSITION Message needs the coordinates like this
                SendMessage(m_lTTHwnd, TTM_TRACKPOSITION, 0, MAKELONG(mvarPos.X, mvarPos.Y));
            }
        }


        #endregion

        //Not all the constants are used... nevertheless they are here, just in case
        //Some constant values were obtained from the API-Guide, available in http://www.allapi.net
        //Other constants came from ApiViewer2004.exe available in http://www.activevb.de/rubriken/apiviewer/index-apiviewereng.html
        //They are also declared in Commctrl.h
        #region Constants
        internal const int WM_USER = 0x0400;
        internal const long CW_USEDEFAULT = 0x80000000;
        internal const int WM_SETFONT = 0x30;

        //For SetWindowsPos
        internal const int SWP_NOSIZE = 0x0001;
        internal const int SWP_NOMOVE = 0x0002;
        internal const int SWP_NOACTIVATE = 0x0010;
        internal const int SWP_NOZORDER = 0x0004;
        //Styles
        internal const int TTS_ALWAYSTIP = 0x01;
        internal const int TTS_NOPREFIX = 0x02;
        internal const int TTS_BALLOON = 0x40;
        internal const int TTS_CLOSE = 0x80;
        //Messages
        internal const int TTM_SETMAXTIPWIDTH = WM_USER + 24;
        internal const int TTM_ADDTOOL = WM_USER + 50;
        internal const int TTM_SETTITLE = WM_USER + 33;
        internal const int TTM_ACTIVATE = WM_USER + 1;
        internal const int TTM_UPDATETIPTEXTA = WM_USER + 12;
        internal const int TTM_SETDELAYTIME = WM_USER + 3;
        internal const int TTM_SETTOOLINFO = WM_USER + 54; //54
        internal const int TTM_TRACKACTIVATE = WM_USER + 17;
        internal const int TTM_TRACKPOSITION = WM_USER + 18;
        internal const int TTM_SETTIPBKCOLOR = WM_USER + 19;
        internal const int TTM_SETTIPTEXTCOLOR = WM_USER + 20;
        internal const int TTM_UPDATE = WM_USER + 29;
        //Flags
        internal const int TTF_IDISHWND = 0x0001;
        internal const int TTF_SUBCLASS = 0x0010;
        internal const int TTF_TRACK = 0x0020;
        internal const int TTF_ABSOLUTE = 0x0080;
        internal const int TTF_TRANSPARENT = 0x0100;
        internal const int TTF_CENTERTIP = 0x0002;
        internal const int TTF_PARSELINKS = 0x1000;
        internal const int TTF_RTLREADING = 0x04;

        //For TTM_SETDELAYTIME
        internal const int TTDT_AUTOMATIC = 0;
        internal const int TTDT_RESHOW = 1;
        internal const int TTDT_AUTOPOP = 2;
        internal const int TTDT_INITIAL = 3;

        internal const long WS_POPUP = 0x80000000;
        internal const string TOOLTIPS_CLASSA = "tooltips_class32";

        #endregion



        #region Static Extern Methods (API)

        /*
		 * The GetClientRect function retrieves the coordinates of a window抯 client 
		 * area. The client coordinates specify the upper-left and lower-right 
		 * corners of the client area. Because client coordinates are relative 
		 * to the upper-left corner of a window抯 client area, the coordinates 
		 * of the upper-left corner are (0,0).
		 */
        [DllImport("User32", SetLastError = true)]
        internal static extern int GetClientRect(
            int hWnd,
            ref RECT lpRect);

        /*
         * The ClientToScreen function converts the client coordinates of a 
         * specified point to screen coordinates.
         */
        [DllImport("User32", SetLastError = true)]
        internal static extern int ClientToScreen(
            int hWnd,
            ref POINTAPI lpPoint);

        [DllImport("User32", SetLastError = true)]
        private static extern int ClientToScreen(
            int hWnd,
            ref RECT lpRect);

        /*
         * The SendMessage function sends the specified message to a window. 
         * The function calls the window procedure for the specified window 
         * and does not return until the window procedure has processed the 
         * message. 
         */
        [DllImport("User32", SetLastError = true)]
        internal static extern int SendMessage(
            int hWnd,
            int Msg,
            int wParam,
            IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendMessage(
            int hWnd,
            int Msg,
            int wParam,
            int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendMessage(
            int hWnd,
            int Msg,
            int wParam,
            TOOLINFO lParam);

        /*
         * The CreateWindowEx function creates an overlapped, pop-up, or child window 
         * with an extended style; otherwise, this function is identical to the 
         * CreateWindow function.
         */
        [DllImport("User32", SetLastError = true)]
        internal static extern int CreateWindowEx(
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            int hWndParent,
            int hMenu,
            int hInstance,
            IntPtr lpParam);

        /*
         * The DestroyWindow function destroys the specified window. 
         * The function sends WM_DESTROY and WM_NCDESTROY messages to the window 
         * to deactivate it and remove the keyboard focus from it. 
         * The function also destroys the window抯 menu, flushes the thread 
         * message queue, destroys timers, removes clipboard ownership,
         * and breaks the clipboard viewer chain (if the window is at the 
         * top of the viewer chain).		 
         *  
         */
        [DllImport("User32", SetLastError = true)]
        internal static extern int DestroyWindow(int hwnd);

        /*
         * The MoveWindow function changes the position and dimensions 
         * of the specified window. For a top-level window, the position and 
         * dimensions are relative to the upper-left corner of the screen. 
         */

        [DllImport("User32", SetLastError = true)]
        static extern int MoveWindow(
            int hwnd,
            int x,
            int y,
            int nWidth,
            int nHeight,
            int bRepaint);

        #endregion

        #region Structs

        /*
		 * The StructLayoutAttribute allows the user to control the physical 
		 * distribution of a struct or class fields.
		 */
        [StructLayout(LayoutKind.Sequential)]
        public struct TOOLINFO
        {
            public int lSize;
            public int lFlags;
            public int hwnd;
            public int lId;
            public RECT lprect;
            public int hInstance;
            public string lpStr;
            public int lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public int X;
            public int Y;

            public POINTAPI(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        #endregion

        public BalloonToolTip()
        {
            timer = new System.Timers.Timer();
            timer.AutoReset = false;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            mvarPopupOnDemand = true;
            mvarStyle = Styles.TTBalloon;
        }


        ~BalloonToolTip()
        {
            Destroy();
        }


        /// <summary>
        /// This method creates a completly new balloon, in terms of window handles.
        /// </summary>
        /// <param name="ParentHwnd">Handle of the parent control that will be associated to the new balloon</param>
        public void CreateToolTip(int ParentHwnd)
        {
            this.Hide();
            int ret;
            int lWinStyle = 0;
            if (m_lTTHwnd != 0)
                DestroyWindow(m_lTTHwnd);

            m_lParentHwnd = ParentHwnd;
            if (mvarStyle == Styles.TTBalloon)
                lWinStyle |= TTS_BALLOON;

            //creates the balloon
            m_lTTHwnd = CreateWindowEx(0, TOOLTIPS_CLASSA, string.Empty,
                lWinStyle, 0, 0, 0, 0, m_lParentHwnd, 0, 0, IntPtr.Zero);

            //now set our tooltip info structure
            if (mvarCentered)
            {
                if (!mvarPopupOnDemand)
                    ti.lFlags = TTF_IDISHWND | TTF_CENTERTIP | TTF_SUBCLASS;
                else
                    ti.lFlags = TTF_IDISHWND | TTF_CENTERTIP | TTF_TRACK;
            }
            else
            {
                if (!mvarPopupOnDemand)
                    ti.lFlags = TTF_IDISHWND | TTF_SUBCLASS;
                else
                    ti.lFlags = TTF_IDISHWND | TTF_TRACK | TTF_TRANSPARENT;
            }

            if (mvarABSPosn)
            {
                ti.lFlags |= (TTF_ABSOLUTE);
            }

            //set the hwnd prop to our parent control's hwnd
            ti.hwnd = m_lParentHwnd;
            ti.lId = m_lParentHwnd; //0
            ti.hInstance = 0;
            //ti.lpstr = ALREADY SET;
            //ti.lpRect = lpRect;
            ti.lSize = Marshal.SizeOf(ti);


            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    IntPtr ptrStruct = Marshal.AllocHGlobal(32 * Marshal.SizeOf(ti));
                    Marshal.StructureToPtr(ti, ptrStruct, false);// abc true
                    ret = SendMessage(m_lTTHwnd, TTM_ADDTOOL, 0, ptrStruct);
                    Marshal.FreeHGlobal(ptrStruct);
                    break;
                }
                catch { }
            }
            Title = mvarTitle;
            TipText = mvarTipText;
            if (mvarmaxWidth != 0) MaxWidth = mvarmaxWidth;
            if (mvarBackColor != 0) BackColor = Color.FromArgb(mvarBackColor);
            if (mvarForeColor != 0) ForeColor = Color.FromArgb(mvarForeColor);
            if (mvarVisibleTime != 0) VisibleTime = mvarVisibleTime;
            if (mvarDelayTime != 0) DelayTime = mvarDelayTime;
            if (mvarFont != null) TipFont = mvarFont;
        }

        /// <summary>
        /// Shows the BalloonTip in the align 
        /// </summary>
        /// <param name="align">
        /// Window Align that the Balloon will have
        /// </param>
        public void Show(BalloonAlignment align)
        {
            Alignment = align;
            Show();
        }

        /// <summary>
        /// This method will show the BalloonTip
        /// </summary>
        /// <remarks>
        /// If a delayTime has been stablished, the balloon will delay
        /// </remarks>
        public void Show()
        {
            System.Threading.Thread.Sleep(mvarDelayTime);


            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    IntPtr ptrStruct = Marshal.AllocHGlobal(32 * Marshal.SizeOf(ti));
                    Marshal.StructureToPtr(ti, ptrStruct, false);
                    SendMessage(m_lTTHwnd, TTM_TRACKACTIVATE, 1, ptrStruct);
                    Marshal.FreeHGlobal(ptrStruct);
                    break;
                }
                catch { }
            }
            if (mvarVisibleTime > 0 && !timer.Enabled)
            {//If this method is called several times during a small period of time, 
                //this action will interpret it and reset the timer and start the count again.
                timer.Interval += 1;
                timer.Interval -= 1;
                timer.Start();
            }
        }

        /// <summary>
        /// This method will show the BalloonTip in a specific point in the screen
        /// </summary>
        /// <param name="x">X-Coordinate in the screen</param>
        /// <param name="y">Y-Coordinate in the screen</param>
        public void Show(int x, int y)
        {
            mvarAlign = BalloonAlignment.Custom;
            Position = new Point(x, y);
            Show();
        }

        /// <summary>
        /// This method moves the Balloon to a specific point in the screen
        /// </summary>
        /// <param name="x">X-Coordinate in the screen</param>
        /// <param name="y">Y-Coordinate in the screen</param>
        public void Move(int x, int y)
        {
            RECT size = new RECT();
            mvarAlign = BalloonAlignment.Custom;
            GetClientRect(this.m_lTTHwnd, ref size);
            MoveWindow(this.m_lTTHwnd, x, y, size.right, size.bottom, 1);
        }

        /// <summary>
        /// This method hides the BalloonTip but does not destroys it
        /// </summary>
        public void Hide()
        {
            //try
            //{
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    IntPtr ptrStruct = Marshal.AllocHGlobal(32 * Marshal.SizeOf(ti));
                    Marshal.StructureToPtr(ti, ptrStruct, false);
                    SendMessage(m_lTTHwnd, TTM_TRACKACTIVATE, 0, ptrStruct);
                    Marshal.FreeHGlobal(ptrStruct);
                    break;
                }
                catch { }
            }
            //}
            //catch (Exception ex)
            //{
            //    Common.WriteLog.SetException(ex);
            //}
        }
        /// <summary>
        /// This method updates or refreshes the BalloonTip
        /// </summary>
        public void Refresh()
        {
            SendMessage(m_lTTHwnd, TTM_UPDATE, 0, 0);
        }

        /// <summary>
        /// This methods destroys and releases the memory used for the Balloon
        /// </summary>
        /// <remarks>
        /// Must always be called at the end of the application
        /// </remarks>
        public void Destroy()
        {
            if (m_lTTHwnd != 0)
                DestroyWindow(m_lTTHwnd);
        }


        private int MAKELONG(int loWord, int hiWord)
        { //USED to set the position in the screen (TTM_TRACKPOSITION Message)
            return (hiWord << 16) | (loWord & 0xffff);
        }


        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Hide();
            if (timerElapsed != null)
            {
                timerElapsed(this, EventArgs.Empty);
            }
            //Destroy(); //Doesn't Work ???? Remove Hide and the Balloon does not disappear.
            //It works on the form's button2 (Hide) why not here. Is it because it's inside the timer. 
            //(Another Thread, i guess)
        }
    }

    #region Enums

    public enum TooltipIcon
    {
        None,
        Info,
        Warning,
        Error
    }

    public enum Styles
    {
        TTStandard, //Shows a square window
        TTBalloon,  //Shows the balloon as you know it.
    }

    public enum BalloonAlignment
    {
        TopLeft,
        TopMiddle,
        TopRight,
        LeftMiddle,
        RightMiddle,
        BottomLeft,
        BottomMiddle,
        BottomRight,
        Custom
    }

    #endregion
}
