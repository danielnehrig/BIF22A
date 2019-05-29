using System.Collections.Generic;
using System.Collections.ObjectModel;
using Coffee.Models;
using Coffee;

namespace Coffee.ViewModels {
  public class CoffeeLogViewModel : ViewModelBase {
    private Administration Admin;

    private string title = "Coffee Log";
    public string Title {
      get => title;
    }

    public CoffeeLogViewModel(Administration admin) {
      Admin = admin;
    }
  }
}
