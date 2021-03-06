﻿using System;
using System.Windows.Forms;
using BpmOnlineConfig.Settings.Base;

namespace BpmOnlineConfig.Settings
{
    class UseSvn : BooleanSetting
    {
        public override bool IsAvailable
        {
            get
            {
                if (!base.IsAvailable)
                {
                    return false;
                }
                if (Site.ApplicationConfig == null)
                {
                    return false;
                }
                return true;
            }
        }

        public UseSvn(CheckBox control) : base(control) { }

        public override bool Read()
        {
            var value = Site.ApplicationConfig.GetConfigParameterValue("appSettings/add[@key=\"UseSvn\"]",
                    "value");
            return (value != null) && Convert.ToBoolean(value);
        }

        public override void Save()
        {
            if (ControlValue == Read())
            {
                return;
            }
            Site.ApplicationConfig.SetConfigParameterValue("appSettings/add[@key=\"UseSvn\"]", "value", ControlValue);
        }
    }
}
