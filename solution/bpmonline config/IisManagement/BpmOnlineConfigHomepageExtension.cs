using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MethodTaskItemUsages usage = MethodTaskItemUsages.TaskList;
            /*if (selectedModulePage == null)
            {
                usage |= MethodTaskItemUsages.ContextMenu;
            }*/
            Connection connection = (Connection)serviceProvider.GetService(typeof(Connection));
            if (_lastConfigPath != connection.ConfigurationPath || _cachedTaskList == null)
            {
                _lastConfigPath = connection.ConfigurationPath;
                _cachedTaskList = new BpmOnlineHomepageTaskList(this, usage);
            }
            return _cachedTaskList;
        }
    }
}
