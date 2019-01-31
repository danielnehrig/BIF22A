using System;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class DeviceAdministration : RepoAdmin<Device> {
    public DeviceAdministration(string ip, string db, string user, string pw):base(ip, db, user,pw) { }
  }
}
