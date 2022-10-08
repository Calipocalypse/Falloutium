using Fallotium.Core;
using Fallotium.Enums;
using Fallotium.MsgScanner.Views;
using Fallotium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.Commands
{
    public class MenuButtons : CommandBase
    {
        public MainWindowViewModel Vm;

        public MenuButtons(MainWindowViewModel vm)
        {
            Vm = vm;
        }

        public override void Execute(object parameter)
        {
            string _parameter = parameter as string;

            switch(_parameter)
            {
                case "GameSetup":
                    break;
                case "MsgScanner": Vm.Content = new MsgScannerView();
                    break;
                case "GvarManager":
                    break;
                case "DdrawManager": Vm.Content = new DdrawIniManager.Views.DdrawManagerMainView();
                    break;
            }
        }
    }
}
