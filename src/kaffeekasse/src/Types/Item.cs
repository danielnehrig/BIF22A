using System;
using System.Data.SqlClient;

namespace Coffee.Types {
  public class Item {
    public Item(SqlDataReader reader) {
      _price = reader.GetDouble(0);
      _name = reader.GetString(1);
      _description = reader.GetString(2);
    }

    private double _price;
    public double price {
      set => _price = value;
      get => _price;
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
