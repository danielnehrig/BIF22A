using System;
using System.IO;
using System.Data;
using System.Data.SQLite;
using Politik.Type;

namespace Politik.Admin {
  public class Administration {
    SQLiteConnection cnn;

    public Administration() {
      Bootstrap();
    }

    public void Bootstrap() {
      try {
        if(!File.Exists("db.sqlite")) {
          SQLiteConnection.CreateFile("db.sqlite");
          cnn = new SQLiteConnection("Data Source = db.sqlite; Version = 3;");
          SQLiteCommand command = new SQLiteCommand(cnn);
           
          command.CommandText = "CREATE TABLE IF NOT EXISTS beispiel ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);";
          command.ExecuteNonQuery();
          command.CommandText = "CREATE TABLE IF NOT EXISTS beispiel ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);";
          command.ExecuteNonQuery();
        } else {
          cnn = new SQLiteConnection("Data Source = db.sqlite; Version = 3;");
        }
      } catch (Exception ex) {
        Console.WriteLine("Error While Init DB Connection\n" + ex);
      }
    }

    public void ParteiErstellen(string name, string candidate) {
      try {
        string sql = String.Format("insert into tbl_partei (name) values ('{0}','{1}')", name, candidate);
        SQLiteCommand command = new SQLiteCommand(sql, cnn);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Partei\n" + ex);
      }
    }

    public void WeahlerErstellen(string firstName, string lastName, string key) {
      try {
        string sql = String.Format("insert into tbl_weahler (firstName, lastName, key) values ('{0}', '{1}', '{2}')", firstName, lastName, key);
        SQLiteCommand command = new SQLiteCommand(sql, cnn);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Weahler\n" + ex);
      }
    }

    public bool Vote(Weahler weahler, Partei partei, string key) {
      try {
        cnn.Open();
        if (getVoteKey == key) {
          string sql = String.Format("", firstName, lastName);
          SQLiteCommand command = new SQLiteCommand(sql, cnn);
          command.ExecuteNonQuery();
          cnn.Close();
        }
      } catch (Exception ex) {
        Console.WriteLine("Error While Updating Waehler and incrementing count on Partei\n" + ex);
      }
    }

    public void WeahlerAnzeigen() {
      cnn.Open();
      string sql = "select * from tbl_weahler";
      SQLiteCommand command = new SQLiteCommand(sql, cnn);
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        Console.WriteLine("Name: " + reader["name"]);
      }
      cnn.Close();
    }

    public void ParteinAnzeigen() {
      cnn.Open();
      string sql = "select * from tbl_partei";
      SQLiteCommand command = new SQLiteCommand(sql, cnn);
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        Console.WriteLine("Name: " + reader["name"]);
      }
      cnn.Close();
    }
  }
}
