using System;
using System.Data.SqlClient;

namespace Coffee.Types {
  public class Item {
    public Item(SqlDataReader reader) {
      _amount = reader.GetDouble(reader.GetOrdinal("amount"));
      _name = reader.GetString(reader.GetOrdinal("name"));
      _description = reader.GetString(reader.GetOrdinal("description"));
    }

    private double _amount;
    public double amount {
      set => _amount = value;
      get => _amount;
    }

    private string _name;
    public string name {
      set => _name = value;
      get => _name;
    }

    private string _description;
    public string description {
      set => _description = value;
      get => _description;
    }
  }
}
