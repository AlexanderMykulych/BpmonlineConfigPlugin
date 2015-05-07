using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    public class WebSocketsPort : TextSetting
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

        public WebSocketsPort(TextBox control) : base(control) { }

        public override string Read()
        {
            var port = Site.ApplicationConfig.GetConfigParameterValue("terrasoft/wsService", "defaultPort");
            return (port == null) ? null : port.ToString();
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("terrasoft/wsService", "defaultPort", ControlValue);
        }
    }
}
