using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Fallotium.DdrawIniManager.Operations
{
    internal static class IniXmlManager
    {
        private static string XmlFolderPath = Settings.settingsXmlDirectory + "/Ddraw/";
        private static string XmlPath = XmlFolderPath + "DdrawFilesInfo.xml";

        private static XElement xml;

        static IniXmlManager()
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
                xml = GetDdrawDocBase();
                xml.Save(XmlPath);
            }
        }

        internal static void AddNewFile(IniFile file)
        {
            var pathAttribute = new XAttribute("Path", file.FilePath);
            var newFileXElement = new XElement("DdrawFile", pathAttribute);
            xml.Add(newFileXElement);
            Save();
        }

        internal static void DeleteFile(IniFile file)
        {
            var xToDelete = xml.Descendants("DdrawFile").FirstOrDefault(x => x.Attribute("Path").Value == file.FilePath);
            xToDelete.Remove();
            Save();
        }

        private static XElement GetDdrawDocBase()
        {
            return new XElement("DdrawFiles");
        }

        private static void Save()
        {
            xml.Save(XmlPath);
        }

        internal static ObservableCollection<IniFile> GetOcAllData()
        {
            var oc = new ObservableCollection<IniFile>();
            foreach (var ddrawFile in xml.Descendants("DdrawFile"))
            {
                oc.Add(new IniFile(ddrawFile.Attribute("Path").Value));
            }
            return oc;
        }
    }
}
