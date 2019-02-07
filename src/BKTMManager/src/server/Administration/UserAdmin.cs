using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class UserAdministration : RepoAdmin<User> {
    public UserAdministration(SqlConnection cnn):base(cnn) { }
  }
}
