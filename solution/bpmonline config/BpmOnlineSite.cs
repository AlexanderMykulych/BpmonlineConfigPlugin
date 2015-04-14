using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BpmOnlineConfig.Settings;
using Microsoft.Web.Administration;
using Application = Microsoft.Web.Administration.Application;

namespace BpmOnlineConfig
{
    public class BpmOnlineSite
    {
        #region Private: Fields

        public ServerManager ServerManager { get; set; }
        public Application BpmonlineApplication { get; set; }
        public string SiteName { get; set; }
        public string VirtualPath { get; set; }
        public ConfigFile SiteConfig { get; set; }
        public ConfigFile ApplicationConfig { get; set; }
        public ConfigFile ConnectionStringsConfig { get; set; }
        public ConfigFile Log4NetConfig { get; set; }

        #endregion

        #region Public: Constructor

        public BpmOnlineSite(ServerManager serverManager, string siteName, string virtualPath)
        {
            ServerManager = serverManager;
            SiteName = siteName;
            VirtualPath = virtualPath;
            var site = serverManager.Sites.FirstOrDefault(e => e.Name == siteName);
            if (site != null)
            {
                var rootApplication = site.Applications.FirstOrDefault(a => a.Path == "/");
                if (rootApplication == null)
                {
                    return;
                }
                var siteRootPath = GetApplicationPhisicalPath(rootApplication);
                if (!File.Exists(siteRootPath + @"\Web.config"))
                {
                    return;
                }
                SiteConfig = new ConfigFile(siteRootPath, "Web.config");
                ConnectionStringsConfig = new ConfigFile(siteRootPath, "ConnectionStrings.config");
                BpmonlineApplication = site.Applications.FirstOrDefault(a => a.Path != "/");
                if (BpmonlineApplication != null)
                {
                    ApplicationConfig = new ConfigFile(GetApplicationPhisicalPath(BpmonlineApplication), "Web.config");
                    Log4NetConfig = new ConfigFile(GetApplicationPhisicalPath(BpmonlineApplication), "log4net.config");
                }
            }
        } 

        #endregion

        private string GetApplicationPhisicalPath(Application application)
        {
            return application.VirtualDirectories[0].PhysicalPath;
        }
    }
}
