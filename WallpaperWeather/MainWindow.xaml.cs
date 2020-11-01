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
using System.Drawing.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace WallpaperWeather
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainWindowViewModel view = new MainWindowViewModel();
        static WeatherHandler weatherHandler;

        public MainWindow()
        {
            DataContext = view;
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            ImageCacheLoader.LoadImagesFromCache(Scroll);

            SettingsLoader.LoadSettings();
            PersistentData currentData = SettingsLoader.GetCurrentData();
            DisplaySettings(currentData);

            weatherHandler = new WeatherHandler(currentData.openWeatherMapAPIKey, currentData.plz);
            DisplayWeatherData();

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += UpdateDataPeriodic;
            LiveTime.Start();

            //v kommt noch weg
            view.comboItemsWeather = new ObservableCollection<string>();
            view.comboItemsWeather.Add("testitem");
            view.comboItemsWeather.Add("testite2m");
        }

        private void OptionsUpdated(object sender, RoutedEventArgs e)
        {
            SettingsLoader.changedData.startWithWindows = view.chkBxStartWithWindows;
            SettingsLoader.changedData.changeInBackground = view.chkBxChangeInBackground;
            SettingsLoader.changedData.autoImageSearch = view.chkBxAutoImageSearch;
            SettingsLoader.UpdateSettings();
        }

        private void TextOptionsUpdated(object sender, TextChangedEventArgs args)
        {
            SettingsLoader.changedData.maxImageCount = Convert.ToInt32(view.maxImageCount);
            SettingsLoader.changedData.plz = view.plz;
            SettingsLoader.changedData.openWeatherMapAPIKey = view.apiKey;
            SettingsLoader.UpdateSettings();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Passthrough to handler
            TrayHandler.MinimizeToTray(this, e);
        }

        private void ClickImportImages(object sender, RoutedEventArgs e)
        {

        }

        private void ClickClearCache(object sender, RoutedEventArgs e)
        {

        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Environment.Exit(0);
        }

        private void ClickDeleteImage(object sender, RoutedEventArgs e)
        {

        }
        
        private void DisplaySettings(PersistentData data)
        {
            PersistentData temp = new PersistentData(data);
            view.timeZone = temp.timeZone;
            view.plz = temp.plz;
            view.maxImageCount = temp.maxImageCount.ToString();
            view.chkBxStartWithWindows = (bool)temp.startWithWindows;
            view.chkBxChangeInBackground = (bool)temp.changeInBackground;
            view.chkBxAutoImageSearch = (bool)temp.autoImageSearch;
            view.apiKey = temp.openWeatherMapAPIKey;
        }

        private void DisplayWeatherData()
        {
            WeatherData data = weatherHandler.GetCurrentWeatherData();
            if (data == null) return;

            view.city = data.data.name;

            TimeSpan timeZone = TimeSpan.FromSeconds(data.data.timezone);
            string relative = data.data.timezone >= 0 ? "GMT +" : "GMT -";
            relative += string.Format("{0:D2}:{1:D2}", timeZone.Hours, timeZone.Minutes);
            view.timeZone = relative;

            view.temperature = (int)(data.data.main.temp -273.15) + "°C";

            view.weatherIcon = PathHandling.GetCorrespondingIconPath(Helperfunctions.ConvertOWMDescrToWeather(data.data.weather[0].description), true);
        }

        private void UpdateDataPeriodic(object sender, EventArgs e)
        {
            view.time = DateTime.Now.ToString("HH:mm");
            DisplayWeatherData();
        }
    }
}
