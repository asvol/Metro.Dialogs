using System;

namespace Metro.Dialogs
{
    public class SelectItem
    {
        private readonly Func<string, bool> _textFilter;
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public object Tag { get; set; }

        public SelectItem(string displayName,string description,object tag,Func<string,bool> textFilter = null)
        {
            _textFilter = textFilter;
            DisplayName = displayName;
            Description = description;
            Tag = tag;
        }

        public bool Filter(string filterText)
        {
            if (_textFilter == null) return false;
            try
            {
                return _textFilter(filterText);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}