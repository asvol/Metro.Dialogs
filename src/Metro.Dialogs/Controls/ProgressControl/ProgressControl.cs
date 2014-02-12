using System.Windows;
using System.Windows.Controls;

namespace Metro.Dialogs
{
    public class ProgressControl : ContentControl
    {
        static ProgressControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressControl), new FrameworkPropertyMetadata(typeof(ProgressControl)));
        }

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof (bool), typeof (ProgressControl), new PropertyMetadata(default(bool)));

        public bool IsBusy
        {
            get { return (bool) GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty HeaderTextProperty =
            DependencyProperty.Register("HeaderText", typeof (string), typeof (ProgressControl), new PropertyMetadata(default(string)));

        public string HeaderText
        {
            get { return (string) GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static readonly DependencyProperty ContentTextProperty =
            DependencyProperty.Register("ContentText", typeof (string), typeof (ProgressControl), new PropertyMetadata(default(string)));

        public string ContentText
        {
            get { return (string) GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof (double), typeof (ProgressControl), new PropertyMetadata(default(double)));

        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof (double), typeof (ProgressControl), new PropertyMetadata(default(double)));

        public double Min
        {
            get { return (double) GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof (double), typeof (ProgressControl), new PropertyMetadata(default(double)));

        public double Max
        {
            get { return (double) GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }   
    }
}
