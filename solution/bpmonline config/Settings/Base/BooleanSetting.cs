using System.Windows.Forms;

namespace BpmOnlineConfig.Settings.Base
{
    public abstract class BooleanSetting : BaseSetting
    {
        protected bool ControlValue
        {
            get { return (Control as CheckBox).Checked;  }
            set { (Control as CheckBox).Checked = value; }
        }

        protected BooleanSetting(CheckBox control) : base(control) { }

        public override void Show()
        {
            base.Show();
            if (IsAvailable)
            {
                ControlValue = Read();
            }
        }

        public abstract bool Read();
        
    }
}
