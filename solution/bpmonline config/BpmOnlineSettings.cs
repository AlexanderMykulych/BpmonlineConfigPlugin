using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BpmOnlineConfig.Settings;
using BpmOnlineConfig.Settings.Base;
using Microsoft.Web.Administration;
using Application = Microsoft.Web.Administration.Application;

namespace BpmOnlineConfig
{
    class BpmOnlineSettings
    {
        #region Private: Fields

        protected BpmOnlineSite Site { get; set; }

        #endregion

        #region Public: Properties

        public List<BaseSetting> settings;

        #endregion

        #region Public: Constructor
        public BpmOnlineSettings(BpmOnlineSite site)
        {
            Site = site;
            settings = new List<BaseSetting>();
        } 
        #endregion

        #region Public: Methods

        public void Save()
        {
            foreach (var setting in settings.Where(item => item.IsAvailable))
            {
                setting.Save();
            }

            Site.ServerManager.CommitChanges();
            if (Site.SiteConfig != null)
            {
                Site.SiteConfig.Save();
            }
            if (Site.ApplicationConfig != null)
            {
                Site.ApplicationConfig.Save();
            }
            if (Site.ConnectionStringsConfig != null)
            {
                Site.ConnectionStringsConfig.Save();
            }
        }

        public void Show()
        {
            foreach (var setting in settings)
            {
                setting.Show();
            }
        }

        public void Add(BaseSetting setting)
        {
            setting.SetSite(Site);
            settings.Add(setting);
        }

        #endregion
    }
}
