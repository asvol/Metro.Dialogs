using Caliburn.Micro;

namespace Metro.Dialogs
{
    public class ProgressViewModel : PropertyChangedBase
    {
        private bool _isBusy;
        private string _headerText;
        private string _contentText;
        private double _max;
        private double _min;
        private double _value;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value.Equals(_isBusy)) return;
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                if (value == _headerText) return;
                _headerText = value;
                NotifyOfPropertyChange(() => HeaderText);
            }
        }

        public string ContentText
        {
            get { return _contentText; }
            set
            {
                if (value == _contentText) return;
                _contentText = value;
                NotifyOfPropertyChange(() => ContentText);
            }
        }

        public double Max
        {
            get { return _max; }
            set
            {
                if (value.Equals(_max)) return;
                _max = value;
                NotifyOfPropertyChange(() => Max);
            }
        }

        public double Min
        {
            get { return _min; }
            set
            {
                if (value.Equals(_min)) return;
                _min = value;
                NotifyOfPropertyChange(() => Min);
            }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                if (value.Equals(_value)) return;
                _value = value;
                NotifyOfPropertyChange(() => Value);
            }
        }

        public void BeginProgress(string title,int actionCount)
        {
            Min = 0;
            Value = 0;
            HeaderText = title;
            IsBusy = true;
        }

        public void ProgressAction(string message, int currentAction)
        {
            ContentText = message;
            Min = 0;
            Value = currentAction;
        }

        public void StopProgress()
        {
            Min = 0;
            Value = 0;
            Max = 0;
            HeaderText = null;
            ContentText = null;
            IsBusy = false;
        }
    }
}