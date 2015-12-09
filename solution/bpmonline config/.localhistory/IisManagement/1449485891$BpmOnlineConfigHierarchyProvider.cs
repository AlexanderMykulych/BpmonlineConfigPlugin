using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;
using Microsoft.Web.Management.Client;
using Microsoft.Web.Management.Server;

namespace BpmOnlineConfig.IisManagement
{
    class BpmOnlineConfigHierarchyProvider : HierarchyProvider
    {
        private BpmOnlineConfigUI _owner;

		private string GetApplicationPath(HierarchyInfo item, string currentApplicationPath) {
			if (string.Equals(item.NodeType, HierarchyInfo.Site, StringComparison.Ordinal)) {
				return currentApplicationPath;
			}
		}

		private string GetSiteName(HierarchyInfo item) {
			if (string.Equals(item.NodeType, HierarchyInfo.Site, StringComparison.Ordinal)) {
				return item.Text;
			}
			return GetSiteName(item.Parent);
		}

        public BpmOnlineConfigHierarchyProvider(BpmOnlineConfigUI owner)
          : base((IServiceProvider) owner)
        {
            _owner = owner;
        }

        public override TaskList GetTasks(HierarchyInfo item)
        {
			if (string.Equals(item.NodeType, HierarchyInfo.ServerConnection, StringComparison.Ordinal))
            {
                // Server task list   
            }
            if (string.Equals(item.NodeType, HierarchyInfo.Site, StringComparison.Ordinal) ||
                string.Equals(item.NodeType, HierarchyInfo.Application, StringComparison.Ordinal)) {
				var siteName = GetSiteName(item);
				var virtualPath = GetApplicationPath(item, "/" + item.Text);
                var serverManager = new ServerManager();
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
                return (TaskList)new BpmOnlineHierarchyTaskList(_owner, site); 
            }
            /*if (string.Equals(item.NodeType, HierarchyInfo.Application, StringComparison.Ordinal))
            {
                // Application task list
            }*/
            return (TaskList) null;
        }

	    public override HierarchyInfo[] GetChildren(HierarchyInfo item)
        {
            return (HierarchyInfo[])null;
        }
    }
}
