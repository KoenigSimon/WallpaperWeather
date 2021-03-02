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
using System.Windows.Forms;

namespace WallpaperWeather
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainWindowViewModel view = new MainWindowViewModel();
        static WeatherHandler weatherHandler;
        public static MainWindow active;
        public MainWindow()
        {
            DataContext = view;
            active = this;
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            Scroll.Content = ImageCacheLoader.LoadImages();

            SettingsLoader.LoadSettings();
            PersistentData currentData = SettingsLoader.GetCurrentData();
            DisplaySettings(currentData);

            weatherHandler = new WeatherHandler(currentData.openWeatherMapAPIKey, currentData.plz);
            DisplayWeatherData();

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(3600);
            LiveTime.Tick += UpdateDataPeriodic;
            LiveTime.Start();

            FillComboboxes();

            ImageChanger.StartImageCycling(weatherHandler);
        }

        private void OptionsUpdated(object sender, RoutedEventArgs e)
        {
            SettingsLoader.changedData.startWithWindows = view.chkBxStartWithWindows;
            SettingsLoader.changedData.changeInBackground = view.chkBxChangeInBackground;
            SettingsLoader.changedData.autoImageSearch = view.chkBxAutoImageSearch;
            SettingsLoader.UpdateSettings();
            SettingsLoader.ApplyAutoStart();
        }

        private void TextOptionsUpdated(object sender, TextChangedEventArgs args)
        {
            SettingsLoader.changedData.maxImageCount = Convert.ToInt32(view.maxImageCount);
            SettingsLoader.changedData.plz = view.plz;
            SettingsLoader.changedData.openWeatherMapAPIKey = view.apiKey;
            SettingsLoader.UpdateSettings();
        }

        private void ComboboxUpdated(object sender, SelectionChangedEventArgs args)
        {
            if (view.imageSelection == null || view.imageSelection == "") return;
            PersistentData data = new PersistentData(SettingsLoader.GetCurrentData());

            for (int i = 0; i < data.imageData.Count; i++)
            {
                if(data.imageData[i].fileName == view.imageSelection)
                {
                    DataStructures.ImageData temp = data.imageData[i];
                    temp.targetDaytime = Helperfunctions.ConvertComboIntToDaytime(view.selectedItemDayTime);
                    temp.targetSeason = Helperfunctions.ConvertComboIntToSeason(view.selectedItemSeason);
                    temp.targetWeather = Helperfunctions.ConvertComboIntToWeather(view.selectedItemWeather);
                    data.imageData[i] = temp;
                    SettingsLoader.changedData = data;
                    SettingsLoader.UpdateSettings();
                }
            }
        }

        private void BanUseUpdated(object sender, RoutedEventArgs e)
        {
            if (view.imageSelection == null || view.imageSelection == "") return;
            PersistentData data = new PersistentData(SettingsLoader.GetCurrentData());

            for (int i = 0; i < data.imageData.Count; i++)
            {
                if (data.imageData[i].fileName == view.imageSelection)
                {
                    DataStructures.ImageData temp = data.imageData[i];
                    temp.banUse = view.chkBxBanUse;
                    data.imageData[i] = temp;
                    SettingsLoader.changedData = data;
                    SettingsLoader.UpdateSettings();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Passthrough to handler
            TrayHandler.MinimizeToTray(this, e);
        }

        private void ClickImportImages(object sender, RoutedEventArgs e)
        {
            PathHandling.ImportFiles();
            Scroll.Content = null;
            Scroll.Content = ImageCacheLoader.LoadImages();
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
            if (view.imageSelection == null || view.imageSelection == "") return;
            PersistentData data = new PersistentData(SettingsLoader.GetCurrentData());

            //dont delete active wallpaper
            if (new Uri(view.imageSelection) == new Uri(Wallpaper.active)) return;

            for (int i = 0; i < data.imageData.Count; i++)
            {
                if (data.imageData[i].fileName == view.imageSelection)
                {
                    ImageCacheLoader.UnloadImage(data.imageData[i].fileName, (WrapPanel)Scroll.Content);
                    SelectedImageBox.Source = null;
                    PathHandling.DeleteFile(data.imageData[i].fileName);
                    return;
                }
            }
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

        private void FillComboboxes()
        {
            //Order is important
            view.comboItemsWeather = new ObservableCollection<string>();
            view.comboItemsWeather.Add("Sunny");
            view.comboItemsWeather.Add("Light Clouds");
            view.comboItemsWeather.Add("Clouds");
            view.comboItemsWeather.Add("Rain");
            view.comboItemsWeather.Add("Thunderstorm");

            view.comboItemsSeason = new ObservableCollection<string>();
            view.comboItemsSeason.Add("Spring");
            view.comboItemsSeason.Add("Summer");
            view.comboItemsSeason.Add("Autumn");
            view.comboItemsSeason.Add("Winter");

            view.comboItemsDayTime = new ObservableCollection<string>();
            view.comboItemsDayTime.Add("Dawn");
            view.comboItemsDayTime.Add("Day");
            view.comboItemsDayTime.Add("Dusk");
            view.comboItemsDayTime.Add("Night");
        }

        private void DisplayWeatherData()
        {
            WeatherData data = weatherHandler.GetCurrentWeatherData();
            if (data == null) return;

            view.city = data.data.name;

            TimeSpan timeZone = TimeSpan.FromSeconds(data.data.timezone);
            string relative = data.data.timezone >= 0 ? "Timezone: GMT +" : "GMT -";
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

        public void ImageClicked(Image sender)
        {
            string filePath = sender.Source.ToString();
            view.imageSelection = filePath;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(filePath);
            image.EndInit();
            SelectedImageBox.Source = image;
            PersistentData data = SettingsLoader.GetCurrentData();

            for (int i = 0; i < data.imageData.Count(); i++)
            {
                if (data.imageData[i].fileName == filePath)
                {
                    //update displayed imagedata
                    view.selectedItemWeather = Helperfunctions.ConvertWeatherEnumToComboInt(data.imageData[i].targetWeather);
                    view.selectedItemDayTime = Helperfunctions.ConvertDayTimeToComboInt(data.imageData[i].targetDaytime);
                    view.selectedItemSeason = Helperfunctions.ConvertSeasonToComboInt(data.imageData[i].targetSeason);
                    view.chkBxBanUse = data.imageData[i].banUse;
                    return;
                }
            }

            //file has no data yet, write entry
            DataStructures.ImageData newEntry = new DataStructures.ImageData();
            newEntry.fileName = filePath;
            newEntry.targetDaytime = DataStructures.enumDayTime.DAWN;
            newEntry.targetSeason = DataStructures.enumSeason.SPRING;
            newEntry.targetWeather = DataStructures.enumWeather.CLEAR_SKY;
            newEntry.banUse = false;
            data.imageData.Add(newEntry);
            SettingsLoader.changedData.imageData = data.imageData;
            SettingsLoader.UpdateSettings();
            ImageClicked(sender);
        }
    }
}
