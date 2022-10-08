using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fallotium.Core.SettingsManagment
{
    internal static class SettingsLaunch
    {

        internal static IEnumerable<Setting> GetCollectionOfMissingSettings(XElement settingsDoc)
        {
            var settingsNode = "Settings";
            var allSettingsFromDoc = settingsDoc.Elements();
            List<Setting> allDefinedSettings = Enum.GetValues<Setting>().ToList();

            foreach (var setting in allSettingsFromDoc)
            {
                try
                {
                    var docSettingName = setting.Name.ToString();
                    Setting existingSetting = (Setting)Enum.Parse(typeof(Setting), docSettingName);
                    allDefinedSettings.Remove(existingSetting);
                }
                catch
                {
                    //Nothing to do here because from allDefinedSettings we will have new collection of missingSettings
                }
            }

            var missingSettings = allDefinedSettings;
            return missingSettings;
        }

        internal static XElement GetFileContent(string defaultSettingsFilePath)
        {
            var doc = XElement.Load(defaultSettingsFilePath);
            return doc;
        }
        internal static void AddMissingSetings(XElement settingsDoc, IEnumerable<Setting> missingSettings)
        {
            foreach (var missingSetting in missingSettings)
            {
                var newSettingForFile = new XElement(missingSetting.ToString());
                settingsDoc.Add(newSettingForFile);
            }
        }

        internal static Dictionary<Setting, string> LoadAllSettings(XElement settingsDoc)
        {
            var dict = new Dictionary<Setting, string>();
            var allSettingsFromDoc = settingsDoc.Elements();
            foreach (var setting in allSettingsFromDoc)
            {
                var settingName = setting.Name.ToString();
                bool settingExistsInEnum = Enum.TryParse(typeof(Setting), settingName, out var enumSetting);
                if (settingExistsInEnum)
                {
                    var settingValue = setting.Value;
                    dict.Add((Setting)enumSetting, settingValue);
                }
            }
            return dict;
        }
    }
}
