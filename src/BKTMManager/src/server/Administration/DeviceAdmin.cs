using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class DeviceAdministration : RepoAdmin<Device> {
    public DeviceAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Device";
    }
  }
}
