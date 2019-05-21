using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Program {
  public class Administration {
    private SqlConnection _cnn;

    public Administration() { 
      bootstrap();
    }

    private void bootstrap() {
      try {
        string connString = String.Format("Data Source=127.0.0.1;Initial Catalog=Coffe;User ID=SA;Password=Hallo1234!");
        _cnn = new SqlConnection(connString);
      } catch (Exception ex) {
        Console.WriteLine("Sql Error", ex);
      }
    }

    public User Login(string username, string password) {
      try {
        _cnn.Open();
        User foundUser = null;
        string sqlQuery = String.Format("SELECT * FROM Users;");
        SqlCommand command = _cnn.CreateCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@firstName", username));
        SqlDataReader reader = command.ExecuteReader();

        foreach (User item in reader) {
          if (item.password == password && item.username == username) {
            foundUser = new User(reader);
          }
        }
        _cnn.Close();
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
