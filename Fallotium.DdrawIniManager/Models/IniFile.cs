using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager.Models
{
    public class IniFile
    {
        public string FilePath { get; set; }
        public ObservableCollection<Preset> Presets { get; set;}
        //list of values suggestions

        //Constructor used only for file switch
        public IniFile(string filePath)
        {
            FilePath = filePath;
            Presets = new ObservableCollection<Preset>();
        }
    }
}
