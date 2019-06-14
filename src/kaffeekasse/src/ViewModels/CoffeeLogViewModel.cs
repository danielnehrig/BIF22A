using System.Collections.Generic;
using System.Collections.ObjectModel;
using Coffee.Models;
using Coffee.Types;
using Coffee;

namespace Coffee.ViewModels {
  public class CoffeeLogViewModel : ViewModelBase {
    private Administration Admin;

    private string title = "Coffee Log";
    public string Title {
      get => title;
    }

    private User user;
    public User User {
      get => user;
    }

    private List<ItemLog> itemLog;
    public List<ItemLog> ItemLog {
      get => itemLog;
    }

    public CoffeeLogViewModel(Administration admin) {
      Admin = admin;
      user = admin.Login("daniel.nehrig", "test123");
      itemLog = admin.GetItemLogFromUser(user);
    }
  }
}
