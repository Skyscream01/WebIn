using System.Configuration;

namespace ProductX.Framework {
    
    public class Configuration {
        //Settings
        private const string Timeout = "Timeout";
       
        
        private static string GetParameterValue(string key) {
            return ConfigurationManager.AppSettings.Get(key);
        }

        private static void SetParameterValue(string key, string value) {
            ConfigurationManager.AppSettings.Set(key, value);
        }

        //============================================== Settings ====================================================
        public static string GetTimeout() {
            return GetParameterValue(Timeout);
        }

    }
}