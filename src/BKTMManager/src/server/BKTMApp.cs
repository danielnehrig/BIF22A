using System;
using System.Collections.Generic;
using Gtk;
using BKTMManager.Administration;
using BKTMManager.Helper;

namespace BKTMManager {
  public partial class BKTMApp : Gtk.Window {
    protected Manager manager;
    protected Login login;
    public BKTMApp() : base(Gtk.WindowType.Toplevel) {
      this.Startup();
      Build();
    }

    protected void Startup() {
      Config config = new Config("config.cfg");
      Dictionary<string, string> cnnInfo = config.cnnInfo;

      this.manager = new Manager(cnnInfo);

      this.login = new Login(manager.user);
      this.login.ShowAll();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
      Application.Quit();
      a.RetVal = true;
    }
  }
}
