using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class DamagedAdministration : RepoAdmin<Damaged> {
    public DamagedAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Damaged";
      columNames = this.getColumnsName();
    }

    public List<Damaged> GetAllDamagedDevices() {
      List<Damaged> damaged = new List<Damaged>();
      try {
        this.cnn.Open();
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = String.Format(@"SELECT *
                                              FROM [dbo].[{0}] AS da
                                              INNER JOIN [dbo].[Device] AS de ON da.deviceId = de.id
                                              INNER JOIN [dbo].[Category] AS ca ON de.CategoryId = ca.id
                                              INNER JOIN [dbo].[DeviceReseller] AS re ON de.resellerId = re.id", this.tableName);
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          Reseller reseller = new Reseller(reader);
          Category category = new Category(reader);
          Device device = new Device(reader, category, reseller);
          Damaged damage = new Damaged(reader, device);
          damaged.Add(damage);
        }
        this.cnn.Close();
      } catch(Exception err) {
        Console.WriteLine(err);
        return null;
      }
      return damaged;
    }
  }
}
