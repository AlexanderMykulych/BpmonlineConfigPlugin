using Microsoft.Web.Administration;
using Microsoft.Web.Management.Client.Win32;

namespace BpmOnlineConfig
{
    class BpmOnlineConfigUIPage : ModulePage
    {
        private ServerManager mgr;
        private BpmonlineConfiguration c;

        public BpmOnlineConfigUIPage()
        {
            mgr = new ServerManager();
            c = new BpmonlineConfiguration(mgr);

            Controls.Add(c);
        }

        protected override void OnActivated(bool initialActivation)
        {
            base.OnActivated(initialActivation);

            if (initialActivation)
                c.Initialize(Connection.ConfigurationPath.SiteName,
                             Connection.ConfigurationPath.ApplicationPath +
                             Connection.ConfigurationPath.FolderPath);
        }
    }
}
