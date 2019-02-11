using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Reseller : TypeRepo {
    public Reseller() { }

    public Reseller(SqlDataReader reader) {
      _id = reader.GetInt32(reader.GetOrdinal("id"));
      _location = reader.GetString(reader.GetOrdinal("location"));
      _name = reader.GetString(reader.GetOrdinal("name"));
      tableNormal = String.Format("ID: {0} ; LOC: {1} ; NAME: {2}", _id, _location, _name);
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
  }
}
