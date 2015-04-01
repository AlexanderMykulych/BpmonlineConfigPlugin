using System;
using System.Linq;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class SessionTimeOutMinutes : IntegerSetting
    {
        public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if ((Site.SiteConfig == null) || (Site.ApplicationConfig == null))
                {
                    return false;
                }
                return true;
            }
        }

        public SessionTimeOutMinutes(NumericUpDown control) : base(control) { }

        public override int Read()
        {
            var timeout = Site.SiteConfig.GetConfigParameterValue("location[@path=\".\"]/system.web/sessionState",
                    "timeout");
            if (timeout == null)
            {
                return 0;
            }
            return Convert.ToInt32(timeout);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            var pool =
                Site.ServerManager.ApplicationPools.FirstOrDefault(
                    ap => ap.Name == Site.BpmonlineApplication.ApplicationPoolName);
            var timeSpan = new TimeSpan(0, ControlValue, 0);
            if (pool != null)
            {
                pool.ProcessModel.IdleTimeout = timeSpan;
            }
            Site.SiteConfig.SetConfigParameterValue("location[@path=\".\"]/system.web/authentication/forms",
                "timeout", (ControlValue - 1)); // Authentication parameter should be less then session
            Site.SiteConfig.SetConfigParameterValue("location[@path=\".\"]/system.web/sessionState",
                "timeout", ControlValue);
            Site.ApplicationConfig.SetConfigParameterValue("location[@path=\".\"]/system.web/authentication/forms",
                "timeout", (ControlValue - 1));
        }
    }
}
