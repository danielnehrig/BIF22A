using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class HardwareAdministration : RepoAdmin<HardwareComponent> {
    public HardwareAdministration(SqlConnection cnn):base(cnn) {
      tableName = "Hardware";
      columNames = this.getColumnsName();
    }
  }
}
