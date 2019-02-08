using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Category : IGlobalType {
    public Category() {}

    public Category(SqlDataReader reader) {
      _id = reader.GetInt32(0);
      _name = reader.GetString(1);
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _name;
    public string name {
      get { return _name; }
      set { _name = value; }
    }

    public string WhatAmI() {
      return String.Format("ID: {0} ; NAME: {1}", _id, _name);
    }
  }
}
