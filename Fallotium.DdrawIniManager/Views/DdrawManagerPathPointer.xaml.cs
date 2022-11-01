using Fallotium.DdrawIniManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fallotium.DdrawIniManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DdrawEditorPathPointer.xaml
    /// </summary>
    public partial class DdrawManagerPathPointer : UserControl
    {
        public DdrawManagerPathPointer(DdrawManagerViewModel ddrawManagerViewModel)
        {
            InitializeComponent();
            DataContext = new DdrawManagerPathPointerViewModel(ddrawManagerViewModel);
        }
    }
}
