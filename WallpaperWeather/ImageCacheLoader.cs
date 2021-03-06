﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WallpaperWeather
{
    static class ImageCacheLoader
    {
        static string[] filePaths;

        public  static WrapPanel LoadImages()
        {
            string cachePath = PathHandling.GetCachePath();
            List<string> fileList = new List<string>();
            fileList.AddRange(Directory.GetFiles(cachePath, "*.jpg"));
            fileList.AddRange(Directory.GetFiles(cachePath, "*.png"));
            fileList.AddRange(Directory.GetFiles(cachePath, "*.bmp"));
            filePaths = fileList.ToArray();

            WrapPanel cachePanel = new WrapPanel();

            

            if(filePaths.Length == 0)
            {
                Label noCacheLabel = new Label();
                noCacheLabel.Content = "No cached files";
                cachePanel.Children.Add(noCacheLabel);
            }
            else
            {
                cachePanel.SizeChanged += (s, args) => HandleResizing(cachePanel);
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

        public static void UnloadImage(string file, WrapPanel imageList)
        {
            UIElementCollection images = imageList.Children;
            UIElement target = new UIElement();
            foreach(UIElement i in images)
            {
                Image temp = (Image)i;
                BitmapImage tmpBmp = (BitmapImage)temp.Source;
                Uri filePath = new Uri(file);
                if (tmpBmp.UriSource.OriginalString == file)
                {
                    target = i;
                    temp.Source = null;
                    break;
                }                    
            }
            
            images.Remove(target);
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
            MainWindow.active.ImageClicked(sender);
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
