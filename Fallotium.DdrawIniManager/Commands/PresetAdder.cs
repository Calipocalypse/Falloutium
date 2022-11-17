using Fallotium.Core;
using Fallotium.DdrawIniManager;
using Fallotium.DdrawIniManager.Models;
using Fallotium.DdrawIniManager.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Fallotium.DdrawIniManager.IniEditorViewModel;

namespace Fallotium.IniManager.Commands
{
    internal class PresetAdder : CommandBase
    {
        private IniEditorViewModel Vm;

        public PresetAdder(IniEditorViewModel iniEditorViewModel)
        {
            Vm = iniEditorViewModel;
        }

        public override void Execute(object parameter)
        {
            var presetParam = (IniFilePresetTextParam)parameter;
            var presetNameFromTextBox = presetParam.presetName;
            var activeFile = presetParam.iniFile;
            var id = GetFreeId(Vm.Presets);

            var newPreset = new Preset(id, presetNameFromTextBox, activeFile);

            //Ui
            Vm.Presets.Add(newPreset);

            //Xml file
            IniXmlManager.AddNewPreset(newPreset, activeFile);
        }

        private int GetFreeId(ObservableCollection<Preset> presets)
        {
            var numList = new List<int>();
            foreach (var preset in presets)
            {
                numList.Add(preset.Id);
            }
            int numberToReturn = 0;
            for (; ; )
            {
                if (numList.Contains(numberToReturn))
                {
                numberToReturn++;
                    continue;
                }
                return numberToReturn;
            }
        }
    }
}
