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

        public BpmOnlineConfigHierarchyProvider(BpmOnlineConfigUI owner)
          : base((IServiceProvider) owner)
        {
            _owner = owner;
        }

        public override TaskList GetTasks(HierarchyInfo item)
        {
			var connection = (Connection)_owner.ServiceProvider.GetService(typeof(Connection));
	        var a = ((Microsoft.Web.Management.Iis.WebObjects.WebObjectsHierarchyProvider.ServerContentInfo) (item)).NavigatorPath;
			var siteName = connection.ConfigurationPath.SiteName;
			var virtualPath = connection.ConfigurationPath.ApplicationPath +
							  connection.ConfigurationPath.FolderPath;
			if (string.Equals(item.NodeType, HierarchyInfo.ServerConnection, StringComparison.Ordinal))
            {
                // Server task list   
            }
            if (string.Equals(item.NodeType, HierarchyInfo.Site, StringComparison.Ordinal) ||
                string.Equals(item.NodeType, HierarchyInfo.Application, StringComparison.Ordinal))
            {
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
