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
        BKTMApp win = new BKTMApp();
        win.ShowAll();
        Application.Run();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }
  }
}
