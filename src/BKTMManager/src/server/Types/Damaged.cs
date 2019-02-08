using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Damaged : IGlobalType {
    public Damaged() { }
    public Damaged(SqlDataReader reader) {
      this._id = reader.GetInt32(0);
      this._date = reader.GetDateTime(1);
      this._description = reader.GetString(2);
      this._deviceId = reader.GetInt32(3);
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private Device _device;
    public Device device {
      get { return _device; }
      set { _device = value; }
    }

    private DateTime _date;
    public DateTime date {
      get { return _date; }
      set { _date = value; }
    }
    private string _description;
    public string description {
      get { return _description; }
      set { _description = value; }
    }

    private int _deviceId;
    public int deviceId {
      get { return _deviceId; }
      set { _deviceId = value; }
    }

    public string WhatAmI() {
      return String.Format("ID: {0} ; DATE: {1} ; DESC: {2}", _id, _date, _description);
    }
  }
}
