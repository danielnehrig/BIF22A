using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public interface IUserAdmin {
    User Login(string username, string password);
  }

  public class UserAdministration : RepoAdmin<User>, IUserAdmin {
    public UserAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "User";
      prefix = "us_";
      columNames = this.getColumnsName();
    }

    public User Login(string username, string password) {
      try {
        this.cnn.Open();
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = String.Format("SELECT id AS {2}id, * FROM [dbo].[{0}] WHERE username = '{1}'", this.tableName, username, this.prefix);
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        if(reader.GetString(2) == password) {
          Console.WriteLine("Login Successfull");
          User user = new User(reader);
          this.cnn.Close();
          return user;
        } else {
          Console.WriteLine("Login Failed");
          this.cnn.Close();
          return null;
        }
      } catch(Exception err) {
        Console.WriteLine(err);
      }
      return null;
    }
  }
}
