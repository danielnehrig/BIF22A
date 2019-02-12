using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BKTMManager.Types {
  public class Device : TypeRepo {
    private int _id;
    public int id {
      set { _id = value; }
      get { return _id; }
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

    private Category _category;
    public Category category {
      set { _category = value; }
      get { return _category; }
    }

    private Reseller _reseller;
    public Reseller reseller {
      set { _reseller = value; }
      get { return _reseller; }
    }

    private int _inventoryNr;
    public int inventoryNr {
      set { _inventoryNr = value; }
      get { return _inventoryNr; }
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
      this._id = reader.GetInt32(reader.GetOrdinal("de_id"));
      this._dateBuy = reader.GetDateTime(reader.GetOrdinal("dateBuy"));
      this._categoryId = reader.GetInt32(reader.GetOrdinal("categoryId"));
      this._inventoryNr = reader.GetInt32(reader.GetOrdinal("inventoryNr"));
      this._resellerId = reader.GetInt32(reader.GetOrdinal("resellerId"));
      this._price = reader.GetDouble(reader.GetOrdinal("price"));
      tableNormal = String.Format("ID: {0} ; BUYDATE: {1} ; CATID: {2} ; INVID: {3} ; RESID: {4} ; PRICE: {5} ", _id, _dateBuy, _categoryId, _inventoryNr, _resellerId, _price);
    }

    public Device(SqlDataReader reader, Category category, Reseller reseller) {
      this._id = reader.GetInt32(reader.GetOrdinal("de_id"));
      this._dateBuy = reader.GetDateTime(reader.GetOrdinal("dateBuy"));
      this._categoryId = reader.GetInt32(reader.GetOrdinal("categoryId"));
      this._inventoryNr = reader.GetInt32(reader.GetOrdinal("inventoryNr"));
      this._resellerId = reader.GetInt32(reader.GetOrdinal("resellerId"));
      this._price = reader.GetDouble(reader.GetOrdinal("price"));
      this._reseller = reseller;
      this._category = category;
    }
  }
}
