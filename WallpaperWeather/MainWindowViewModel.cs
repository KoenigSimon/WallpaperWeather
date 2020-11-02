using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace WallpaperWeather
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region SelectedItem Properties

        private bool _chkBxBanUse;
        public bool chkBxBanUse
        {
            get { return _chkBxBanUse; }
            set
            {
                _chkBxBanUse = value;
                OnPropertyChanged();
            }
        }


        private string _imageSelection;
        public string imageSelection
        {
            get { return _imageSelection;  }
            set {
                _imageSelection = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<string> _comboItemsWeather;
        public ObservableCollection<string> comboItemsWeather
        {
            get { return _comboItemsWeather; }
            set
            {
                _comboItemsWeather = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<string> _comboItemsDayTime;
        public ObservableCollection<string> comboItemsDayTime
        {
            get { return _comboItemsDayTime; }
            set
            {
                _comboItemsDayTime = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<string> _comboItemsSeason;
        public ObservableCollection<string> comboItemsSeason
        {
            get { return _comboItemsSeason; }
            set
            {
                _comboItemsSeason = value;
                OnPropertyChanged();
            }
        }


        private int _selectedItemWeather;
        public int selectedItemWeather
        {
            get { return _selectedItemWeather; }
            set
            {
                _selectedItemWeather = value;
                OnPropertyChanged();
            }
        }


        private int _selectedItemDayTime;
        public int selectedItemDayTime
        {
            get { return _selectedItemDayTime; }
            set
            {
                _selectedItemDayTime = value;
                OnPropertyChanged();
            }
        }


        private int _selectedItemSeason;
        public int selectedItemSeason
        {
            get { return _selectedItemSeason; }
            set
            {
                _selectedItemSeason = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Localization Properties

        private string _temperature;
        public string temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }


        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }


        private string _time;
        public string time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }


        private string _weatherIcon;
        public string weatherIcon
        {
            get { return _weatherIcon; }
            set
            {
                _weatherIcon = value;
                OnPropertyChanged();
            }
        }


        private string _plz;
        public string plz
        {
            get { return _plz; }
            set
            {
                _plz = value;
                OnPropertyChanged();
            }
        }


        private string _timeZone;
        public string timeZone
        {
            get { return _timeZone; }
            set
            {
                _timeZone = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Option Properties

        private bool _chkBxStartWithWindows;
        public bool chkBxStartWithWindows
        {
            get { return _chkBxStartWithWindows; }
            set
            {
                _chkBxStartWithWindows = value;
                OnPropertyChanged();
            }
        }


        private bool _chkBxChangeInBackground;
        public bool chkBxChangeInBackground
        {
            get { return _chkBxChangeInBackground; }
            set
            {
                _chkBxChangeInBackground = value;
                OnPropertyChanged();
            }
        }


        private bool _chkBxAutoImageSearch;
        public bool chkBxAutoImageSearch
        {
            get { return _chkBxAutoImageSearch; }
            set
            {
                _chkBxAutoImageSearch = value;
                OnPropertyChanged();
            }
        }


        private string _maxImageCount;
        public string maxImageCount
        {
            get { return _maxImageCount; }
            set
            {
                //only numbers
                byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
                for (int i = 0; i < asciiBytes.Length; i++)
                {
                    if (asciiBytes[i] < 48 || asciiBytes[i] > 57) return;
                }
                _maxImageCount = value;
                OnPropertyChanged();
            }
        }

        private string _apiKey;
        public string apiKey
        {
            get { return _apiKey; }
            set
            {
                _apiKey = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
