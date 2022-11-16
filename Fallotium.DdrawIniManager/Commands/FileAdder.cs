using Fallotium.Core;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager;
using Fallotium.DdrawIniManager.Models;
using Fallotium.DdrawIniManager.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fallotium.IniManager.Commands
{
    internal class FileAdder : CommandBase
    {
        private IniEditorViewModel Vm { get; }

        public FileAdder(IniEditorViewModel iniEditorViewModel)
        {
            Vm = iniEditorViewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ddraw.ini (*.ini)|*.ini";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var resultPath = dialog.FileName;
                Settings.ChangeSetting(Setting.DdrawIniFilePath, resultPath);
                var newFile = new IniFile(resultPath);
                IniXmlManager.AddNewFile(newFile);
                Vm.AddIniFileToUi(newFile);
            }
        }
    }
}
