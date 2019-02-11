using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class DamagedAdministration : RepoAdmin<Damaged> {
    public DamagedAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Damaged";
      prefix = "da_";
      toPopulate = new string[] { "Device", "Category", "DeviceReseller" };
      columNames = this.getColumnsName();
    }

    public List<Damaged> GetAllPopulated() {
      List<Damaged> damaged = new List<Damaged>();
      try {
        this.cnn.Open();
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = String.Format(@"SELECT da.id AS {0}id, de.id AS de_id, ca.id AS ca_id, re.id AS re_id, *
                                              FROM [dbo].[{1}] AS da
                                              INNER JOIN [dbo].[Device] AS de ON da.deviceId = de.id
                                              INNER JOIN [dbo].[Category] AS ca ON de.categoryId = ca.id
                                              INNER JOIN [dbo].[DeviceReseller] AS re ON de.resellerId = re.id", this.prefix, this.tableName);
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
        this.cnn.Close();
        return null;
      }
      return damaged;
    }
  }
}
