using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class JsPath : TextSetting
    {
        public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if (Site.ConnectionStringsConfig == null)
                {
                    return false;
                }
                return true;
            }
        }

        public JsPath(TextBox control) : base(control) { }

        public override string Read()
        {
            var path = Site.ConnectionStringsConfig.GetConfigParameterValue("add[@name=\"clientUnitContentPath\"]",
                "connectionString");
            return (path == null) ? null : path.ToString();
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ConnectionStringsConfig.SetConfigParameterValue("add[@name=\"clientUnitContentPath\"]", "connectionString", ControlValue);
        }
    }
}
