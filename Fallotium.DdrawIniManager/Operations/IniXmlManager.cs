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
        private static string XmlFolderPath;
        private static string XmlPath;

        private static XElement xml;

        static IniXmlManager()
        {
            ComposePaths();
            CheckAndCreateDirectoryAndFile();
            xml = XElement.Load(XmlPath);
        }

        private static void ComposePaths()
        {
            XmlFolderPath = Settings.settingsXmlDirectory + "/Ddraw/";
            XmlPath = XmlFolderPath + "DdrawFilesInfo.xml";
        }

        private static void CheckAndCreateDirectoryAndFile()
        {
            if (!Directory.Exists(XmlFolderPath))
            {
                Directory.CreateDirectory(XmlFolderPath);
            }
            if (!File.Exists(XmlPath))
            {
                CreateBasicXmlFile();
            }
        }

        internal static void CreateBasicXmlFile() => Save(new ObservableCollection<IniFile>());
        internal static void Save(ObservableCollection<IniFile> iniFiles)
        {
            var newXmlFileContent = GetXElementsOfFiles(iniFiles);
            xml = newXmlFileContent;
            xml.Save(XmlPath);
        }

        private static XElement GetXElementsOfFiles(ObservableCollection<IniFile> iniFiles)
        {
            var XIniFiles = new XElement("DdrawFiles");
            foreach (var iniFile in iniFiles)
            {
                var xIniFile =
                    new XElement("DdrawFile",
                    new XAttribute("Path", iniFile.FilePath));

                var presets = iniFile.Presets;
                foreach (var preset in presets)
                {
                    var xIniFilePresets =
                    new XElement("DdrawFile",
                    new XAttribute("Path", iniFile.FilePath),
                        new XElement("Preset",
                        new XAttribute("Name", preset.Name),
                        new XAttribute("Id", preset.Id)));

                    xIniFile.Add(xIniFilePresets);
                }
                
                XIniFiles.Add(xIniFile);
            }
            return XIniFiles;
        }

        internal static void AddNewFile(IniFile file)
        {
            var pathAttribute = new XAttribute("Path", file.FilePath);
            var newFileXElement = new XElement("DdrawFile", pathAttribute);
            var newOriginalPreset = new XElement("Preset", new XAttribute("Name", "Original"), new XAttribute("Id", 0));
            newFileXElement.Add(newOriginalPreset);
            xml.Add(newFileXElement);
            Save();
        }

        internal static void DeleteFile(IniFile file)
        {
            var xToDelete = xml.Descendants("DdrawFile").FirstOrDefault(x => x.Attribute("Path").Value == file.FilePath);
            xToDelete.Remove();
            Save();
        }

        internal static void AddNewPreset(Preset preset, IniFile activeFile)
        {
            var xIniFile = xml.Descendants("DdrawFile").FirstOrDefault(x => x.Attribute("Path").Value == activeFile.FilePath);
            var xPreset = new XElement("Preset",
                new XAttribute("Name", preset.Name),
                new XAttribute("Id", preset.Id));

            xIniFile.Add(xPreset);
            Save();
        }

        internal static void DeletePreset(Preset preset)
        {
            var iniFile = preset.Parent;
            var xIniFiles = xml.Descendants("DdrawFile");
            var xIniFile = xIniFiles.FirstOrDefault(x => x.Attribute("Path").Value == iniFile.FilePath);
            var xPreset = xIniFile.Descendants("Preset").FirstOrDefault(x => x.Attribute("Id").Value == preset.Id.ToString());
            xPreset.Remove();
            Save();
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
                string filePath = ddrawFile.Attribute("Path").Value;
                var iniFile = new IniFile(filePath);
                var presetOc = new ObservableCollection<Preset>();
                foreach (var xPreset in ddrawFile.Descendants("Preset"))
                {
                    var id = xPreset.Attribute("Id").Value;
                    var name = xPreset.Attribute("Name").Value;
                    var preset = new Preset(Int32.Parse(id), name, iniFile);
                    presetOc.Add(preset);
                }
                iniFile.Presets = presetOc;
                oc.Add(iniFile);
            }
            return oc;
        }
    }
}
