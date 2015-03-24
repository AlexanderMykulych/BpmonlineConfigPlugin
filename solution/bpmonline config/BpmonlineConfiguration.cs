using System;
using System.Windows.Forms;
using Microsoft.Web.Administration;

namespace BpmOnlineConfig
{
    public partial class BpmonlineConfiguration : UserControl
    {
        private ServerManager serverManager;
        private BpmOnlineSettings settings;

        public BpmonlineConfiguration(ServerManager serverManager)
        {
            this.serverManager = serverManager;
            InitializeComponent();
        }

        public void Initialize(string siteName, string virtualPath)
        {
            settings = new BpmOnlineSettings(this.serverManager, siteName, virtualPath);
            ReadSettings();
            UpdateControlsByExtractJSFlug();
            UpdateControlsByExtractCSFlug();
        }

        #region Private: Methods

        private void ReadSettings()
        {
            edtSessionTimeOut.Value = settings.SessionTimeOutMinutes;
            edtWebSocketsPort.Text = settings.WebSocketsPort;
            edtMaxEntityNameLength.Value = settings.MaxEntityNameLength;
            chbExtractJS.Checked = settings.ExtractJs;
            edtJSPath.Text = settings.JsPath;
            chbUncompressedJS.Checked = settings.UncompressedCoreJs;
            chbExtractCS.Checked = settings.ExtractCs;
            chbExtractAllCSSources.Checked = settings.ExtractAllCsSources;
            edtCSPath.Text = settings.CsPath;
        }

        private void UpdateControlsByExtractJSFlug()
        {
            var isChecked = chbExtractJS.Checked;
            edtJSPath.Enabled = isChecked;
            btnBrowseJSPath.Enabled = isChecked;
        }

        private void UpdateControlsByExtractCSFlug()
        {
            var isChecked = chbExtractCS.Checked;
            chbExtractAllCSSources.Enabled = isChecked;
            edtCSPath.Enabled = isChecked;
            btnBrowseCSPath.Enabled = isChecked;
        }

        private static string GetSelectedPath(string path)
        {
            path = path.TrimEnd('\\');
            return path + @"\%WORKSPACE%";
        }

        private static string GetPathForBrowserDialog(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            var indexOfPercent = path.IndexOf('%');
            return (indexOfPercent < 0) ? path : path.Substring(0, indexOfPercent);
        } 

        #endregion

        #region Private: PageControlsEvents

        private void chbExtractCS_Click(object sender, EventArgs e)
        {
            UpdateControlsByExtractCSFlug();
        }

        private void chbExtractJS_Click(object sender, EventArgs e)
        {
            UpdateControlsByExtractJSFlug();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            settings.SessionTimeOutMinutes = Convert.ToInt32(edtSessionTimeOut.Value);
            settings.WebSocketsPort = edtWebSocketsPort.Text;
            settings.MaxEntityNameLength = Convert.ToInt32(edtMaxEntityNameLength.Value);
            settings.ExtractJs = chbExtractJS.Checked;
            settings.JsPath = edtJSPath.Text;
            settings.UncompressedCoreJs = chbUncompressedJS.Checked;
            settings.ExtractCs = chbExtractCS.Checked;
            settings.ExtractAllCsSources = chbExtractAllCSSources.Checked;
            settings.CsPath = edtCSPath.Text;
            settings.Save();
            lbSavingStatus.Text = "Settings saved successfully";
        }

        private void btnBrowseJSPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtJSPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtJSPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath);
            }
        }

        private void btnBrowseCSPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtCSPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtCSPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath);
            }
        } 

        #endregion
        
    }
}
