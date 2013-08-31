using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Caliburn.Micro;

namespace Metro.Dialogs
{
    public class SelectItemDialogViewModel:Conductor<SelectItemViewModel>.Collection.OneActive
    {
        private SelectItemViewModel _selectedItem;
        private string _message;
        private string _selectButtonText;
        private string _cancelButtonText;
        private string _filterText;
        private bool _filterVisible;
        private string _filterLabel;

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

        public SelectItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
            }
        }

        public string SelectButtonText
        {
            get { return _selectButtonText; }
            set
            {
                if (value == _selectButtonText) return;
                _selectButtonText = value;
                NotifyOfPropertyChange(() => SelectButtonText);
            }
        }

        public string CancelButtonText
        {
            get { return _cancelButtonText; }
            set
            {
                if (value == _cancelButtonText) return;
                _cancelButtonText = value;
                NotifyOfPropertyChange(() => CancelButtonText);
            }
        }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (value == _filterText) return;
                _filterText = value;
                NotifyOfPropertyChange(() => FilterText);
                UpdateFilter();
            }
        }

        private void UpdateFilter()
        {
            var collView = CollectionViewSource.GetDefaultView(Items);
            if (collView == null)
            {
                return;
            }
            if (!collView.CanFilter)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                collView.Filter = null;
            }
            else
            {
                collView.Filter = o => ((SelectItemViewModel)o).Filter(FilterText);
            }
            SelectedItem = Items.FirstOrDefault();
        }

        public void DoubleClick(SelectItemViewModel viewModel)
        {
            SelectedItem = viewModel;
            Select();
            
        }

        public void Select()
        {
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }

       

        public bool FilterVisible
        {
            get { return _filterVisible; }
            set
            {
                if (value.Equals(_filterVisible)) return;
                _filterVisible = value;
                NotifyOfPropertyChange(() => FilterVisible);
            }
        }

        public string FilterLabel
        {
            get { return _filterLabel; }
            set
            {
                if (value == _filterLabel) return;
                _filterLabel = value;
                NotifyOfPropertyChange(() => FilterLabel);
            }
        }
    }
}