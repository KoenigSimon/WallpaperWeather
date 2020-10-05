using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperWeather
{
    static class TrayHandler
    {
        private static System.Windows.Forms.NotifyIcon _notifyIcon;

        public static void MinimizeToTray(MainWindow window, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            window.Hide();

            if (_notifyIcon != null) _notifyIcon.Dispose();
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow(window);
            _notifyIcon.Icon = WallpaperWeather.Properties.Resources.Icon1;     //<--- icon noch ändern
            _notifyIcon.Visible = true;

            CreateContextMenu(window);
        }

        private static void CreateContextMenu(MainWindow window)
        {
            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Open UI").Click += (s, e2) => ShowMainWindow(window);
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e2) => ExitApplication(window);
        }

        private static void ShowMainWindow(MainWindow window)
        {
            if (window.IsVisible)
            {
                if (window.WindowState == System.Windows.WindowState.Minimized)
                {
                    window.WindowState = System.Windows.WindowState.Normal;
                }
                window.Activate();
            }
            else
            {
                window.Show();
            }
        }

        private static void ExitApplication(MainWindow window)
        {
            window.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
            Environment.Exit(1);
        }
    }
}
