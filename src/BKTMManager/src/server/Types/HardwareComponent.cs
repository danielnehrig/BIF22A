using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BKTMManager.Types {
  public class HardwareComponent : IGlobalType {
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

    private bool _isExchanged = false;
    public bool isExchanged {
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

    public HardwareComponent(string name, float price) {
      this._name = name;
      this._price = price;
    }

    public HardwareComponent(SqlDataReader reader) {
      this._id = reader.GetInt32(0);
      this._categoryId = reader.GetInt32(1);
      // this._isExchanged = reader.GetBoolean(2);
      this._name = reader.GetString(3);
      this._price = reader.GetDouble(4);
      this._description = reader.GetString(5);
    }

    public HardwareComponent(int id, string name, float price, bool isExchanged, string description) {
      this._id = id;
      this._name = name;
      this._description = description;
      this._isExchanged = isExchanged;
      this._price = price;
    }

    public HardwareComponent() {
    }

    public string WhatAmI() {
      return String.Format("ID: {0} ; NAME: {1} ; DESC: {2} ; isEx: {3} ; PRICE: {4}", _id, _name, _description, _isExchanged, _price);
    }
  }
}
