using System;
using System.Windows.Forms;

namespace BpmOnlineConfig.Settings.Base
{
    public abstract class IntegerSetting : BaseSetting
    {
        protected int ControlValue
        {
            get { return Convert.ToInt32((Control as NumericUpDown).Value); }
            set { (Control as NumericUpDown).Value = value; }
        }

        protected IntegerSetting(NumericUpDown control)  : base(control) { }

        public override void Show()
        {
            base.Show();
            if (IsAvailable)
            {
                ControlValue = Read();
            }
        }

        public abstract int Read();
        
    }
}
