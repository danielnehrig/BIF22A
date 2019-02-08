using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Damaged {
    public Damaged(SqlDataReader reader) {
      this._id = reader.GetInt32(0);
      this._date = reader.GetDateTime(1);
      this._description = reader.GetString(2);
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
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
  }
}
