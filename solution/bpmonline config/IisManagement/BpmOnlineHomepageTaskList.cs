using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Client.Win32;
using Microsoft.Web.Management.Server;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineHomepageTaskList : TaskList
    {
        private MethodTaskItemUsages _usage;
        private BpmOnlineConfigHomepageExtension _owner;
        private BpmOnlineConfigUI _module;
        private Connection _connection;

        public BpmOnlineHomepageTaskList(BpmOnlineConfigHomepageExtension owner, MethodTaskItemUsages usage)
        {
          _usage = usage;
          _owner = owner;
          _module = _owner.Module;
          _connection = _module.Connection;
          /*this._scope = this._owner._scope;
          this._connection = (Connection) this._module.GetService(typeof (Connection));
          this._currentObjectBag = new PropertyBag();
          this._isWebSiteExpanded = true;
          this._isWebAppExpanded = true;
          this._isVirtualDirectoryExpanded = true;
          this._isFileOrFolderExpanded = true;*/
        }

        public override ICollection GetTaskItems()
        {
            var arrayList = new ArrayList();
            try
            {
                switch (_connection.ConfigurationPath.PathType)
                {
                    case ConfigurationPathType.Server:
                        break;
                    case ConfigurationPathType.Site:
                        arrayList = GetSiteTaskItems();
                        break;
                    case ConfigurationPathType.Application:
                        break;
                }
            }
            catch (Exception ex)
            {
                IManagementUIService managementUiService = (IManagementUIService)_module.ServiceProvider.GetService(typeof(IManagementUIService));
                if (managementUiService == null)
                {
                    return arrayList;
                }
                managementUiService.ShowError(ex, ex.Message, string.Empty, false);
            }
            return arrayList;
        }

        private ArrayList GetSiteTaskItems()
        {
            ArrayList arrayList = new ArrayList();
            if (_connection.IsLocalConnection)
            {
                arrayList.Add(new TextTaskItem("Redis", "Redis", true));
                var taskItem = new MethodTaskItem("FlushRedisTask", "Flush", "Redis", String.Empty, image: null)
                {
                    Usage = _usage
                };
                arrayList.Add(taskItem);
            }
            return arrayList;
        }

        public void FlushRedisTask()
        {
            // TODO: Flush redis here
        }
    }
}
