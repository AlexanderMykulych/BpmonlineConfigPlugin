using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;
namespace BpmOnlineConfig.Settings {
	public class UseIncludeDependenciesSource : BooleanSetting
	{

		public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if (Site.ApplicationConfig == null)
                {
                    return false;
                }
                return true;
            }
        }

		public UseIncludeDependenciesSource(CheckBox control) : base(control) {
		}

        public override bool Read()
        {
            var separatedJsFiles = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"SeparatedJsFiles\"]",
                "value");
            return (separatedJsFiles != null) && Convert.ToBoolean(separatedJsFiles);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"SeparatedJsFiles\"]", "value", ControlValue, true);
        }

	}
}