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
        //public List<List<DdrawEntry>> 

        public DdrawManagerEditorViewModel()
        {
            var iniPath = Settings.GetSetting(Setting.DdrawIniFilePath);
            DdrawEntries = DdrawReader.GetDdrawEntriesFromFile(iniPath).ToList();
        }
    }
}
