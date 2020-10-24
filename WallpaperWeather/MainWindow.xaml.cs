using System;
using System.Collections.Generic;
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
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace WallpaperWeather
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ImageCacheLoader.LoadImagesFromCache(Scroll);
            city = "testingen";
            time = "4:20";
            temperature = "69°C";
            timeZone = "Cool";
            plz = "PLZ";
        }

        //enums
        public enum enumWeather
        {
            CLOUDS,
            CLOUDSRAINY,
            THUNDERSTORM,
            SUNNY,
            SUNNYCLOUDS
        }
        public enum dayTime
        {
            DAWN,
            DUSK,
            DAY,
            NIGHT
        }
        public enum season
        {
            SPRING,
            SUMMER,
            AUTUMN,
            WINTER
        }

        //selected item Properties
        private bool _chkBxBanUse;
        public bool chkBxBanUse
        {
            get { return _chkBxBanUse; }
            set {
                _chkBxBanUse = value;
                OnPropertyChanged();
            }
        }
        public List<string> comboItemsWeather = new List<string>();
        public List<string> comboItemsDayTime = new List<string>();
        public List<string> comboItemsSeason = new List<string>();

        //localization Properties
        private string _temperature;
        public string temperature
        {
            get { return _temperature; }
            set {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        private string _city;
        public string city { 
            get { return _city; }
            set { 
                _city = value;
                OnPropertyChanged();
            } 
        }

        private string _time;
        public string time
        {
            get { return _time; }
            set {
                _time = value;
                OnPropertyChanged();
            }
        }

        private Image _weatherIcon;
        public Image weatherIcon
        {
            get { return _weatherIcon; }
            set {
                _weatherIcon = value;
                OnPropertyChanged();
            }
        }

        private string _plz;
        public string plz
        {
            get { return _plz; }
            set {
                _plz = value;
                OnPropertyChanged();
            }
        }

        private string _timeZone;
        public string timeZone
        {
            get { return _timeZone; }
            set {
                _timeZone = value;
                OnPropertyChanged();
            }
        }

        //option Properties
        private bool _chkBxStartWithWindows;
        public bool chkBxStartWithWindows
        {
            get { return _chkBxStartWithWindows; }
            set {
                _chkBxStartWithWindows = value;
                OnPropertyChanged();
            }
        }
        private bool _chkBxChangeInBackground;
        public bool chkBxChangeInBackground
        {
            get { return _chkBxChangeInBackground; }
            set {
                _chkBxChangeInBackground = value;
                OnPropertyChanged();
            }
        }
        private bool _chkBxAutoImageSearch;
        public bool chkBxAutoImageSearch
        {
            get { return _chkBxAutoImageSearch; }
            set {
                _chkBxAutoImageSearch = value;
                OnPropertyChanged();
            }
        }
        private string _maxImageCount;
        public string maxImageCount
        {
            get { return _maxImageCount; }
            set {
                _maxImageCount = value;
                OnPropertyChanged();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Passthrough to handler
            TrayHandler.MinimizeToTray(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClickImportImages(object sender, RoutedEventArgs e)
        {

        }

        private void ClickClearCache(object sender, RoutedEventArgs e)
        {

        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void ClickDeleteImage(object sender, RoutedEventArgs e)
        {

        }
    }
}
