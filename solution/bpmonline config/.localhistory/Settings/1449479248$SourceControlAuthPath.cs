using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class SourceControlAuthPath : TextSetting
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
                if (Read() == null)
                {
                    return false;
                }
                return true;
            }
        }

        public SourceControlAuthPath(TextBox control) : base(control) { }

        public override string Read()
        {
            var path = Site.ConnectionStringsConfig.GetConfigParameterValue("add[@name=\"defPackagesWorkingCopyPath\"]",
                "connectionString");
            return (path == null) ? null : path.ToString();
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ConnectionStringsConfig.SetConfigParameterValue("add[@name=\"defPackagesWorkingCopyPath\"]", "connectionString", ControlValue);
        }
    }
}
