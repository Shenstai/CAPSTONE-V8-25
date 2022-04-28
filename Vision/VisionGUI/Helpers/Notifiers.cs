using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Vision.Core;
using VisionGUI.Views;
using VisionGUI.Models;
using VisionGUI.ViewModels;

namespace VisionGUI.Helpers
{
    public static  class Notifiers
    {
        public static System.Windows.Forms.NotifyIcon icon;
        private static System.Windows.Forms.ContextMenuStrip context;
        private static int notificationTimeOutSeconds = 10;

        private static TimeSpan notifyLimit = TimeSpan.FromMinutes(15);

#if DEBUG  
        private static int checkInterval = 10;

#else 
           private static int checkInterval = 59;


#endif

        private static EventHandler defaultNotificationHandler;

        static Notifiers()
        {
            icon = new System.Windows.Forms.NotifyIcon();
            icon.Icon = Properties.Resources.appLogo;

            context = new System.Windows.Forms.ContextMenuStrip();
            icon.ContextMenuStrip = context;

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

            context.Items.Add("Open", null, (s, e) =>
            {
                mainWindow.RestoreWindow();


            });

            context.Items.Add("Settings", null, (s, e) =>
           {

               mainWindow.GoToSettings();

           });


            context.Items.Add("Exit", null, (s, e) =>
                {
                    mainWindow.ForceClose();
                }
                );

            icon.Visible = true;
        }

        public static void ShowNotification(string title, string message, EventHandler clickHandler = null, System.Windows.Forms.ToolTipIcon toolTipIcon = System.Windows.Forms.ToolTipIcon.None)
        {
            icon.BalloonTipTitle = title;
            icon.BalloonTipText = message;
            icon.BalloonTipIcon = toolTipIcon;

            icon.BalloonTipClicked += clickHandler ?? defaultNotificationHandler;

            icon.ShowBalloonTip(notificationTimeOutSeconds * 1000);
        }

        public static void SetDefaultNotificationHandler(EventHandler baloonTipHandlerClick)
        {
            defaultNotificationHandler = baloonTipHandlerClick;
            icon.BalloonTipClicked += baloonTipHandlerClick;
        }


    }
}
