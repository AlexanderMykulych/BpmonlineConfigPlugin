using System.Windows.Forms;

namespace BpmOnlineConfig.Settings.Base
{
    public abstract class TextSetting : BaseSetting
    {
        protected string ControlValue
        {
            get { return (Control as TextBox).Text; }
            set { (Control as TextBox).Text = value; }
        }

        protected TextSetting(TextBox control) : base(control) { }

        public override void Show()
        {
            base.Show();
            if (IsAvailable)
            {
                ControlValue = Read();
            }
        }

        public abstract string Read();
        
    }
}
