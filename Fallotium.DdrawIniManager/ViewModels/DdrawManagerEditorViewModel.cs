using Fallotium.Core;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Operations;
using Fallotium.DdrawIniManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager
{
    public class DdrawManagerEditorViewModel : ViewModelBase
    {

        public List<DdrawEntry> DdrawEntries { get; set; }
        public string IniPath { get; set; } 

        public DdrawManagerEditorViewModel()
        {
            IniPath = Settings.GetSetting(Setting.DdrawIniFilePath);
            DdrawEntries = DdrawReader.GetDdrawEntriesFromFile(IniPath).ToList();
        }
    }
}
