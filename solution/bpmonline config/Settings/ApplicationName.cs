using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class ApplicationName : TextSetting
    {
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
                return true;
            }
        }

        public ApplicationName(TextBox control) : base(control) { }

        public override string Read()
        {
            var connectionStringText = Site.ConnectionStringsConfig.GetConfigParameterValue("add[@name=\"db\"]", "connectionString").ToString();
            var connectionString = new ConnectionString(connectionStringText);
            return connectionString.GetAttribute("Application Name");
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
            var connectionStringText = Site.ConnectionStringsConfig.GetConfigParameterValue(connectionStringXPath, "connectionString").ToString();
            var connectionString = new ConnectionString(connectionStringText);
            connectionString.SetAttribute("Application Name", ControlValue);
            Site.ConnectionStringsConfig.SetConfigParameterValue("add[@name=\"db\"]", "connectionString", connectionString.ToString());
        }
    }
}
