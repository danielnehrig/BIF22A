using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Teacher : TypeRepo {
    public Teacher() { }

    public Teacher(SqlDataReader reader) {
      _id = reader.GetInt32(reader.GetOrdinal("id"));
      _firstName = reader.GetString(reader.GetOrdinal("firstName"));
      _lastName = reader.GetString(reader.GetOrdinal("lastName"));
      _roomId = reader.GetInt32(reader.GetOrdinal("roomId"));
      _roomOwner = reader.GetInt32(reader.GetOrdinal("roomOwner"));
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _firstName;
    public string firstName {
      get { return _firstName; }
      set { _firstName = value; }
    }

    private string _lastName;
    public string lastName {
      get { return _lastName; }
      set { _lastName = value; }
    }

    private int _roomId;
    public int roomId {
      get { return _roomId; }
      set { _roomId = value; }
    }

    private int _roomOwner;
    public int roomOwner {
      get { return _roomOwner; }
      set { _roomOwner = value; }
    }
  }
}
