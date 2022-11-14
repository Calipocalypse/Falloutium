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
    /// Logika interakcji dla klasy DdrawManagerEditorView.xaml
    /// </summary>
    public partial class IniEditorView : UserControl
    {
        private IniMainViewModel ddrawManagerViewModel;

        public IniEditorView(IniMainViewModel ddrawManagerViewModel)
        {
            InitializeComponent();
            DataContext = new IniEditorViewModel();
            this.ddrawManagerViewModel = ddrawManagerViewModel;
        }

        public IniEditorView(IniMainViewModel ddrawManagerViewModel, string newPath)
        {
            DataContext = new IniEditorViewModel(newPath);
        }
    }
}
