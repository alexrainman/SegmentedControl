using System;
using PropertyChanged;

namespace Demo
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public MainViewModel()
        {
            SelectedSegment = 3;
        }

        public int SelectedSegment { get; set; }
    }
}
