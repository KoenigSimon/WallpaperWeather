using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WallpaperWeather
{
    static class ImageCacheLoader
    {
        private static string basePath = "../../ImageCache/";

        public static void LoadImagesFromCache(ScrollViewer rootElement)
        {
            string[] filePaths = Directory.GetFiles(basePath, "*.jpg");
            GenerateList(filePaths, rootElement);
        }

        private static void GenerateList(string[] filePaths, ScrollViewer rootElement)
        {
            WrapPanel cachePanel = new WrapPanel();

            cachePanel.SizeChanged += (s, args) => HandleResizing(cachePanel);

            for (int i = 0; i < filePaths.Length; i++)
            {
                Image img = new Image();
                img.Width = 250;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(filePaths[i], UriKind.Relative);
                image.EndInit();
                img.Source = image;

                
                img.MouseDown += (s, args) => MouseDown(img);
                img.MouseEnter += (s, args) => MouseEnter(img);
                img.MouseLeave += (s, args) => MouseLeave(img);

                cachePanel.Children.Add(img);
            }

            rootElement.Content = cachePanel;
        }


        private static void HandleResizing(WrapPanel target)
        {
            List<Image> childList = target.Children.Cast<Image>().ToList();

            double rootWidth = target.ActualWidth;
            int elementCountPerRow = (int)(rootWidth / 250);
            if (rootWidth <= 250) elementCountPerRow = 1;
            double elementWidth = rootWidth / elementCountPerRow;

            foreach(Image elem in childList)
            {
                elem.Width = elementWidth;
            }
        }

        private static void MouseDown(Image sender)
        {

        }

        private static void MouseEnter(Image sender)
        {
            sender.Opacity = 0.5;
        }

        private static void MouseLeave(Image sender)
        {
            sender.Opacity = 1;
        }
    }
}
