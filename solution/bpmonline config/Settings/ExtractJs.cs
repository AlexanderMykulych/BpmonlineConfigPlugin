using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class ExtractJs : BooleanSetting
    {
        public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if (Site.SiteConfig == null)
                {
                    return false;
                }
                return true;
            }
        }

        public ExtractJs(CheckBox control) : base(control) { }

        public override bool Read()
        {
            var useFileContent = Site.SiteConfig.GetConfigParameterValue("terrasoft/resources/clientUnits",
                    "useFileContent");
            return (useFileContent != null) && Convert.ToBoolean(useFileContent);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.SiteConfig.SetConfigParameterValue("terrasoft/resources/clientUnits", "useFileContent", ControlValue);
        }
    }
}
