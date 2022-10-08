using Fallotium.Core;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallotium.Commands
{
    internal class WindowManipulationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var _parameter = (string)parameter;

            if (_parameter == "Exit") ShutdownApplication();
            else if (_parameter == "Minimize") MinimizeApplication();
            else if (_parameter == "Maximize") ResizeApplication();
        }

        private void ShutdownApplication() => Application.Current.Shutdown();
        private void MinimizeApplication() => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        public void ResizeApplication()
        {
            var currentWindow = Application.Current.MainWindow;

            if (currentWindow.WindowState == WindowState.Normal) MaximizeWithSpaceForTaskBar(currentWindow);
            else if (currentWindow.WindowState == WindowState.Maximized) currentWindow.WindowState = WindowState.Normal;
        }

        private void MaximizeWithSpaceForTaskBar(Window currentWindow)
        {
            currentWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            currentWindow.WindowState = WindowState.Maximized;
            currentWindow.WindowStyle = WindowStyle.None;
        }
    }
}
