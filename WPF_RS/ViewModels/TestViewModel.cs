using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_RS.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TestViewModel> children { get; set; }
        public ObservableCollection<TestViewModel> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }

        private string label;
        public string Label
        {
            get { return label;  }
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
                CheckChildSelected(value);
            }
        }

        //private bool isExpanded;
        //public bool IsExpanded
        //{
        //    get { return isExpanded; }
        //    set
        //    {
        //        isExpanded = value;
        //        OnPropertyChanged("IsExpanded");
        //    }
        //}

        public TestViewModel(string label, bool isSelected)
        {
            Children = new ObservableCollection<TestViewModel>();
            Label = label;
            IsSelected = isSelected;
        }

        public TestViewModel(string label)
            : this(label, false)
        {
        }

        public TestViewModel()
        {
            Children = new ObservableCollection<TestViewModel>();
        }

        public void AddChild(TestViewModel child)
        {
            Children.Add(child);
        }

        public void CheckChildSelected(bool value)
        {
            foreach (TestViewModel m in children)
            {
                m.IsSelected = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
