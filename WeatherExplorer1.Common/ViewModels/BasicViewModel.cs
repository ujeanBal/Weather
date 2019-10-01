using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using WeatherExplorer1.Models;

namespace WeatherExplorer1
{
    public class BasicViewModel :ViewModelBase
    {
      

        public BasicViewModel()
        {
           
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { Set(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }
    }
}
