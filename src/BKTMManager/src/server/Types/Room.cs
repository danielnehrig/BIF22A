using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public interface IRoom {
    int id { get; set; }
    string name { get; set; }
  }

  public class Room : IGlobalType, IRoom {
    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    private string _description;
    public string description {
      set { _description = value; }
      get { return _description; }
    }

    public Room() {
    }

    public Room(SqlDataReader reader) {
      this._id = reader.GetInt32(0);
      this._name = reader.GetString(1);
      this._description = reader.GetString(2);
    }

    public Room(int id) {
      _id = id;
    }

    public Room(int id, string name) {
      this._id = id;
      this._name = name;
    }

    public string WhatAmI() {
      return String.Format("ID: {0} ; NAME: {1} ; DESC: {2} ", _id, _name, _description);
    }
  }
}
