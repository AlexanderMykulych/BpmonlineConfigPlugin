using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class LogPath : TextSetting
    {
        public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if (Site.Log4NetConfig == null)
                {
                    return false;
                }
                return true;
            }
        }

        public LogPath(TextBox control) : base(control) { }

        public override string Read()
        {
            var path = Site.Log4NetConfig.GetConfigParameterValue(
                "appender/file[@type=\"log4net.Util.PatternString\"]/conversionPattern", "value");
            return (path == null) ? null : path.ToString();
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.Log4NetConfig.SetConfigParametersValue(
                "appender/file[@type=\"log4net.Util.PatternString\"]/conversionPattern", "value", ControlValue);
        }
    }
}
