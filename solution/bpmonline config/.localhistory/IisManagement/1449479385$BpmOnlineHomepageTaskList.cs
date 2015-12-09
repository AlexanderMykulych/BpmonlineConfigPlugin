using System;
using System.Collections;
using BpmOnlineConfig.Maintenance;
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
        private BpmOnlineSite _site;

        public BpmOnlineHomepageTaskList(BpmOnlineConfigHomepageExtension owner, MethodTaskItemUsages usage, BpmOnlineSite site)
        {
          _usage = usage;
          _owner = owner;
          _site = site;
          _module = _owner.Module;
          _connection = _module.Connection;
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
                ShowError(ex);
            }
            return arrayList;
        }

        private ArrayList GetSiteTaskItems()
        {
            var arrayList = new ArrayList();
            if (_connection.IsLocalConnection)
            {
                arrayList.Add(new TextTaskItem("Redis", "Redis", true));
                var taskItem = new MethodTaskItem("FlushRedisTask", "Flush DB", "Redis", String.Empty, image: null)
                {
                    Usage = _usage
                };
                arrayList.Add(taskItem);
            }
            return arrayList;
        }

        private void ShowError(Exception ex)
        {
            var managementUiService = (IManagementUIService)_module.ServiceProvider.GetService(typeof(IManagementUIService));
            if (managementUiService == null)
            {
                return;
            }
            managementUiService.ShowError(ex, string.Empty, string.Empty, false);
        }

        private void ShowMessage(string text, string caption)
        {
            var managementUiService = (IManagementUIService)_module.ServiceProvider.GetService(typeof(IManagementUIService));
            if (managementUiService == null)
            {
                return;
            }
            managementUiService.ShowMessage(text, caption);
        }

        public void FlushRedisTask()
        {
            try
            {
                using (var redis = new Redis(_site))
                {
                    redis.Connect();
                    redis.FlushCurrentSiteDb();
                    const string messageTemplate = "Server {0}. Db #{1} was succesfully flushed";
                    var message = string.Format(messageTemplate, redis.ServerConnectionString, redis.Db);
                    ShowMessage(message, "Flushing the Redis");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
