using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Room : TypeRepo {
    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _roomNr;
    public string roomNr {
      set { _roomNr = value; }
      get { return _roomNr; }
    }

    private string _description;
    public string description {
      set { _description = value; }
      get { return _description; }
    }

    public Room() {
    }

    public Room(SqlDataReader reader) {
      this._id = reader.GetInt32(reader.GetOrdinal("id"));
      this._roomNr = reader.GetString(reader.GetOrdinal("roomNr"));
      this._description = reader.GetString(reader.GetOrdinal("description"));
      tableNormal = String.Format("ID: {0} ; NR: {1} ; DESC: {2} ", _id, _roomNr, _description);
    }
  }
}
