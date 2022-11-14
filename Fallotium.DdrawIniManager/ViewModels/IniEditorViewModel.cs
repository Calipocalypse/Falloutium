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
        public ObservableCollection<IniFile> DdrawFiles { get;
            set; }
        public string IniPath { get; set; } 

        public ICommand DdrawFileSwitch { get; set; }

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
            DdrawFiles = GetDdrawFiles();
            DdrawFileSwitch = new FileSwitch(this);
        }

        private void ComposeData()
        {
            DdrawFiles = IniXmlManager.GetOcAllData();
            //DdrawEntries = DdrawReader.GetDdrawEntriesFromFile(IniPath).ToList();
        }

        private ObservableCollection<IniFile> GetDdrawFiles()
        {
            return new ObservableCollection<IniFile>{ new IniFile("TESE"), new IniFile("TERERESE") };
        }
    }
}
