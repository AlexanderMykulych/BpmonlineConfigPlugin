using System;
using Microsoft.Web.Administration;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Client.Extensions;
using Microsoft.Web.Management.Server;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineConfigUI : Module
    {
        public Connection Connection { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        protected override void Initialize(IServiceProvider serviceProvider, ModuleInfo moduleInfo)
        {
            base.Initialize(serviceProvider, moduleInfo);

            ServiceProvider = serviceProvider;
            Connection = (Connection)GetService(typeof(Connection));
            // Register UI elements
            var  controlPanel = (IControlPanel)GetService(typeof(IControlPanel));
            controlPanel.RegisterPage(new ModulePageInfo(this, typeof(BpmOnlineConfigUIPage),
               "Bpm'online", "Configuration of the bpm'online web site"));
            IExtensibilityManager extensibilityManager = (IExtensibilityManager)serviceProvider.GetService(typeof(IExtensibilityManager));
            if (extensibilityManager != null)
            {
                var homePageExtention = new BpmOnlineConfigHomepageExtension(this);
                extensibilityManager.RegisterExtension(typeof(IHomepageTaskListProvider), homePageExtention);
                var hierarchyProvider = new BpmOnlineConfigHierarchyProvider(this);
                extensibilityManager.RegisterExtension(typeof(HierarchyProvider), (object)hierarchyProvider);
            }
        }

        protected override bool IsPageEnabled(ModulePageInfo pageInfo)
        {
            ConfigurationPathType pathType = Connection.ConfigurationPath.PathType;
            return (pathType == ConfigurationPathType.Site) || (pathType == ConfigurationPathType.Application);
        }
    }
}
