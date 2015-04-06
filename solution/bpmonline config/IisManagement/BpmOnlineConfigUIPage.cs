using BpmOnlineConfig.IisManagement;
using Microsoft.Web.Administration;
using Microsoft.Web.Management.Client.Win32;

namespace BpmOnlineConfig
{
    class BpmOnlineConfigUIPage : ModulePage
    {
        private ServerManager serverManager;
        private BpmonlineConfiguration configurationWindow;

        public BpmOnlineConfigUIPage()
        {
            serverManager = new ServerManager();
            configurationWindow = new BpmonlineConfiguration(serverManager);

            Controls.Add(configurationWindow);
        }

        protected override void OnActivated(bool initialActivation)
        {
            base.OnActivated(initialActivation);

            if (initialActivation)
            {
                configurationWindow.Initialize(Connection.ConfigurationPath.SiteName,
                    Connection.ConfigurationPath.ApplicationPath +
                    Connection.ConfigurationPath.FolderPath);
            }
        }
    }
}
