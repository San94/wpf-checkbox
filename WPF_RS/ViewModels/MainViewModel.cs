using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WPF_RS;
using WPF_RS.ViewModels;

namespace WPF_RS
{

    public class MainViewModel
    {
        public ObservableCollection<TestViewModel> TestsCollection { get; set; }

        public MainViewModel()
        {
            this.LoadTestsCollection();
        }

        public void LoadTestsCollection()
        {
            IList<Test> testList = new List<Test>
            {
                new Test { Major = 1, Minor = 1 },
                new Test { Major = 1, Minor = 2 },
                new Test { Major = 2, Minor = 1 },
                new Test { Major = 2, Minor = 2 },
                new Test { Major = 2, Minor = 3 },
            };

            TestsCollection = new ObservableCollection<TestViewModel>();
            TestViewModel parent = null;
            List<int> chckMajor = new List<int>();
            bool isInserted = false;

            foreach (var item in testList)
            {
                //New Major thus insert the previous value to parent
                if (isInserted && !chckMajor.Contains(item.Major))
                {
                    TestsCollection.Add(parent);
                }

                if(!chckMajor.Contains(item.Major) && item.Major > 0)
                {
                    parent = new TestViewModel("Test " + item.Major.ToString());
                    chckMajor.Add(item.Major);
                    isInserted = true;
                }

                parent.AddChild(new TestViewModel("Test " + item.Major.ToString() + '.' + item.Minor.ToString()));

                //Check last item
                int lastIndex = testList.Count - 1;
                int itemIndex = testList.IndexOf(item);

                if (itemIndex == lastIndex)
                    TestsCollection.Add(parent);
            }
        }
    }
}