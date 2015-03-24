using System;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Server;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineConfigUI : Module
    {
        protected override void Initialize(IServiceProvider serviceProvider, Microsoft.Web.Management.Server.ModuleInfo moduleInfo)
        {
            base.Initialize(serviceProvider, moduleInfo);

            IControlPanel controlPanel = (IControlPanel)GetService(typeof(IControlPanel));
            controlPanel.RegisterPage(new ModulePageInfo(this, typeof(BpmOnlineConfigUIPage),
               "Bpm'online", "Configuration of the bpm'online web site"));
        }

        protected override bool IsPageEnabled(ModulePageInfo pageInfo)
        {
            Connection conn = (Connection)GetService(typeof(Connection));
            ConfigurationPathType pt = conn.ConfigurationPath.PathType;
            return pt == ConfigurationPathType.Site || pt == ConfigurationPathType.Application;
        }
    }
}
