using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fallotium.Core.SettingsManagment
{
    internal static class SettingFirstTimeLaunch
    {
        private static Dictionary<Setting, string> allSettings = GetEmptySettings();

        internal static XElement GetNewSettingsDoc()
        {
            var doc = new XElement("Settings", GetSettingsXElements());
            return doc;
        }

        private static List<XElement> GetSettingsXElements()
        {
            var c = new List<XElement>();
            foreach (var setting in allSettings)
            {
                var element = new XElement(setting.Key.ToString());
                c.Add(element);
            }
            return c;
        }
        private static Dictionary<Setting, string> GetEmptySettings()
        {
            var dic = new Dictionary<Setting, string>();
            foreach (var setting in Enum.GetValues(typeof(Setting)))
            {
                dic.Add((Setting)setting, null);
            }
            return dic;
        }
    }
}
