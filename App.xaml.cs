using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Addev_Profom_Estimator
{
  public class App : Application
  {
    private bool _contentLoaded;

    private void StartupHandler(object sender, StartupEventArgs e)
    {
    }

    protected virtual void OnStartup(StartupEventArgs e)
    {
      Mouse.set_OverrideCursor(Cursors.get_Wait());
      try
      {
        Application.get_Current().add_DispatcherUnhandledException(new DispatcherUnhandledExceptionEventHandler(this.Current_DispatcherUnhandledException));
        this.add_DispatcherUnhandledException(new DispatcherUnhandledExceptionEventHandler(this.App_DispatcherUnhandledException));
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(this.CurrentDomain_UnhandledException);
        base.OnStartup(e);
        SplashScreenWindow splashScreen = new SplashScreenWindow();
        SplashScreenWindow splashScreenWindow = splashScreen;
        splashScreen.Show();
        Task.Factory.StartNew((Action) (() =>
        {
          Thread.Sleep(4000);
          ((DispatcherObject) this).Dispatcher.Invoke((Action) (() =>
          {
            new UserLogin().Show();
            splashScreen.Close();
          }));
        }));
      }
      finally
      {
        Mouse.set_OverrideCursor((Cursor) null);
      }
    }
