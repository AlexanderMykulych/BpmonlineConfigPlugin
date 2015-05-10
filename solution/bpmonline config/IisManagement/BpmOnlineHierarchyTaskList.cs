using System;
using System.Collections;
using BpmOnlineConfig.Maintenance;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Client.Win32;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineHierarchyTaskList : TaskList
    {
        private BpmOnlineConfigUI _module;
        private BpmOnlineSite _site;

        public BpmOnlineHierarchyTaskList(BpmOnlineConfigUI module, BpmOnlineSite site)
        {
          _site = site;
          _module = module;
        }

        public override ICollection GetTaskItems()
        {
            Connection connection = (Connection)this._module.ServiceProvider.GetService(typeof(Connection));
            var arrayList = new ArrayList();
            if (connection.IsLocalConnection)
            {
                //arrayList.Add(new TextTaskItem("Redis", "Redis", true));
                var taskItem = new MethodTaskItem("FlushRedisTask", "Flush Redis DB", "Browse", String.Empty, image: null)
                {
                    Usage = MethodTaskItemUsages.ContextMenu
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
