using Fallotium.Core;
using Fallotium.MsgScanner.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Fallotium.MsgScanner.Commands
{
    public class DirectoryButton : CommandBase
    {
        private MsgScannerViewModel vm;

        public DirectoryButton(MsgScannerViewModel VM)
        {
            vm = VM;
        }

        public override void Execute(object parameter)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            vm.DirectoryPath = dialog.SelectedPath;
        }
    }
}
