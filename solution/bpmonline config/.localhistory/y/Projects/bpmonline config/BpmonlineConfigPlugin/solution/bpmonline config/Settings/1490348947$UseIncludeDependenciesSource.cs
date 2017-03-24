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
			var configParameterValue = Site.ApplicationConfig.GetConfigParameterValue(
				"appSettings/add[@key=\"UseIncludeDependenciesSource\"]", "value");
			return (configParameterValue != null) && Convert.ToBoolean(configParameterValue);
		}

		public override void Save() {
			if (ControlValue == Read()) {
				return;
			}
			Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"UseIncludeDependenciesSource\"]", 
				"value", ControlValue, true);
		}

		#endregion
	}
}