using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Addev_Profom_Estimator
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void StartupHandler(object sender, System.Windows.StartupEventArgs e)
        {
            Elysium.Manager.Apply(this, Elysium.Theme.Dark, Elysium.AccentBrushes.Blue, Elysium.AccentBrushes.Lime);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                base.OnStartup(e);

                //initialize the splash screen and set it as the application main window
                var splashScreen = new SplashScreenWindow();
                SplashScreenWindow mainWindow = splashScreen;
                splashScreen.Show();

                //in order to ensure the UI stays responsive, we need to
                //do the work on a different thread
                Task.Factory.StartNew(() =>
                {
                    //simulate some work being done
                    System.Threading.Thread.Sleep(4000);

                    //since we're not on the UI thread
                    //once we're done we need to use the Dispatcher
                    //to create and show the main window
                    this.Dispatcher.Invoke(() =>
                        {
                            //initialize the main window, set it as the application main window
                            //and close the splash screen

                            var loginWindow = new UserLogin();
                            loginWindow.Show();

                            splashScreen.Close();


                        });
                });

            } // perform task

            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
