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
        static string[] filePaths;

        public  static WrapPanel LoadImages()
        {
            string cachePath = PathHandling.GetCachePath();
            filePaths = Directory.GetFiles(cachePath, "*.jpg");

            WrapPanel cachePanel = new WrapPanel();

            cachePanel.SizeChanged += (s, args) => HandleResizing(cachePanel);

            if(filePaths.Length == 0)
            {
                Label noCacheLabel = new Label();
                noCacheLabel.Content = "No cached files";
                cachePanel.Children.Add(noCacheLabel);
            }
            else
            {
                for (int i = 0; i < filePaths.Length; i++)
                {
                    Image img = new Image();
                    img.Width = 300;
                    img.SnapsToDevicePixels = true;
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
            }            

            return cachePanel;
        }


        private static void HandleResizing(WrapPanel target)
        {
            List<Image> childList = target.Children.Cast<Image>().ToList();

            double rootWidth = target.ActualWidth;
            int elementCountPerRow = (int)(rootWidth / 300);
            if (rootWidth <= 300) elementCountPerRow = 1;
            double elementWidth = rootWidth / elementCountPerRow;

            foreach(Image elem in childList)
            {
                elem.Width = elementWidth;
            }
        }

        private static void MouseDown(Image sender)
        {
            //select image for more options
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
