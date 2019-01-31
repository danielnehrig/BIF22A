using System;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class HardwareAdministration : RepoAdmin<HardwareComponent> {
    public HardwareAdministration(string ip, string db, string user, string pw):base(ip, db, user, pw) { }
  }
}
