using Fallotium.Core;
using Fallotium.DdrawIniManager;
using Fallotium.DdrawIniManager.Models;
using Fallotium.DdrawIniManager.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.IniManager.Commands
{
    internal class PresetDelete : CommandBase
    {
        private IniEditorViewModel Vm;

        public PresetDelete(IniEditorViewModel iniEditorViewModel)
        {
            Vm = iniEditorViewModel;
        }

        public override void Execute(object parameter)
        {
            var preset = (Preset)parameter;
            Vm.Presets.Remove(preset);

            IniXmlManager.DeletePreset(preset);
        }
    }
}
