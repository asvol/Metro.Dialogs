using Caliburn.Micro;
using Metro.Dialogs;
using Action = System.Action;

namespace Metro.Dialogs
{
    public class MessageBoxViewModel:Screen
    {
        public MessageBoxViewModel()
        {
            Items = new BindableCollection<MessageBoxButtonViewModel>();
        }

        internal void InternalExecuteButton(MessageBoxButton button)
        {
            DialogResult = button.Result;
            TryClose(true);
        }

        private MessageBoxIconType _icon;
        public MessageBoxIconType Icon
        {
            get { return _icon; }
            set
            {
                if (value == _icon) return;
                _icon = value;
                NotifyOfPropertyChange(() => Icon);
            }
        }

        #region Help button

        public bool IsHelpVisible { get { return HelpButtonCallback != null; } }

        public string HelpButtonText { get; set; }
        public Action HelpButtonCallback { get; set; }

        public void OpenHelp()
        {
            if (HelpButtonCallback != null) HelpButtonCallback();
        }

        #endregion


        public void AddButton(MessageBoxButton button)
        {
            Items.Add(new MessageBoxButtonViewModel(this, button));
        }

        public BindableCollection<MessageBoxButtonViewModel> Items { get; private set; }

        private string _message;
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

        public object DialogResult { get; private set; }
    }
}