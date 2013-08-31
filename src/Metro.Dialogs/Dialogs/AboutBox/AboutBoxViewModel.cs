using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Metro.Dialogs
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AboutBoxViewModel : Conductor<ActionViewModel>.Collection.OneActive
    {
        private string _appName;
        private string _appVersion;
        private string _appAbout;

        public string AppName
        {
            get { return _appName; }
            set
            {
                if (value == _appName) return;
                _appName = value;
                NotifyOfPropertyChange(() => AppName);
            }
        }

        public string AppVersion
        {
            get { return _appVersion; }
            set
            {
                if (value == _appVersion) return;
                _appVersion = value;
                NotifyOfPropertyChange(() => AppVersion);
            }
        }

        public string AppAbout
        {
            get { return _appAbout; }
            set
            {
                if (value == _appAbout) return;
                _appAbout = value;
                NotifyOfPropertyChange(() => AppAbout);
            }
        }

        public ActionViewModel SelectedAction { get; private set; }

        public void ExecuteAction(ActionViewModel vm)
        {
            SelectedAction = vm;
            TryClose(true);
        }

        public void SayBack()
        {
            SelectedAction = null;
            TryClose(false);
        }

    }
}