using System;

namespace Metro.Dialogs
{
    public class MessageBoxHelpButton
    {
        public MessageBoxHelpButton(string text,Action action)
        {
            if (text == null) throw new ArgumentNullException("text");
            if (action == null) throw new ArgumentNullException("action");
            Action = action;
            Text = text;
        }

        public string Text { get; set; }
        public Action Action { get; private set; }
    }
}