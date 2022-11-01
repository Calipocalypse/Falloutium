using Fallotium.Core;
using Fallotium.Core.SettingsManagment;
using Fallotium.DdrawIniManager.Commands;
using Fallotium.DdrawIniManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fallotium.DdrawIniManager.ViewModels
{
    public class DdrawManagerViewModel : ViewModelBase
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

        public DdrawManagerViewModel()
        {
            if (Settings.GetSetting(Setting.DdrawIniFilePath) == String.Empty)
            {
                SetContentViewToFileFinder(this);
            }
            else
            {
                SetContentViewToEditor(this);
            }
        }

        internal void SetContentViewToEditor(DdrawManagerViewModel parentVm)
        {
            Content = new DdrawManagerEditorView(parentVm);
        }

        internal void SetContentViewToFileFinder(DdrawManagerViewModel parentVm)
        {
            Content = new DdrawManagerPathPointer(parentVm);
        }
    }
}
