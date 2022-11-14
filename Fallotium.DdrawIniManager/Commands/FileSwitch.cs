using Fallotium.Core;
using Fallotium.DdrawIniManager.Models;
using Fallotium.DdrawIniManager.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.DdrawIniManager.Commands
{
    public class FileSwitch : CommandBase
    {
        private IniEditorViewModel parentVm;

        public FileSwitch(IniEditorViewModel parentVm)
        {
            this.parentVm = parentVm;
        }

        public override void Execute(object parameter)
        {
            var ddrawFile = (IniFile)parameter;
            parentVm.DdrawEntries = IniReader.GetDdrawEntriesFromFile(ddrawFile.FilePath);
        }
    }
}
