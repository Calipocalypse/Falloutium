using Fallotium.Core;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Operations;
using Fallotium.DdrawIniManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Fallotium.DdrawIniManager.Commands
{
    public class FilePointer : CommandBase
    {
        IniPathPointerViewModel vm;
        public FilePointer(object viewModel)
        {
            this.vm = (IniPathPointerViewModel)viewModel;
        }
        public override void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ddraw.ini (*.ini)|*.ini";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var resultPath = dialog.FileName;
                Settings.ChangeSetting(Setting.DdrawIniFilePath, resultPath);
                IniXmlManager.AddNewFile(resultPath);
                vm.IniPath = resultPath;
            }
            
            //vm.FilePath = dialog.SelectedPath;
        }
    }
}
