using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class MaxEntityNameLength : IntegerSetting
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

        public MaxEntityNameLength(NumericUpDown control) : base(control) { }

        public override int Read()
        {
            return Convert.ToInt32(Site.SiteConfig.GetConfigParameterValue("terrasoft/db/general", "maxEntitySchemaNameLength"));
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.SiteConfig.SetConfigParameterValue("terrasoft/db/general", "maxEntitySchemaNameLength", ControlValue);
        }
    }
}
