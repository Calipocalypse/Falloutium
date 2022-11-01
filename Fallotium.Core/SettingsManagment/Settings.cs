using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Fallotium.Core.SettingsManagment
{
    public static class Settings
    {
        static string defaultSettingsFileDirectory => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Falloutium 1.0";
        static string defaultSettingsFilePath => defaultSettingsFileDirectory + "/Settings.xml";
        public static string settingsXmlDirectory => defaultSettingsFileDirectory;
        static string settingsXmlPath => defaultSettingsFilePath;

        static Dictionary<Setting, string> settings = new Dictionary<Setting, string>();
        static XElement loadedXml;

        public static void Init()
        {
            //First times
            if (!Directory.Exists(settingsXmlDirectory))
            {
                Directory.CreateDirectory(settingsXmlDirectory);
            }
            if (!File.Exists(settingsXmlPath))
            {
                var newSettingsDoc = SettingFirstTimeLaunch.GetNewSettingsDoc();
                newSettingsDoc.Save(settingsXmlPath);    
            }

            //Another times (First time also)
            var settingsDoc = SettingsLaunch.GetFileContent(settingsXmlPath);
            var missingSettings = SettingsLaunch.GetCollectionOfMissingSettings(settingsDoc);
            if (missingSettings.Count() > 0)
            {
                SettingsLaunch.AddMissingSetings(settingsDoc, missingSettings);
                settingsDoc.Save(settingsXmlPath);
            }

            Load(settingsDoc);
        }

        private static void Load(XElement settingsDoc)
        {
            settings = SettingsLaunch.LoadAllSettings(settingsDoc);
            loadedXml = settingsDoc;
        }

        private static void Save()
        {
            settings.Save(loadedXml, settingsXmlPath);
        }

        public static void ChangeSetting(Setting settingName, string value)
        {
            settings[settingName] = value;
            settings.Save(loadedXml, settingsXmlPath);
        }

        public static string GetSetting(Setting settingName)
        {
            return settings[settingName];
        }

        private static void Save(this Dictionary<Setting, string> dict, XElement xml, string desiredFileLocation)
        {
            foreach(var kvp in dict)
            {
                var dictSettingName = kvp.Key.ToString();
                var xmlSettingElement = xml.Element(dictSettingName);
                if (kvp.Value != xmlSettingElement.Value)
                {
                    xmlSettingElement.Value = kvp.Value;
                }
            }
            xml.Save(desiredFileLocation);
        }
    }
}
