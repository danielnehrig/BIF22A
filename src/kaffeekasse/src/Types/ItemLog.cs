using System;
using System.Data.SqlClient;

namespace Coffee.Types {
  public class ItemLog {
    public ItemLog(Item item, User user) {
      _user = user;
      _item = item;
    }

    private Item _item;
    public Item item {
      set => _item = value;
      get => _item;
    }

    private User _user;
    public User user {
      set => _user = value;
      get => _user;
    }
  }
}
