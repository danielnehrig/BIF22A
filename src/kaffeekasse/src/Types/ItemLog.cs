using System;
using System.Data.SqlClient;

namespace Program {
  public class ItemLog {
    public ItemLog(SqlDataReader reader) {
      _user = reader.GetDouble(0);
      _item = reader.GetString(1);
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
