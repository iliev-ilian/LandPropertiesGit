using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LandProperties.Util
{
    public class ConfigurationHelper
    {
        public static String ReadFromConfig(String key)
        {
            System.Configuration.Configuration rootWebConfig1 =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            if (rootWebConfig1.AppSettings.Settings.Count > 0)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                    rootWebConfig1.AppSettings.Settings[key];
                if (customSetting != null)
                    return customSetting.Value;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
