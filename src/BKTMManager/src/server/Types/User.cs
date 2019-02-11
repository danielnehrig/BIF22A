using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class User : TypeRepo {
    public User() { }

    public User(SqlDataReader reader) {
      this._id = reader.GetInt32(reader.GetOrdinal("id"));
      this._username = reader.GetString(reader.GetOrdinal("username"));
      this._password = reader.GetString(reader.GetOrdinal("password"));
      this._email = reader.GetString(reader.GetOrdinal("email"));
      this._admin = reader.GetByte(reader.GetOrdinal("admin"));
      this._teacherId = reader.GetInt32(reader.GetOrdinal("teacherId"));
      tableNormal = String.Format("ID: {0} ; NAME: {1} ; EMAIL: {2} ; ISADMIN: {3}", _id, _username, _email, _admin);
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

    private byte _admin = 0;
    public byte admin {
      get { return _admin; }
      set { _admin = value; }
    }

    private int _teacherId;
    public int teacherId {
      get { return _teacherId; }
      set { _teacherId = value; }
    }
  }
}
