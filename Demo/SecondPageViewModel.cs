using System;
using System.ComponentModel;

namespace Demo
{
    public class SecondPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _text;
        public string Text
        {
            get { return _text; }
            set 
            {
                if (_text != value)
                {
                    _text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
                }
            }

        }
    }
}
