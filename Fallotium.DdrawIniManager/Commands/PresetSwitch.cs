using Fallotium.Core;
using Fallotium.DdrawIniManager;
using Fallotium.DdrawIniManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.IniManager.Commands
{
    internal class PresetSwitch : CommandBase
    {
        private IniEditorViewModel Vm;

        public PresetSwitch(IniEditorViewModel iniEditorViewModel)
        {
            Vm = iniEditorViewModel;
        }

        public override void Execute(object parameter)
        {
            var convertedParam = (Preset)parameter;
            Vm.SwitchPreset();
        }
    }
}
