using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class CsPath : TextSetting
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

        public CsPath(TextBox control) : base(control) { }

        public override string Read()
        {
            var path = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"CompilerSourcesTempFolderPath\"]",
                "value");
            return (path == null) ? null : path.ToString();
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"CompilerSourcesTempFolderPath\"]", "value", ControlValue);
        }
    }
}
