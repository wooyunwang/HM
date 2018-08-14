using MetroFramework.Controls;

namespace HM.Form_
{
    public class HMUserControl : MetroUserControl
    {
        public MetroFramework.Components.MetroStyleManager _Msm { get; set; }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HMUserControl));
            this.SuspendLayout();
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.ResumeLayout(false);
        }
        public HMUserControl() : base()
        {
            this._Msm = new MetroFramework.Components.MetroStyleManager();
            this._Msm.Owner = this;

        }

        protected override void OnCreateControl()
        {
            _Msm.Theme = MetroFramework.MetroThemeStyle.Light;
            base.OnCreateControl();
        }
    }
}
