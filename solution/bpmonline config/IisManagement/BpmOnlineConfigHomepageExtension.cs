using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Client.Extensions;
using Microsoft.Web.Management.Server;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineConfigHomepageExtension : HomepageExtension
    {
        private ManagementConfigurationPath _lastConfigPath;
        private BpmOnlineHomepageTaskList _cachedTaskList;
        public BpmOnlineConfigUI Module;

        public BpmOnlineConfigHomepageExtension(BpmOnlineConfigUI module)
        {
            Module = module;
        }

        internal void ClearCache()
        {
            _lastConfigPath = null;
            _cachedTaskList = null;
        }

        protected override void OnRefresh()
        {
            ClearCache();
        }

        protected override TaskList GetTaskList(IServiceProvider serviceProvider, ModulePageInfo selectedModulePage)
        {
            var connection = (Connection)serviceProvider.GetService(typeof(Connection));
            var serverManager = new ServerManager();
            var siteName = connection.ConfigurationPath.SiteName;
            var virtualPath = connection.ConfigurationPath.ApplicationPath +
                              connection.ConfigurationPath.FolderPath;
            BpmOnlineSite site;
            try
            {
                site = new BpmOnlineSite(serverManager, siteName, virtualPath);
            }
            catch (Exception)
            {
                return null;
            }
            if (site.ConnectionStringsConfig == null)
            {
                return null;
            }
            if (_lastConfigPath != connection.ConfigurationPath || _cachedTaskList == null)
            {
                _lastConfigPath = connection.ConfigurationPath;
                _cachedTaskList = new BpmOnlineHomepageTaskList(this, MethodTaskItemUsages.TaskList, site);
            }
            return _cachedTaskList;
        }
    }
}
