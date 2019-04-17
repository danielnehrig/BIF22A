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

    public void ParteiErstellen(Partei partei) {
      try {
        string sql = String.Format("insert into tbl_partei (name) values ('{0}')", partei.name);
        SQLiteCommand command = new SQLiteCommand(sql, cnn);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Partei\n" + ex);
      }
    }

    public void WeahlerErstellen(Weahler weahler) {
      try {
        string sql = String.Format("insert into tbl_weahler (name) values ('{0}', '{1}')", weahler.name, weahler.nachname);
        SQLiteCommand command = new SQLiteCommand(sql, cnn);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Weahler\n" + ex);
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

    public void ParteiAnzeigen() {
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