using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class UseFlatPackage : BooleanSetting
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

        public UseFlatPackage(CheckBox control) : base(control) { }

        public override bool Read()
        {
            var extractAllCompilerSources = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"UseFlatPackage\"]",
                    "value");
            return (extractAllCompilerSources != null) && Convert.ToBoolean(extractAllCompilerSources);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"UseFlatPackage\"]", "value", ControlValue);
        }
    }
}

