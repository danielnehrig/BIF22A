using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BKTMManager.Types {
  public class HardwareComponent : TypeRepo {
    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private int _categoryId;
    public int categoryId {
      get { return _categoryId; }
      set { _categoryId = value; }
    }

    private byte _isExchanged = 0;
    public byte isExchanged {
      get { return _isExchanged; }
      set { _isExchanged = value; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    private double _price;
    public double price {
      set { _price = value; }
      get { return _price; }
    }

    private string _description;
    public string description {
      set { _description = value; }
      get { return _description; }
    }

    public HardwareComponent(SqlDataReader reader) {
      this._id = reader.GetInt32(reader.GetOrdinal("ha_id"));
      this._categoryId = reader.GetInt32(reader.GetOrdinal("categoryId"));
      this._isExchanged = reader.GetByte(reader.GetOrdinal("isExchanged"));
      this._name = reader.GetString(reader.GetOrdinal("haName"));
      this._price = reader.GetDouble(reader.GetOrdinal("haPrice"));
      this._description = reader.GetString(reader.GetOrdinal("description"));
      tableNormal = String.Format("ID: {0} ; NAME: {1} ; DESC: {2} ; isEx: {3} ; PRICE: {4}", _id, _name, _description, _isExchanged, _price);
    }

    public HardwareComponent() {
    }
  }
}
