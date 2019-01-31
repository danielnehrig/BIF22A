using System;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class RoomAdministration : RepoAdmin<Room> {
    public RoomAdministration(string ip, string db, string user, string pw):base(ip, db, user,pw) { }
  }
}
