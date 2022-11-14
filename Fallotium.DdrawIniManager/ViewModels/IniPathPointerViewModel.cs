using Fallotium.Core;
using Fallotium.Core.FilesBackupManagment;
using Fallotium.Core.FilesBackupManagment.Enum;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Commands;
using Fallotium.DdrawIniManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fallotium.DdrawIniManager.ViewModels
{
    internal class IniPathPointerViewModel : ViewModelBase
    {
        private IniMainViewModel parentVm;

        private string iniPath = Settings.GetSetting(Setting.DdrawIniFilePath);
        public string IniPath
        {
            get
            {
                return iniPath;
            }
            set
            {
                iniPath = value;
                OnPropertyChange(nameof(IniPath));
                parentVm.Content = new IniEditorView(parentVm, value);
            }
        }

        public ICommand DirectoryButton { get; }
        public IniPathPointerViewModel(IniMainViewModel ddrawManagerViewModel)
        {
            this.parentVm = ddrawManagerViewModel;
            DirectoryButton = new FilePointer(this);
        }
    }
}
