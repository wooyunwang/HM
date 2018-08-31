using MetroFramework.Components;
using MetroFramework.Interfaces;
using MetroFramework.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace HM.Form_
{
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract class MetroDataGridViewBase : DataGridView,
         IMetroControl, IMetroStyledComponent
    {
        /**************************************************************************************
									GENERATED FILE - DO NOT EDIT
		 **************************************************************************************/

        #region Fields, Constructor & IDisposable

        protected readonly MetroStyleManager _styleManager;

        protected MetroDataGridViewBase()
        {
            _styleManager = new MetroStyleManager();
            _styleManager.MetroStyleChanged += NotifyMetroStyleChanged;
        }

#if DEBUG
        private bool _controlWasPainted;
#endif

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
#if DEBUG
                Debug.WriteLineIf(!_controlWasPainted, GetType().Name + ": never received OnPaint() event.");
#endif
                _styleManager.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        [Browsable(false)]
        public event PaintEventHandler UserPaint;

        protected override void OnPaint(PaintEventArgs e)
        {
#if DEBUG
            _controlWasPainted = true;
#endif
            try
            {
                //Debug.WriteLine(Name + ": OnPaint: " + e.ClipRectangle);
                if (GetStyle(ControlStyles.AllPaintingInWmPaint)) OnPaintBackground(e);
                OnPaintForeground(e);
                if (GetStyle(ControlStyles.UserPaint))
                {
                    var ev = UserPaint;
                    if (ev != null) ev(this, e);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        #region Style Manager Interface

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        MetroStyleManager IMetroStyledComponent.InternalStyleManager
        {
            get { return _styleManager; }
            // NOTE: we don't replace our style manager, but instead assign the style manager a new manager
            set { ((IMetroStyledComponent)_styleManager).InternalStyleManager = value; /* no need to Invalidate() here */ }
        }

        // Event handler for our style manager's updates
        // NOTE: The event may have been triggered from a different thread.
        private void NotifyMetroStyleChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new Action<EventArgs>(OnMetroStyleChanged), e);
            else
                OnMetroStyleChanged(e);
        }

        protected virtual void OnMetroStyleChanged(EventArgs e)
        {
            //_effectiveFont = _styleManager.Theme.ToFont();
            Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            OnMetroStyleChanged(e);
        }

        // Override Site property to set the style manager into design mode, too.
        public override ISite Site
        {
            get { return base.Site; }
            set { base.Site = _styleManager.Site = value; }
        }

        #endregion

        //private Font _effectiveFont;
        //protected virtual Font EffectiveFont
        //{
        //    get { return _effectiveFont; }
        //}
    }
}
