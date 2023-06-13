using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_RS.ViewModels;

namespace WPF_RS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModellInstance { get; set; }
        public ObservableCollection<TestViewModel> testViewCollection = new ObservableCollection<TestViewModel>();

        public MainWindow()
        {
            InitializeComponent();
            MainViewModellInstance = new MainViewModel();
            testViewCollection = MainViewModellInstance.TestsCollection;
            this.DataContext = MainViewModellInstance;
        }

        public void OnClickExpand(object sender, RoutedEventArgs e)
        {
            foreach(object item in this.TreeView1.Items)
            {
                TreeViewItem trItem = this.TreeView1.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (trItem != null)
                {
                    ToggleAll(trItem, true);
                }
                trItem.IsExpanded  = true;
            }
        }

        public void OnClickCollapse(object sender, RoutedEventArgs e)
        {
            foreach (object item in this.TreeView1.Items)
            {
                TreeViewItem trItem = this.TreeView1.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (trItem != null)
                {
                    ToggleAll(trItem, false);
                }
                trItem.IsExpanded = false;
            }
        }

        public void ToggleAll(ItemsControl items, bool expand)
        {
            foreach (object obj in items.Items)
            {
                ItemsControl childControl = items.ItemContainerGenerator.ContainerFromItem(obj) as ItemsControl;
                if (childControl != null)
                {
                    ToggleAll(childControl, expand);
                }
                TreeViewItem item = childControl as TreeViewItem;
                if (item != null)
                    item.IsExpanded = expand;
            }
        }
    
        public void OnClickBack(object sender, RoutedEventArgs e)
        {
            foreach (var a in this.testViewCollection)
            {
                a.IsSelected = false;
            }
            BackBtn.IsEnabled = false;
            StartBtn.IsEnabled = false;
        }

        public void OnClickStart(object sender, RoutedEventArgs e)
        {
            var result = this.testViewCollection.SelectMany(a=> a.Children.Where(b => b.IsSelected == true).Select(i=>i.Label)).ToList();

            MessageBox.Show(string.Join("\n", result));
        }
        

        public void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            //var testItems = MainViewModellInstance.TestsCollection;
            bool isClicked = false;
            foreach (var parent in this.testViewCollection)
            {
                foreach(var child in parent.Children)
                {
                    if(child.IsSelected)
                        isClicked = true;
                }   
            }

            if (isClicked)
            {
                BackBtn.IsEnabled = true;
                StartBtn.IsEnabled = true;
            }
            else
            {
                BackBtn.IsEnabled = false;
                StartBtn.IsEnabled = false;
            }
        }
    }
}
