using System;
using BKTMManager.Administration;
using Gtk;

namespace BKTMManager {
  public partial class Login : Gtk.Dialog {
    UserAdministration user;
    public Login(UserAdministration user) {
      this.user = user;
      this.Build();
    }

    public Login() {
      this.Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
      Application.Quit();
      a.RetVal = true;
    }
  }
}
