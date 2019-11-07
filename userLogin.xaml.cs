using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Addev_Profom_Estimator
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
            userNameTick.Visibility = Visibility.Collapsed;
            passwordTick.Visibility = Visibility.Collapsed;

        }
        public static class GlobalUserName
        {
            public static string myName = "";
        }

        private void UserTextbox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            userNameTick.Visibility = Visibility.Collapsed;
            UserTextbox.BorderBrush = Brushes.DarkGray;

            string[] lineOfContents = File.ReadAllLines("data/user_login_data.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');

                if (UserTextbox.Text == tokens[2])

                {
                    userNameTick.Source = new BitmapImage(new Uri("Ressources/icons8-ok-96.png", UriKind.Relative));
                    userNameTick.Visibility = Visibility.Visible;
                    UserTextbox.BorderBrush = Brushes.LightGreen;

                }
            }
        }

        private void PasswordTextbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordTick.Visibility = Visibility.Collapsed;
            PasswordTextbox.BorderBrush = Brushes.DarkGray;

            string[] lineOfContents = File.ReadAllLines("data/user_login_data.txt");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(';');

                if (UserTextbox.Text == tokens[2] && PasswordTextbox.Password == tokens[3])

                {
                    passwordTick.Visibility = Visibility.Visible;
                    PasswordTextbox.BorderBrush = Brushes.LightGreen;
                    passwordTick.Source = new BitmapImage(new Uri("Ressources/icons8-ok-96.png", UriKind.Relative));
                    userNameTick.Source = new BitmapImage(new Uri("Ressources/icons8-ok-96.png", UriKind.Relative));
                    userNameTick.Visibility = Visibility.Visible;
                    UserTextbox.BorderBrush = Brushes.LightGreen;
                }
            }
        }
        private void UserLoginCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UserLoginOk_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {

                if (UserTextbox.Text != "" && PasswordTextbox.Password != null)
                {
                    string[] lineOfContents = File.ReadAllLines("data/user_login_data.txt");
                    foreach (var line in lineOfContents)
                    {
                        string[] tokens = line.Split(';');

                        if (UserTextbox.Text == tokens[2] && PasswordTextbox.Password == tokens[3])

                        {

                            GlobalUserName.myName = tokens[0] + " " + tokens[1];

                            MainWindow loadingHome = new MainWindow();

                            loadingHome.Show();

                            this.Close();


                        }

                    }
                }
            }


            finally
            {
                Mouse.OverrideCursor = null;
            }
        }



        public void AttributeRedColour()
        {
            userNameTick.Source = new BitmapImage(new Uri("Ressources/icons8-wrong-96.png", UriKind.Relative));
            passwordTick.Source = new BitmapImage(new Uri("Ressources/icons8-wrong-96.png", UriKind.Relative));
            passwordTick.Visibility = Visibility.Visible;
            PasswordTextbox.BorderBrush = Brushes.Red;
            userNameTick.Visibility = Visibility.Visible;
            UserTextbox.BorderBrush = Brushes.Red;
            UserTextbox.Foreground = new SolidColorBrush(Colors.Red);
            PasswordTextbox.Foreground = new SolidColorBrush(Colors.Red);
        }


    }

}

