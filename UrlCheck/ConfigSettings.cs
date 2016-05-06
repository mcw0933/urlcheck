using System;
using System.Configuration;
using System.Windows.Forms;

namespace UrlCheck {
    internal class ConfigSettings {
        #region Members
        public static readonly int AnimationIntervalMSec = Get("AnimationIntervalMSec", 10);
        public static readonly int DisplayMSec = Get("DisplayMSec", 3000);
        public static readonly int PollIntervalMSec = Get("PollIntervalMSec", 15000);

        public static readonly string PollUrl = Get("PollUrl", "https://gist.githubusercontent.com/hrp/900964/raw/2bbee4c296e6b54877b537144be89f19beff75f4/twitter.json");
        public static readonly string ValueJsonPath = Get("ValueJsonPath", "user.followers_count");
        public static readonly string LabelJsonPath = Get("LabelJsonPath", "user.screen_name");
        #endregion

        #region Subroutines
        internal static int Get(string name, int defVal) {
            var retVal = defVal;
            var setting = ConfigurationManager.AppSettings.Get(name);

            if (!string.IsNullOrWhiteSpace(setting))
                retVal = int.TryParse(setting, out retVal) ? retVal : defVal;

            return retVal;
        }

        internal static string Get(string name, string defVal) {
            var setting = ConfigurationManager.AppSettings.Get(name);
            var retVal = string.IsNullOrWhiteSpace(setting) ? defVal : setting;

            return retVal;
        }

        internal static void Set(string name, int val) {
            Set(name, val.ToString());
        }

        internal static void Set(string name, string val) {
            // http://stackoverflow.com/a/25806731/3782
            var c = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            // http://stackoverflow.com/a/8313682/3782
            c.AppSettings.Settings.Remove(name);
            c.AppSettings.Settings.Add(name, val);

            c.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion
    }
}
