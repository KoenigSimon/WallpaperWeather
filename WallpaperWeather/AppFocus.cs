﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallpaperWeather
{
    class AppFocus
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRect(IntPtr hwnd, out RECT rc);

        private static IntPtr desktopHandle; //Window handle for the desktop
        private static IntPtr shellHandle; //Window handle for the shell
                                    //Get the handles for the desktop and shell now.

        public static bool OtherAppIsInFullScreen()
        {            
            desktopHandle = GetDesktopWindow();
            shellHandle = GetShellWindow();

            //Detect if the current app is running in full screen
            bool runningFullScreen = false;
            RECT appBounds;
            Rectangle screenBounds;
            IntPtr hWnd;

            //get the dimensions of the active window
            hWnd = GetForegroundWindow();
            if (hWnd != null && !hWnd.Equals(IntPtr.Zero))
            {
                //Check we haven't picked up the desktop or the shell
                if (!(hWnd.Equals(desktopHandle) || hWnd.Equals(shellHandle)))
                {
                    GetWindowRect(hWnd, out appBounds);
                    //determine if window is fullscreen
                    screenBounds = Screen.FromHandle(hWnd).Bounds;
                    if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width)
                    {
                        runningFullScreen = true;
                    }
                }
            }

            return runningFullScreen;
        }
    }

}