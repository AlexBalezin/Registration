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
using System.Windows.Shapes;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Registration
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        ApplicationContext db;
        public AuthenticationWindow()
        {
            InitializeComponent();
        }

        private bool Check(string login, string password)
        {
            User currentUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                currentUser = db.Users.Where(x => x.Login == login && x.Pass == password).FirstOrDefault();
                if (currentUser != null)
                    return true;
                else
                    return false;
            }

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e) 
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text.Trim();
            string password = passwordField.Password.Trim();

            if (Check(login, password))
            {
                passwordField.ToolTip = "";
                passwordField.Background = Brushes.Transparent;
                loginField.ToolTip = "";
                loginField.Background = Brushes.Transparent;
                var notification = new ToastContentBuilder();
                notification.AddText("Вход выполнен");
                notification.Show();
            }
            else
            {
                var notification = new ToastContentBuilder();
                notification.AddText("Неверный логин или пароль");
                notification.Show();
            }

        }
    }
}
