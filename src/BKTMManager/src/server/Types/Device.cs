using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BKTMManager.Types {
  public class Device {
    private int _id;
    public int id {
      set { _id = value; }
      get { return _id; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    private DateTime _dateBuy;
    public DateTime dateBuy {
      set { _dateBuy = value; }
      get { return _dateBuy; }
    }

    private int _categoryId;
    public int categoryId {
      set { _categoryId = value; }
      get { return _categoryId; }
    }

    private int _inventoryId;
    public int inventoryId {
      set { _inventoryId = value; }
      get { return _inventoryId; }
    }

    private int _resellerId;
    public int resellerId {
      set { _resellerId = value; }
      get { return _resellerId; }
    }

    private double _price;
    public double price {
      set { _price = value; }
      get { return _price; }
    }

    public Device() {
    }

    public Device(SqlDataReader reader) {
      this._id = reader.GetInt32(0);
      this._dateBuy = reader.GetDateTime(1);
      this._categoryId = reader.GetInt32(2);
      this._inventoryId = reader.GetInt32(3);
      this._resellerId = reader.GetInt32(4);
      this._price = reader.GetDouble(5);
    }

    public Device(int id, string name) {
      this._id = id;
      this._name = name;
    }
  }
}
