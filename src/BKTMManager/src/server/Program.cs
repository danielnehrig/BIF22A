using System;
using System.Collections.Generic;
using Gtk;
using BKTMManager.Helper;
using BKTMManager.Types;
using BKTMManager.Administration;

namespace BKTMManager {
  class MainClass {
    public static void Main(string[] args) {
      try {
        Application.Init();
        MainWindow win = new MainWindow();
        win.Resize(200, 200);
        Label myLabel = new Label();
        myLabel.Text = "Hello World!!!";
        win.Add(myLabel);
        win.ShowAll();
        Application.Run();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }
  }
}
