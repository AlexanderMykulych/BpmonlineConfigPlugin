using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings 
{
    class ExtractCs : BooleanSetting
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

        public ExtractCs(CheckBox control) : base(control) { }

        public override bool Read()
        {
            var includeDebugInformation = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"IncludeDebugInformation\"]",
                    "value");
            return (includeDebugInformation != null) && Convert.ToBoolean(includeDebugInformation);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"IncludeDebugInformation\"]", "value", ControlValue);
        }
    }
}
