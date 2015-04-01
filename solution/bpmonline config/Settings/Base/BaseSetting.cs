using System.Windows.Forms;

namespace BpmOnlineConfig.Settings.Base
{
    public abstract class BaseSetting
    {
        #region Protected: Fields

        protected BpmOnlineSite Site { get; set; }
        protected Control Control { get; set; }

        #endregion

        protected BaseSetting(Control control)
        {
            Control = control;
        }

        #region Public: Properties

        public virtual bool IsAvailable
        {
            get
            {
                if (Site == null)
                {
                    return false;
                }
                return true;
            }
        } 

        #endregion

        #region Public: Methods

        public virtual void Show()
        {
            Control.Enabled = IsAvailable;
        }

        public abstract void Save();

        public virtual void SetSite(BpmOnlineSite site)
        {
            Site = site;
        }

        #endregion
    }
}
