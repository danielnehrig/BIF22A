using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Reseller : IGlobalType {
    public Reseller() { }

    public Reseller(SqlDataReader reader) {
      _id = reader.GetInt32(0);
      _location = reader.GetString(1);
      _name = reader.GetString(2);
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _location;
    public string location {
      get { return _location; }
      set { _location = value; }
    }

    private string _name;
    public string name {
      get { return _name; }
      set { _name = value; }
    }

    public string WhatAmI() {
      return String.Format("ID: {0} ; LOC: {1} ; NAME: {2}", _id, _location, _name);
    }
  }
}
