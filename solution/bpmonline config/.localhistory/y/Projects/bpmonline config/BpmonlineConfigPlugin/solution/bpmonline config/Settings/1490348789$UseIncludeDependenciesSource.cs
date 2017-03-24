namespace BpmOnlineConfig.Settings {
	#region Usings

	using System;
	using System.Windows.Forms;
	using Base;

	#endregion

	public class UseIncludeDependenciesSource : BooleanSetting {
		#region Constructors: Public

		public UseIncludeDependenciesSource(CheckBox control) : base(control) {
		}

		#endregion

		#region Properties: Public

		public override bool IsAvailable {
			get {
				if (!base.IsAvailable) {
					return false;
				}
				if (Site.ApplicationConfig == null) {
					return false;
				}
				return true;
			}
		}

		#endregion

		#region Methods: Public

		public override bool Read() {
			var separatedJsFiles = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"SeparatedJsFiles\"]",
				"value");
			return (separatedJsFiles != null) && Convert.ToBoolean(separatedJsFiles);
		}

		public override void Save() {
			if (ControlValue == Read()) {
				return;
			}
			Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"SeparatedJsFiles\"]", "value", ControlValue,
				true);
		}

		#endregion
	}
}