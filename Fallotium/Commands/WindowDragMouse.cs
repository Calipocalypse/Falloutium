using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Fallotium.Commands
{
    public class WindowDragMouse
    {
        private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            //Control src = e.Source as Control;

            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    MessageBox.Show("CLICKED");
                    break;
                case MouseButton.Middle:

                    break;
                case MouseButton.Right:

                    break;
                case MouseButton.XButton1:

                    break;
                case MouseButton.XButton2:

                    break;
                default:
                    break;
            }
        }
    }
}
