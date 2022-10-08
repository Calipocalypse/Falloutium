using Fallotium.Commands;
using Fallotium.Core;
using Fallotium.MsgScanner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fallotium.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object content;
        public object Content
        {
            get { return content; }
            set 
            {
                content = value;
                OnPropertyChange(nameof(Content));
            }
        }

        public ICommand WindowManipulationButton { get; }
        public ICommand MenuButtons { get; }
        public delegate void MouseButtonEventHandler(object sender, MouseButtonEventArgs e);

        public MainWindowViewModel()
        {
            WindowManipulationButton = new WindowManipulationCommand();
            MenuButtons = new MenuButtons(this);
        }
    }
}
