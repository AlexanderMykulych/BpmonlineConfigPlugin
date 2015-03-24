using System;
using System.Linq;
using Microsoft.Web.Administration;

namespace BpmOnlineConfig
{
    class BpmOnlineSettings
    {
        #region Private: Fields
        private ServerManager serverManager;
        private Application bpmonlineApplication;
        private string siteName;
        private string virtualPath;
        private ConfigFile siteConfig;
        private ConfigFile applicationConfig;
        private ConfigFile connectionStringsConfig;
        #endregion

        #region Public: Constructor
        public BpmOnlineSettings(ServerManager serverManager, string siteName, string virtualPath)
        {
            this.serverManager = serverManager;
            this.siteName = siteName;
            this.virtualPath = virtualPath;
            var site = serverManager.Sites.FirstOrDefault(e => e.Name == siteName);
            if (site != null)
            {
                var rootApplication = site.Applications.FirstOrDefault(a => a.Path == "/");
                var siteRootPath = GetApplicationPhisicalPath(rootApplication);
                siteConfig = new ConfigFile(siteRootPath, "Web.config");
                connectionStringsConfig = new ConfigFile(siteRootPath, "ConnectionStrings.config");
                bpmonlineApplication = site.Applications.FirstOrDefault(a => a.Path != "/");
                applicationConfig = new ConfigFile(GetApplicationPhisicalPath(bpmonlineApplication), "Web.config");
            }
        } 
        #endregion

        private string GetApplicationPhisicalPath(Application application)
        {
            return application.VirtualDirectories[0].PhysicalPath;
        }

        #region Public: Properties

        public string WebSocketsPort
        {
            get
            {
                return (applicationConfig == null) ? null : applicationConfig.GetConfigParameterValue("terrasoft/wsService", "defaultPort").ToString();
            }
            set
            {
                if (value == WebSocketsPort)
                {
                    return;
                }
                applicationConfig.SetConfigParameterValue("terrasoft/wsService", "defaultPort", value);
            }
        }

        public int MaxEntityNameLength
        {
            get
            {
                return Convert.ToInt32(siteConfig.GetConfigParameterValue("terrasoft/db/general", "maxEntitySchemaNameLength"));
            }
            set
            {
                if (value == MaxEntityNameLength)
                {
                    return;
                }
                siteConfig.SetConfigParameterValue("terrasoft/db/general", "maxEntitySchemaNameLength", value);
            }
        }

        public int SessionTimeOutMinutes
        {
            get
            {
                var timeout = siteConfig.GetConfigParameterValue("location[@path=\".\"]/system.web/sessionState",
                    "timeout");
                if (timeout == null)
                {
                    return 0;
                }
                return Convert.ToInt32(timeout);
            }
            set
            {
                if (value == SessionTimeOutMinutes)
                {
                    return;
                }
                var pool =
                    serverManager.ApplicationPools.FirstOrDefault(
                        ap => ap.Name == bpmonlineApplication.ApplicationPoolName);
                var timeSpan = new TimeSpan(0, value, 0);
                if (pool != null)
                {
                    pool.ProcessModel.IdleTimeout = timeSpan;
                }
                siteConfig.SetConfigParameterValue("location[@path=\".\"]/system.web/authentication/forms",
                    "timeout", (value - 1)); // Authentication parameter should be less then session
                siteConfig.SetConfigParameterValue("location[@path=\".\"]/system.web/sessionState",
                    "timeout", value);
                applicationConfig.SetConfigParameterValue("location[@path=\".\"]/system.web/authentication/forms",
                    "timeout", (value - 1));
            }
        }

        public bool ExtractJs
        {
            get
            {
                var useFileContent = siteConfig.GetConfigParameterValue("terrasoft/resources/clientUnits",
                    "useFileContent");
                return (useFileContent != null) && Convert.ToBoolean(useFileContent);
            }
            set
            {
                if (value == ExtractJs)
                {
                    return;
                }
                siteConfig.SetConfigParameterValue("terrasoft/resources/clientUnits", "useFileContent", value);
            }
        }

        public string JsPath
        {
            get
            {
                var path = connectionStringsConfig.GetConfigParameterValue("add[@name=\"clientUnitContentPath\"]",
                    "connectionString");
                return (path == null) ? null : path.ToString();
            }
            set
            {
                if (value == JsPath)
                {
                    return;
                }
                connectionStringsConfig.SetConfigParameterValue("add[@name=\"clientUnitContentPath\"]", "connectionString", value);
            }
        }

        public bool UncompressedCoreJs
        {
            get
            {
                var separatedJsFiles = applicationConfig.GetConfigParameterValue("appSettings/add[@key=\"SeparatedJsFiles\"]",
                    "value");
                return (separatedJsFiles != null) && Convert.ToBoolean(separatedJsFiles);
            }
            set
            {
                if (value == UncompressedCoreJs)
                {
                    return;
                }
                applicationConfig.SetConfigParameterValue("appSettings/add[@key=\"SeparatedJsFiles\"]", "value", value, true);
            }
        }

        public bool ExtractCs
        {
            get
            {
                var includeDebugInformation = applicationConfig.GetConfigParameterValue("appSettings/add[@key=\"IncludeDebugInformation\"]",
                    "value");
                return (includeDebugInformation != null) && Convert.ToBoolean(includeDebugInformation);
            }
            set
            {
                if (value == ExtractCs)
                {
                    return;
                }
                applicationConfig.SetConfigParameterValue("appSettings/add[@key=\"IncludeDebugInformation\"]", "value", value);
            }
        }

        public string CsPath
        {
            get
            {
                var path = applicationConfig.GetConfigParameterValue("appSettings/add[@key=\"CompilerSourcesTempFolderPath\"]",
                    "value");
                return (path == null) ? null : path.ToString();
            }
            set
            {
                if (value == CsPath)
                {
                    return;
                }
                applicationConfig.SetConfigParameterValue("appSettings/add[@key=\"CompilerSourcesTempFolderPath\"]", "value", value);
            }
        }

        public bool ExtractAllCsSources
        {
            get
            {
                var extractAllCompilerSources = applicationConfig.GetConfigParameterValue("appSettings/add[@key=\"ExtractAllCompilerSources\"]",
                    "value");
                return (extractAllCompilerSources != null) && Convert.ToBoolean(extractAllCompilerSources);
            }
            set
            {
                if (value == ExtractAllCsSources)
                {
                    return;
                }
                applicationConfig.SetConfigParameterValue("appSettings/add[@key=\"ExtractAllCompilerSources\"]", "value", value);
            }
        }

        #endregion

        #region Public: Methods

        public void Save()
        {
            serverManager.CommitChanges();
            siteConfig.Save();
            applicationConfig.Save();
            connectionStringsConfig.Save();
        }

        #endregion
    }
}
