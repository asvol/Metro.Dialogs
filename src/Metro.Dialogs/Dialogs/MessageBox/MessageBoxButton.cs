namespace Metro.Dialogs
{
    public class MessageBoxButton
    {
        public string Text { get; private set; }
        public object Result { get; private set; }
        public bool IsDefault { get; private set; }
        public bool IsCancel { get; private set; }

        public MessageBoxButton(string text, object result = null, bool isDefault = false, bool isCancel = false)
        {
            Text = text;
            Result = result;
            IsDefault = isDefault;
            IsCancel = isCancel;
        }
    }

    public class MessageBoxButton<TResult> : MessageBoxButton
    {
        public MessageBoxButton(string text, TResult result = default(TResult), bool isDefault = false, bool isCancel = false)
            : base(text, result, isDefault, isCancel)
        {

        }

        public new TResult Result { get { return (TResult)base.Result; } }
    }
}