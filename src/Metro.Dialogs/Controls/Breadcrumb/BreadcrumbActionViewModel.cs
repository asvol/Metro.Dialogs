using Caliburn.Micro;
using Action = System.Action;

namespace Metro.Dialogs
{
    public class BreadcrumbActionViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private readonly Action _callback;
        private string _displayName;
        private bool _canExecute;

        public BreadcrumbActionViewModel()
        {
            
        }

        public BreadcrumbActionViewModel(Action callback)
        {
            _callback = callback;
        }

        public void Execute()
        {
            if (_callback != null) _callback();
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (value.Equals(_canExecute)) return;
                _canExecute = value;
                NotifyOfPropertyChange(() => CanExecute);
            }
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
    }
}