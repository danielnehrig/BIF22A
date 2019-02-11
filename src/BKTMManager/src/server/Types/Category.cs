using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Category : TypeRepo {
    public Category() {}

    public Category(SqlDataReader reader) {
      _id = reader.GetInt32(reader.GetOrdinal("id"));
      _name = reader.GetString(reader.GetOrdinal("name"));
      tableNormal = String.Format("ID: {0} ; NAME: {1}", _id, _name);
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
  }
}
