using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Metro.Dialogs
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SplashScreenViewModel:Screen
    {
        private string _appTitle;
        private string _appSubTitle;
        private string _version;
        private string _organizationName;
        private string _allRightsReserved;
        private string _message;

        public string AppTitle
        {
            get { return _appTitle; }
            set
            {
                if (value == _appTitle) return;
                _appTitle = value;
                NotifyOfPropertyChange(() => AppTitle);
            }
        }

        public string Version
        {
            get { return _version; }
            set
            {
                if (value == _version) return;
                _version = value;
                NotifyOfPropertyChange(() => Version);
            }
        }

        public string AppSubTitle
        {
            get { return _appSubTitle; }
            set
            {
                if (value == _appSubTitle) return;
                _appSubTitle = value;
                NotifyOfPropertyChange(() => AppSubTitle);
            }
        }

        public string OrganizationName
        {
            get { return _organizationName; }
            set
            {
                if (value == _organizationName) return;
                _organizationName = value;
                NotifyOfPropertyChange(() => OrganizationName);
            }
        }

        public string AllRightsReserved
        {
            get { return _allRightsReserved; }
            set
            {
                if (value == _allRightsReserved) return;
                _allRightsReserved = value;
                NotifyOfPropertyChange(() => AllRightsReserved);
            }
        }

        

        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message) return;
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }
    }
}