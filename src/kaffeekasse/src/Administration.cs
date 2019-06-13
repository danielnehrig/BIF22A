using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Coffee.Types;

namespace Coffee {
  public class Administration {
    protected SqlConnection _cnn;
    public SqlConnection cnn {
      get { return _cnn; }
    }
    private string _ip;
    private string _port;
    private string _db;
    private string _user;
    private string _pw;

    public Administration(string ip, string port, string db, string user, string pw) { 
      _ip = ip;
      _port = port;
      _db = db;
      _user = user;
      _pw = pw;
      this.bootstrap();
    }

    private void bootstrap() {
      try {
        string connString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", this._ip, this._db, this._user, this._pw);
        this._cnn = new SqlConnection(connString);
        Console.WriteLine("Connection Established");
      } catch (Exception ex) {
        Console.WriteLine("Sql Error " + ex);
      }
    }

    public User Login(string username, string password) {
      try {
        this.cnn.Open();
        User foundUser = null;
        string sqlQuery = String.Format("GetUser");
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@UserName", username));
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();

        if (reader.GetString(reader.GetOrdinal("password")) == password) {
          foundUser = new User(reader);
        }
        cnn.Close();
        return foundUser;
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error logging in {0}", ex));
        return null;
      }
    }

    public List<ItemLog> GetAllItemsFromUser(User user) {
      try {
        List<Item> items = new List<Item>();
        List<User> users = new List<User>();
        List<ItemLog> itemlog = new List<ItemLog>();
        return itemlog;
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Retriving log from items from Table {0}", ex));
        return null;
      }
    }

    public void SetUserStatus(bool active) {
      try {
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Updateing User Table (isActive)", ex));
      }
    }

    public void UpdateUserAmount(double amount) {
      try {
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Updateing User Table (accAmount)", ex));
      }
    }

    public void Logout(User user) {
      try {
        user = null;
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Updateing User Table (accAmount)", ex));
      }
    }
  }
}
