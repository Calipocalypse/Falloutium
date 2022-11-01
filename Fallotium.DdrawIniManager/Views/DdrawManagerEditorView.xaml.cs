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
    public partial class DdrawManagerEditorView : UserControl
    {
        private DdrawManagerViewModel ddrawManagerViewModel;

        public DdrawManagerEditorView(DdrawManagerViewModel ddrawManagerViewModel)
        {
            InitializeComponent();
            DataContext = new DdrawManagerEditorViewModel();
            this.ddrawManagerViewModel = ddrawManagerViewModel;
        }
    }
}
