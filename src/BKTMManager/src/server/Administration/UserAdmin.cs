using System;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class UserAdministration : RepoAdmin<User> {
    public UserAdministration(string ip, string db, string user, string pw):base(ip, db, user, pw) { }
  }
}
