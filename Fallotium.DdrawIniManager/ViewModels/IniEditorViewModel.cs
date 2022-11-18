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
using System.Windows;

namespace Fallotium.DdrawIniManager
{
    internal class IniEditorViewModel : ViewModelBase
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

        private IniFile activeFile;
        public IniFile ActiveFile
        {
            get { return activeFile; }
            set
            {
                activeFile = value;
                OnPropertyChange(nameof(ActiveFile));
                UpdatePresetsUi(activeFile);

                PresetParam.iniFile = value;
                OnPropertyChange(nameof(PresetParam));

                if (value != null) AddPresetVisibility = Visibility.Visible;
                else AddPresetVisibility = Visibility.Collapsed;
            }
        }

        private IniFilePresetTextParam presetParam = new IniFilePresetTextParam();
        public IniFilePresetTextParam PresetParam
        {
            get { return presetParam; }
            set
            {
                presetParam = value;
                OnPropertyChange(nameof(PresetParam));
            }
        }

        private string addPresetTextBoxText = String.Empty;
        public string AddPresetTextBoxText
        {
            get { return addPresetTextBoxText; }
            set
            {
                addPresetTextBoxText = value;
                OnPropertyChange(nameof(AddPresetTextBoxText));

                PresetParam.presetName = value;
                OnPropertyChange(nameof(PresetParam));
            }
        }

        private Visibility addPresetVisibility = Visibility.Collapsed;
        public Visibility AddPresetVisibility
        {
            get { return addPresetVisibility; }
            set
            {
                addPresetVisibility = value;
                OnPropertyChange(nameof(AddPresetVisibility));
            }
        }

        public string IniPath { get; set; } 

        public ICommand DdrawFileSwitch { get; set; }
        public ICommand DdrawFileDeleter { get; set; }
        public ICommand AddNewFile { get; set; }
        public ICommand AddPreset { get; set; }
        public ICommand DeletePreset { get; set; }
        public ICommand PresetSwticher { get; set; }

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
            AddPreset = new PresetAdder(this);
            DeletePreset = new PresetDelete(this);
            PresetSwticher = new PresetSwitch(this);
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
            ActiveFile = iniFile;
        }

        internal void SwitchPreset(Preset preset)
        {
            //Edit DdrawEntries

        }

        internal class IniFilePresetTextParam
        {
            internal string presetName;
            internal IniFile iniFile;
        }
    }
}
