using Fallotium.Core;
using Fallotium.Core.FilesBackupManagment.Enum;
using Fallotium.Core.FilesBackupManagment;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Operations;
using Fallotium.DdrawIniManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Fallotium.DdrawIniManager.Models;
using System.Windows.Input;
using Fallotium.DdrawIniManager.Commands;
using Fallotium.IniManager.Commands;

namespace Fallotium.DdrawIniManager
{
    public class IniEditorViewModel : ViewModelBase
    {
        private ObservableCollection<IniEntry> ddrawEntries;
        public ObservableCollection<IniEntry> DdrawEntries
        {
            get { return ddrawEntries; }
            set
            {
                ddrawEntries = value;
                OnPropertyChange(nameof(DdrawEntries));
            }
        }
        public ObservableCollection<IniFile> DdrawFiles { get; set; }

        private ObservableCollection<Preset> presets;
        public ObservableCollection<Preset> Presets
        {
            get { return presets; }
            set
            {
                presets = value;
                OnPropertyChange(nameof(Presets));
            }
        }

        public string IniPath { get; set; } 

        public ICommand DdrawFileSwitch { get; set; }
        public ICommand DdrawFileDeleter { get; set; }
        public ICommand AddNewFile { get; set; }

        public IniEditorViewModel()
        {
            IniPath = Settings.GetSetting(Setting.DdrawIniFilePath);
            ComposeElements();
            ComposeData();
        }

        //Only once - coming from Path Picker
        public IniEditorViewModel(string newPath)
        {
            IniPath = newPath;
            ComposeElements();
            //DdrawEntries = DdrawReader.GetDdrawEntriesFromFile(newPath).ToList();
        }

        private void ComposeElements()
        {
            DdrawFileSwitch = new FileSwitch(this);
            DdrawFileDeleter = new FileDeleter(this);
            AddNewFile = new FileAdder(this);
        }

        private void ComposeData()
        {
            DdrawFiles = IniXmlManager.GetOcAllData();
            Presets = new ObservableCollection<Preset>();
        }

        internal void UpdatePresetsUi(IniFile activeFile)
        {
            Presets = activeFile.Presets;
        }

        internal void RemoveIniFileFromUi(IniFile file)
        {
            DdrawFiles.Remove(file);
        }

        internal void AddIniFileToUi(IniFile file)
        {
            DdrawFiles.Add(file);
        }

        internal void SwitchFile(IniFile iniFile)
        {
            //Fill file content area
            DdrawEntries = IniReader.GetDdrawEntriesFromFile(iniFile.FilePath);
            //Update Presets
            UpdatePresetsUi(iniFile);
        }
    }
}
