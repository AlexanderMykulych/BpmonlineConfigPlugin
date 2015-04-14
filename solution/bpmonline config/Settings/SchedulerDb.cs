using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class SchedulerDb : BooleanSetting
    {
        protected const string schedulerConnectionName = "schedulerDb";
        protected const string schedulerApplicationEnding = "_Quartz";

        public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if (Site.ConnectionStringsConfig == null)
                {
                    return false;
                }
                if (Site.SiteConfig == null)
                {
                    return false;
                }
                return true;
            }
        }

        public SchedulerDb(CheckBox control) : base(control) { }

        public override bool Read()
        {
            var schedulerConnection = Site.ConnectionStringsConfig.GetConfigParameterValue(
                string.Format("add[@name=\"{0}\"]", schedulerConnectionName),
                "connectionString");
            return (schedulerConnection != null);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            var dbConnectionStringName = 
                Site.SiteConfig.GetConfigParameterValue("terrasoft/db/general", "connectionStringName") ?? "db";
            var connectionStringXPath = string.Format("add[@name=\"{0}\"]", dbConnectionStringName);
            var schedulerConnectionStringXPath = string.Format("add[@name=\"{0}\"]", schedulerConnectionName);
            if (ControlValue)
            {
                AddSchedulerConnectionString(connectionStringXPath, schedulerConnectionStringXPath);
            }
            else
            {
                Site.ConnectionStringsConfig.RemoveConfigSection("connectionStrings/" + schedulerConnectionStringXPath);
            }

            Site.SiteConfig.SetConfigParameterValue("quartz/add[@key=\"quartz.dataSource.SchedulerDb.connectionStringName\"]",
                "value", (ControlValue ? schedulerConnectionName : dbConnectionStringName), true);
        }

        private void AddSchedulerConnectionString(string connectionStringXPath, string schedulerConnectionStringXPath)
        {
            var connectionStringText =
                Site.ConnectionStringsConfig.GetConfigParameterValue(connectionStringXPath, "connectionString")
                    .ToString();
            var connectionString = new ConnectionString(connectionStringText);
            var applicationName = connectionString.GetAttribute("Application Name") ?? string.Empty;
            connectionString.SetAttribute("Application Name", applicationName + schedulerApplicationEnding);
            Site.ConnectionStringsConfig.SetConfigParameterValue(schedulerConnectionStringXPath, "connectionString",
                connectionString.ToString(), true);
        }
    }
}
