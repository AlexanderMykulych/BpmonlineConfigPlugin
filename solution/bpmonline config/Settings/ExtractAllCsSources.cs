using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class ExtractAllCsSources : BooleanSetting
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

        public ExtractAllCsSources(CheckBox control) : base(control) { }

        public override bool Read()
        {
            var extractAllCompilerSources = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"ExtractAllCompilerSources\"]",
                    "value");
            return (extractAllCompilerSources != null) && Convert.ToBoolean(extractAllCompilerSources);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"ExtractAllCompilerSources\"]", "value", ControlValue);
        }
    }
}
