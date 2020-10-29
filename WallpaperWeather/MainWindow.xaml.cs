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

namespace WallpaperWeather
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainWindowViewModel view = new MainWindowViewModel();
        public MainWindow()
        {
            DataContext = view;
            InitializeComponent();

            ImageCacheLoader.LoadImagesFromCache(Scroll);
            SettingsLoader.LoadSettings();

            DisplaySettings(SettingsLoader.GetCurrentData());


            view.city = "testingen";
            view.time = "yeeettime";

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
        }
    }
}
