using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class DamagedAdministration : RepoAdmin<Damaged> {
    public DamagedAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Damaged";
      columNames = this.getColumnsName();
    }
  }
}
