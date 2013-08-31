using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using Caliburn.Micro;
using Metro.Dialogs.Properties;

namespace Metro.Dialogs
{
    [Export(typeof(IWindowsDialogs))]
    [PartCreationPolicy(CreationPolicy.Any)]
    public class WindowsDialogs : IWindowsDialogs
    {
        private readonly IWindowManager _windowManager;
        public static readonly string YesButtonText = Resources.DialogServiceExtentios_YesButtonText_Yes;
        public static readonly string NoButtonText = Resources.DialogServiceExtentios_NoButtonText_No;
        public static readonly string OkButtonText = Resources.DialogServiceExtentios_OkButtonText_Ok;
        public static readonly string CancelButtonText = Resources.DialogServiceExtentios_CancelButtonText_Cancel;
        private static readonly string ExceptionDialogText = Resources.DialogServiceExtentios_ExceptionDialogText_Additional;
        private static readonly string SelectButtonText = "Select";
        private static readonly string FilterLabel = "Filter...";


        [ImportingConstructor]
        public WindowsDialogs(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        #region splash screen

        public void OpenSplashScreen(string appTitle,string version,string appSubTitle,string organizationName, string allRightReserved = null ,string message = null)
        {
            var vm = new SplashScreenViewModel
                         {
                             DisplayName = appTitle,
                             AppTitle = appTitle,
                             AppSubTitle = appSubTitle,
                             OrganizationName = organizationName,
                             AllRightReserved = allRightReserved,
                             Message = message,
                         };
            _windowManager.ShowDialog(vm);
        }

        #endregion


        #region About box

        public bool? ShowAboutBox(string appName, string appVersion, string appAbout)
        {
            var dlg = new AboutBoxViewModel
                          {
                              AppName = appName, 
                              AppVersion = appVersion, 
                              AppAbout = appAbout
                          };
            return _windowManager.ShowDialog(dlg);
        }

        public ActionViewModel ShowAboutBox(string appName, string appVersion, string appAbout, params ActionViewModel[] actions)
        {
            ActionViewModel result = null;
            Execute.OnUIThread(() =>
                                   {
                                       var dlg = IoC.Get<AboutBoxViewModel>();
                                       dlg.AppName = appName;
                                       dlg.AppVersion = appVersion;
                                       dlg.AppAbout = appAbout;
                                       foreach (var actionViewModel in actions)
                                       {
                                           dlg.Items.Add(actionViewModel);
                                       }
                                       _windowManager.ShowDialog(dlg);
                                       result = dlg.SelectedAction;
                                   });
            return result;
        }

        #endregion

        #region Message box

        public object ShowMessageBox(string caption, string message, MessageBoxIconType icon, MessageBoxHelpButton helpButton, params MessageBoxButton[] buttons)
        {
            object result = null;
            Execute.OnUIThread(() =>
                                   {
                                       var viewModel = new MessageBoxViewModel { DisplayName = caption, Message = message, Icon = icon };
                                       if (buttons != null)
                                       {
                                           foreach (var messageBoxButton in buttons)
                                           {
                                               viewModel.AddButton(messageBoxButton);
                                           }
                                       }
                                       if (helpButton != null)
                                       {
                                           viewModel.HelpButtonCallback = helpButton.Action;
                                           viewModel.HelpButtonText = helpButton.Text;
                                       }
                                       _windowManager.ShowDialog(viewModel);
                                       result = viewModel.DialogResult;
                                   });
            return result;
        }

        public  TResult ShowMessageBox<TResult>(string caption, string message, MessageBoxIconType icon, MessageBoxHelpButton helpButton, params MessageBoxButton<TResult>[] buttons)
        {
            return (TResult)this.ShowMessageBox(caption, message, icon, helpButton, buttons.Cast<MessageBoxButton>().ToArray());
        }

        public  TResult ShowMessageBox<TResult>( string caption, string message, MessageBoxIconType icon, params MessageBoxButton<TResult>[] buttons)
        {
            return (TResult)this.ShowMessageBox(caption, message, icon, null, buttons);
        }

        public  bool AskUserYesNo( string caption, string message, MessageBoxIconType icon = MessageBoxIconType.Question, MessageBoxHelpButton helpButton = null)
        {
            return this.ShowMessageBox(caption, message, icon, helpButton,
                                       new MessageBoxButton<bool>(YesButtonText, true, true),
                                       new MessageBoxButton<bool>(NoButtonText, false, false, true));
        }

        public  bool AskUserOkCancel( string caption, string message, MessageBoxIconType icon = MessageBoxIconType.Question, MessageBoxHelpButton helpButton = null)
        {
            return this.ShowMessageBox(caption, message, icon, helpButton,
                                       new MessageBoxButton<bool>(OkButtonText, true, true),
                                       new MessageBoxButton<bool>(CancelButtonText, false, false, true));
        }

        public  void ShowError( string caption, string message, MessageBoxHelpButton helpButton = null)
        {
            this.ShowMessageBox(caption, message, MessageBoxIconType.Error, helpButton, new MessageBoxButton(OkButtonText, null, true, true));
        }

        public  void ShowError( string caption, string message, Exception ex)
        {
            this.ShowMessageBox(caption, message, MessageBoxIconType.Error, new MessageBoxHelpButton(ExceptionDialogText, () => this.ShowExceptionInfoDialog(ExceptionDialogText, ex)), new MessageBoxButton(OkButtonText, null, true, true));
        }

        public  void ShowInfo( string caption, string message, MessageBoxHelpButton helpButton = null)
        {
            this.ShowMessageBox(caption, message, MessageBoxIconType.Info, helpButton, new MessageBoxButton(OkButtonText, null, true, true));
        }

        public  void ShowWarning( string caption, string message, MessageBoxHelpButton helpButton = null)
        {
            this.ShowMessageBox(caption, message, MessageBoxIconType.Warning, helpButton, new MessageBoxButton(OkButtonText, null, true, true));
        }

        public  void ShowExceptionInfoDialog( string caption, Exception ex)
        {
            this.ShowError(caption, ex.ToString());
        }

        #endregion

        

        #region file dialogs

        public string ShowOpenFileDialog( string caption, string filter = null, string initialDirectory = null)
        {
            string filename = null;
            Execute.OnUIThread(() =>
            {
                var ofd = new Microsoft.Win32.OpenFileDialog
                {
                    Title = caption,
                    CheckFileExists = true,
                    RestoreDirectory = true,
                    InitialDirectory = initialDirectory,
                    Multiselect = true,
                    Filter = filter
                };

                if (ofd.ShowDialog() == true)
                    filename = ofd.FileName;
            });
            return filename;
        }

        public string ShowSaveFileDialog( string caption, string defaultExt = null, string filter = null, string initialDirectory = null)
        {
            string folder = null;
            Execute.OnUIThread(() =>
            {
                var ofd = new Microsoft.Win32.SaveFileDialog
                {
                    Title = caption,
                    DefaultExt = defaultExt,
                    InitialDirectory = initialDirectory,
                    CheckFileExists = false,
                    RestoreDirectory = true,
                    Filter = filter
                };
                folder = ofd.ShowDialog() == true ? ofd.FileName : null;
            });

            return folder;
        }

        public string ShowSelectFolderDialog( string caption, string oldPath = null)
        {
            string folder = null;
            Execute.OnUIThread(() =>
            {
                var folderBrowser = new FolderBrowserDialog
                {
                    SelectedPath = oldPath,
                    Description = caption,
                    ShowNewFolderButton = true,
                };
                folder = folderBrowser.ShowDialog() == DialogResult.OK ? folderBrowser.SelectedPath : null;
            });
            return folder;
        }

        
        #endregion


        #region Select item/items

        public SelectItem SelectItemDialog(string caption, string message, bool filterVisible, params SelectItem[] items)
        {
            SelectItem result = null;
            Execute.OnUIThread(() =>
            {
                var vm = new SelectItemDialogViewModel
                {
                    DisplayName = caption,
                    Message = message,
                    SelectButtonText = SelectButtonText,
                    CancelButtonText = CancelButtonText,
                    FilterLabel = FilterLabel,
                    FilterVisible = filterVisible,
                };
                vm.Items.AddRange(items.Select(_ => new SelectItemViewModel(_)));
                var res = _windowManager.ShowDialog(vm);
                if (res == true && vm.SelectedItem != null)
                {
                    result = vm.SelectedItem.Model;
                }

            });

            return result;
        }


        #endregion
    }
}