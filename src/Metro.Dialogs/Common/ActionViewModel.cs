using Caliburn.Micro;

namespace Metro.Dialogs
{
    public class ActionViewModel:PropertyChangedBase,IHaveDisplayName
    {
        private string _displayName;
        private string _actionName;
        private bool _isDefault;
        private bool _isCancel;

        public ActionViewModel(string displayName, string actionName,bool isDefault = false,bool isCancel = false)
        {
            IsDefault = isDefault;
            DisplayName = displayName;
            ActionName = actionName;
            IsCancel = isCancel;
        }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (value == _displayName) return;
                _displayName = value;
                NotifyOfPropertyChange(() => DisplayName);
            }
        }

        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (value.Equals(_isDefault)) return;
                _isDefault = value;
                NotifyOfPropertyChange(() => IsDefault);
            }
        }

        public bool IsCancel
        {
            get { return _isCancel; }
            set
            {
                if (value.Equals(_isCancel)) return;
                _isCancel = value;
                NotifyOfPropertyChange(() => IsCancel);
            }
        }

        public string ActionName
        {
            get { return _actionName; }
            set
            {
                if (value == _actionName) return;
                _actionName = value;
                NotifyOfPropertyChange(() => ActionName);
            }
        }
    }
}