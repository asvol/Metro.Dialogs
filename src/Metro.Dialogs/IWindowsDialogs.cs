using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Metro.Dialogs
{
    public interface IWindowsDialogs
    {
        bool? ShowAboutBox(string appName, string appVersion, string appAbout);

        ActionViewModel ShowAboutBox(string appName, string appVersion, string appAbout,
                                     params ActionViewModel[] actions);

        SplashScreenViewModel OpenSplashScreen(string appTitle, string version, string appSubTitle, string organizationName,
                              string allRightReserved = null, string message = null);

        object ShowMessageBox(string caption, string message, MessageBoxIconType icon, MessageBoxHelpButton helpButton,
                              params MessageBoxButton[] buttons);

        TResult ShowMessageBox<TResult>(string caption, string message, MessageBoxIconType icon,
                                        MessageBoxHelpButton helpButton, params MessageBoxButton<TResult>[] buttons);
        TResult ShowMessageBox<TResult>(string caption, string message, MessageBoxIconType icon,
                                        params MessageBoxButton<TResult>[] buttons);

        bool AskUserYesNo(string caption, string message, MessageBoxIconType icon = MessageBoxIconType.Question,
                          MessageBoxHelpButton helpButton = null);

        bool AskUserOkCancel(string caption, string message, MessageBoxIconType icon = MessageBoxIconType.Question,
                             MessageBoxHelpButton helpButton = null);

        void ShowError(string caption, string message, MessageBoxHelpButton helpButton = null);
        void ShowError(string caption, string message, Exception ex);
        void ShowInfo(string caption, string message, MessageBoxHelpButton helpButton = null);
        void ShowWarning(string caption, string message, MessageBoxHelpButton helpButton = null);
        void ShowExceptionInfoDialog(string caption, Exception ex);

        string ShowOpenFileDialog(string caption, string filter = null, string initialDirectory = null);

        string ShowSaveFileDialog(string caption, string defaultExt = null, string filter = null,
                                  string initialDirectory = null);

        string ShowSelectFolderDialog(string caption, string oldPath = null);


        SelectItem SelectItemDialog(string caption, string message, bool filterVisible, params SelectItem[] items);
    }

    
}