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
            return Site.ApplicationConfig.GetConfigParameterValue("terrasoft/wsService", "defaultPort").ToString();
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
