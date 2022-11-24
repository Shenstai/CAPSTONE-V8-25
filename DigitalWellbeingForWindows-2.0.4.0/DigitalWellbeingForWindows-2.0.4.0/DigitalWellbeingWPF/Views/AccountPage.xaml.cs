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
using DigitalWellbeingWPF;
using DigitalWellbeingWPF.Views;

namespace DigitalWellbeingWPF.Views
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ParentalControlPage parentalControlPage = new ParentalControlPage();
            MainWindow mainWindow = new MainWindow();
            bool log = false;
            if (this.username.Text == "admin" && this.password.Password == "admin")
            {
                log = true;

                while (log)
                {
                    mainWindow.ContentFrame.Content = parentalControlPage;
                }
            }
        }
    }
}
