using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;


namespace Metro.Dialogs.Controls
{
    public class Breadcrumb:ContentControl
    {
        static Breadcrumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Breadcrumb), new FrameworkPropertyMetadata(typeof(Breadcrumb)));
        }

        public Breadcrumb()
        {
            Items = new ObservableCollection<BreadcrumbActionViewModel>();
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<BreadcrumbActionViewModel>), typeof(Breadcrumb), new PropertyMetadata(default(ObservableCollection<BreadcrumbActionViewModel>)));

        public ObservableCollection<BreadcrumbActionViewModel> Items
        {
            get { return (ObservableCollection<BreadcrumbActionViewModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }



        public static readonly DependencyProperty SeparatorProperty =
            DependencyProperty.Register("Separator", typeof (string), typeof (Breadcrumb), new PropertyMetadata(default(string)));

        public string Separator
        {
            get { return (string) GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

       
    }
}