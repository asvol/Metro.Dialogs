using System.Diagnostics;
using Caliburn.Micro;

namespace Metro.Dialogs
{
    public class LoginDialogViewModel:Screen
    {
        private LoginDialogView _view;

        public LoginDialogViewModel()
        {
            LoginHistory = new BindableCollection<string>();
        }

        #region Localization

        public string MessageText { get; set; }
        public string UserNameText { get; set; }
        public string PasswordText { get; set; }
        public string LoginButtonText { get; set; }
        public string CancelButtonText { get; set; }

        
        #endregion

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            _view = view as LoginDialogView;
            Debug.Assert(_view != null);
            _view.password.Password = Password;

        }

        public BindableCollection<string> LoginHistory { get; private set; }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                if (value == _login) return;
                _login = value;
                NotifyOfPropertyChange(() => Login);
                if (!string.IsNullOrWhiteSpace(value)) CanTryLogin = true;
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password) return;
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private bool _canTryLogin;
        public bool CanTryLogin
        {
            get { return _canTryLogin; }
            set
            {
                if (value == _canTryLogin) return;
                _canTryLogin = value;
                NotifyOfPropertyChange(() => CanTryLogin);
            }
        }

        public void TryLogin()
        {
            Password = _view.password.Password;
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }
    }
}