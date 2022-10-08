using Fallotium.Core;
using Fallotium.MsgScanner.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fallotium.MsgScanner.ViewModels
{
    public class MsgScannerViewModel : ViewModelBase
    {
        public ICommand DirectoryButton { get; }
        public ICommand ScanButton { get; }

        private string directoryPath;
        public string DirectoryPath
        {
            get { return directoryPath; }
            set
            {
                directoryPath = value;
                OnPropertyChange(nameof(DirectoryPath));
            }
        }

        public MsgScannerViewModel()
        {
            DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            DirectoryButton = new DirectoryButton(this);
            ScanButton = new ScanButton();
        }
    }
}
