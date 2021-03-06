using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Logging.Serilog;
using Coffee.Helper;
using Coffee.Views;
using Coffee.Services;
using Coffee.ViewModels;

namespace Coffee {
  public class MainProgram {
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
      => AppBuilder.Configure<App>()
      .UsePlatformDetect()
      .LogToDebug()
      .UseReactiveUI();

    // Your application's entry point. Here you can initialize your MVVM framework, DI
    // container, etc.
    private static void AppMain(Application app, string[] args) {
      var db = new Database();
      Config config = new Config("config.cfg");
      Dictionary<string, string> cnnInfo = config.cnnInfo;

      Administration admin = new Administration(cnnInfo["ip"], cnnInfo["port"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);
      var window = new MainWindow {
        DataContext = new MainWindowViewModel(admin, db),
      };

      app.Run(window);
    }
  }
}
