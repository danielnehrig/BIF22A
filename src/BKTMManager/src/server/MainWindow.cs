using System;
using System.Collections.Generic;
using Gtk;
using BKTMManager.Administration;
using BKTMManager.Helper;

public partial class MainWindow : Gtk.Window {
  public MainWindow() : base(Gtk.WindowType.Toplevel) {
    Build();
  }

  protected void Test() {
    // Read the Config which holds Database connection information
    Config config = new Config("config.cfg");
    Dictionary<string, string> cnnInfo = config.cnnInfo;

    // Load Administration manager v2 with repo design pattern
    Manager manager = new Manager(cnnInfo);
  }

  protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
    Application.Quit();
    a.RetVal = true;
  }
}
