using Fallotium.Core;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fallotium.DdrawIniManager.ViewModels
{
    internal class DdrawManagerPathPointerViewModel : ViewModelBase
    {
        private DdrawManagerViewModel parentVm;

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
            }
        }

        public ICommand DirectoryButton { get; }
        public DdrawManagerPathPointerViewModel(DdrawManagerViewModel ddrawManagerViewModel)
        {
            this.parentVm = ddrawManagerViewModel;
            DirectoryButton = new FilePointer(this);
        }
    }
}
