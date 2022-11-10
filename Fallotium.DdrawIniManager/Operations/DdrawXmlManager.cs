using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fallotium.DdrawIniManager.Operations
{
    internal static class DdrawXmlManager
    {
        private static string XmlFolderPath = Settings.settingsXmlDirectory + "/Ddraw/";
        private static string XmlPath = XmlFolderPath + "DdrawFilesInfo.xml";

        private static XElement xml;

        static DdrawXmlManager()
        {
            CheckAndCreateDirectoryAndFile();
            xml = XElement.Load(XmlPath);
        }
        private static void CheckAndCreateDirectoryAndFile()
        {
            if (!Directory.Exists(XmlFolderPath))
            {
                Directory.CreateDirectory(XmlFolderPath);
            }
            if (!File.Exists(XmlPath))
            {

            }
        }

        private static void Save()
        {
        }

        internal static ObservableCollection<string> GetOcOfFilePaths()
        {

        }

        internal static ObservableCollection<DdrawFilePreset> GetOcOfFilePreset(string filePath)
        {

        }
    }
}
