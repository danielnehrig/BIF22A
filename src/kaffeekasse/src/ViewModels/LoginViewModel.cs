using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using System;
using ReactiveUI;
using Coffee.Models;
using Coffee.Types;
using Coffee;

namespace Coffee.ViewModels {
  public class LoginViewModel : ViewModelBase {
    Administration Admin;

    private string title = "Login";
    public string Title {
      get => title;
      set => this.RaiseAndSetIfChanged(ref title, value);
    }

    private string username;
    public string Username {
      get => username;
      set => this.RaiseAndSetIfChanged(ref username, value);
    }

    private string password;
    public string Password {
      get => password;
      set => this.RaiseAndSetIfChanged(ref password, value);
    }

    public ReactiveCommand<Unit, User> Login { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }

    public LoginViewModel(Administration admin) {
      Admin = admin;

      var loginEnabled = this.WhenAnyValue(
          x => x.Username,
          x => !string.IsNullOrWhiteSpace(x));

        Login = ReactiveCommand.Create(() => {
          User user = admin.Login(this.Username, this.Password);
          Console.WriteLine(String.Format("{0} {1}", user.username, user.accAmount, user.isActive));
          return user;
      }, loginEnabled);

      Cancel = ReactiveCommand.Create(() => {  });
    }
  }
}
