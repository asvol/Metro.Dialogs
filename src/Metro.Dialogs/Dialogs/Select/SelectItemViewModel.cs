using Caliburn.Micro;

namespace Metro.Dialogs
{
    public class SelectItemViewModel:PropertyChangedBase,IHaveDisplayName
    {
        private readonly SelectItem _model;


        public SelectItemViewModel(SelectItem model)
        {
            _model = model;
        }

        public string DisplayName
        {
            get { return _model.DisplayName; }

            set {  }
        }

        public string Description
        {
            get { return _model.Description; }
        }

        public SelectItem Model { get { return _model; } }

        public bool Filter(string filterText)
        {
            return _model.Filter(filterText);
        }
    }
}