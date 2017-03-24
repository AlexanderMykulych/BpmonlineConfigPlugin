using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings;
using Microsoft.Web.Administration;

namespace BpmOnlineConfig
{
    public partial class BpmonlineConfiguration : UserControl
    {
        private ServerManager _serverManager;
        private BpmOnlineSettings _settings;

        public BpmonlineConfiguration(ServerManager serverManager)
        {
            _serverManager = serverManager;
            InitializeComponent();
        }

        public void Initialize(string siteName, string virtualPath)
        {
            var site = new BpmOnlineSite(_serverManager, siteName, virtualPath);
            _settings = new BpmOnlineSettings(site);
            BindSettings(_settings);
            _settings.Show();
            UpdateControlsByExtractJSFlug();
            UpdateControlsByExtractCSFlug();
	        SubscribeOnControlChange();
        }

	    private void SubscribeOnControlChange() {
			foreach (Control c in this.Controls) {
				if (c is CheckBox) {
					((CheckBox)c).CheckedChanged += OnFormControlChanged;
				} else {
					c.TextChanged += new EventHandler(OnFormControlChanged);
				}
			}
	    }

	    private void OnFormControlChanged(object sender, EventArgs e) {
			lbSavingStatus.Text = string.Empty;
	    }

	    #region Private: Methods

        private void BindSettings(BpmOnlineSettings settings)
        {
            settings.Add(new SessionTimeOutMinutes(edtSessionTimeOut));
            settings.Add(new WebSocketsPort(edtWebSocketsPort));
            settings.Add(new MaxEntityNameLength(edtMaxEntityNameLength));
            settings.Add(new ExtractJs(chbExtractJS));
            settings.Add(new JsPath(edtJSPath));
            settings.Add(new UncompressedCoreJs(chbUncompressedJS));
			settings.Add(new UseIncludeDependenciesSource(chbIncludeDependenciesSource));
            settings.Add(new ExtractCs(chbExtractCS));
            settings.Add(new ExtractAllCsSources(chbExtractAllCSSources));
            settings.Add(new CsPath(edtCSPath));
            settings.Add(new LogPath(edtLogPath));
            settings.Add(new ApplicationName(edtApplicatinName));
            settings.Add(new SchedulerDb(chbSchedulerDb));
            // Legacy
            //settings.Add(new UseFlatPackage(chbUseFlatPackage));
            //settings.Add(new UsePackageVersions(chbUsePackageVersions));
            settings.Add(new DefWorkingCopyPath(edtDefWorkingCopyPath));
            settings.Add(new DefPackagesWorkingCopyPath(edtDefPackagesWorkingCopyPath));
            settings.Add(new SourceControlAuthPath(edtSourceControlAuthPath));
            settings.Add(new UseSvn(chbUseSvn));
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

        private static string GetSelectedPath(string path, string defaultEnding)
        {
            path = path.TrimEnd('\\');
            return path + defaultEnding;
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
            lbSavingStatus.Text = "Saving...";
            _settings.Save();
            lbSavingStatus.Text = "Settings saved successfully";
        }

        private void btnBrowseJSPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtJSPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtJSPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath, @"\%WORKSPACE%");
            }
        }

        private void btnBrowseCSPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtCSPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtCSPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath, @"\%WORKSPACE%");
            }
        }

        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtLogPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtLogPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath, @"%AspNet{ApplicationPath}\Log\");
            }
        }

        private void btnBrowseDefPackagesWorkingCopyPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtDefPackagesWorkingCopyPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtDefPackagesWorkingCopyPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath, @"\%WORKSPACE%");
            }
        }

        #endregion

        private void btnBrowseDefWorkingCopyPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtDefPackagesWorkingCopyPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtDefWorkingCopyPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath, @"\%WORKSPACE%");
            }
        }

        private void btnBrowseSourceControlAuthPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = GetPathForBrowserDialog(edtDefPackagesWorkingCopyPath.Text);
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                edtSourceControlAuthPath.Text = GetSelectedPath(folderBrowserDialog.SelectedPath, @"\%WORKSPACE%");
            }
        }

    }
}
