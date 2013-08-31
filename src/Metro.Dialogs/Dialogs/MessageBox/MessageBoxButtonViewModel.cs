using System;
using Caliburn.Micro;
using Metro.Dialogs;

namespace Metro.Dialogs
{
    public class MessageBoxButtonViewModel:PropertyChangedBase,IHaveDisplayName
    {
        private readonly MessageBoxViewModel _owner;
        private readonly MessageBoxButton _button;

        public MessageBoxButtonViewModel(MessageBoxViewModel owner, MessageBoxButton button)
        {
            if (owner == null) throw new ArgumentNullException("owner");
            if (button == null) throw new ArgumentNullException("button");
            _owner = owner;
            _button = button;
        }

        public void Execute()
        {
            _owner.InternalExecuteButton(_button);
        }

        public bool IsDefault
        {
            get { return _button.IsDefault; }
        }

        public bool IsCancel
        {
            get { return _button.IsCancel; }
        }

        #region Implementation of IHaveDisplayName

        public string DisplayName
        {
            get { return _button.Text; }
            set {  }
        }

        #endregion
    }
}