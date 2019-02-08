using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class RoomAdministration : RepoAdmin<Room> {
    public RoomAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Room";
      columNames = this.getColumnsName();
    }
  }
}
