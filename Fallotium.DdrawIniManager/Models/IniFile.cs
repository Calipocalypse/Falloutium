using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager.Models
{
    public class IniFile
    {
        public string FilePath { get; set; }
        //list of file presets
        //list of values suggestions
        public IniFile(string filePath)
        {
            FilePath = filePath;
        }
    }
}
