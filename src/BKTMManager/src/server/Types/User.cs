using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class User : IGlobalType {
    public User() { }

    public User(SqlDataReader reader) {
      this._id = reader.GetInt32(0);
      this._username = reader.GetString(1);
      this._password = reader.GetString(2);
      this._email = reader.GetString(3);
      this._isAdmin = reader.GetByte(4);
      this._teacherId = reader.GetInt32(5);
    }

    private Teacher _teacher;
    public Teacher teacher {
      get { return _teacher; }
      set { _teacher = value; }
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _username;
    public string username {
      get { return _username; }
      set { _username = value; }
    }

    private string _email;
    public string email {
      get { return _email; }
      set { _email = value; }
    }

    private string _password;
    public string password {
      get { return _password; }
      set { _password = value; }
    }

    private byte _isAdmin = 0;
    public byte isAdmin {
      get { return _isAdmin; }
      set { _isAdmin = value; }
    }

    private int _teacherId;
    public int teacherId {
      get { return _teacherId; }
      set { _teacherId = value; }
    }

    public string WhatAmI() {
      return String.Format("ID: {0} ; NAME: {1} ; EMAIL: {2} ; ISADMIN: {3}", _id, _username, _email, _isAdmin);
    }
  }
}
