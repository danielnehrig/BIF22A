using System;
using System.IO;
using Mono.Data.Sqlite;
using Politik.Type;

namespace Politik.Admin {
  public class Administration {
    SqliteConnection cnn;

    public Administration() {
      Bootstrap();
    }

    public void Bootstrap() {
      try {
        if(!File.Exists("db.sqlite")) {
          SqliteConnection.CreateFile("db.sqlite");
          cnn = new SqliteConnection("Data Source = db.sqlite; Version = 3;");
          cnn.Open();
          SqliteCommand command = new SqliteCommand(cnn);
          command.CommandText = @"CREATE TABLE IF NOT EXISTS waehler
                                ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                  firstName VARCHAR(100) NOT NULL,
                                  lastName VARCHAR(100) NOT NULL,
                                  key VARCHAR(20) NOT NULL,
                                  voted tinyint DEFAULT 0);";
          command.ExecuteNonQuery();
          command.CommandText = @"CREATE TABLE IF NOT EXISTS partei
                                ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL,
                                  candidate VARCHAR(100) NOT NULL, votes int DEFAULT 0);";
          command.ExecuteNonQuery();
          cnn.Close();
        } else {
          cnn = new SqliteConnection("Data Source = db.sqlite; Version = 3;");
        }
      } catch (Exception ex) {
        Console.WriteLine("Error While Init DB Connection\n" + ex);
      }
    }

    public void ParteiErstellen(string name, string candidate) {
      try {
        cnn.Open();
        string sql = String.Format("insert into partei (name, candidate) values ('{0}','{1}')", name, candidate);
        SqliteCommand command = new SqliteCommand(sql, cnn);
        command.ExecuteNonQuery();
        cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Partei\n" + ex);
      }
    }

    public void WaehlerErstellen(string firstName, string lastName, string key) {
      try {
        cnn.Open();
        string sql = String.Format("insert into waehler (firstName, lastName, key) values ('{0}', '{1}', '{2}')", firstName, lastName, key);
        SqliteCommand command = new SqliteCommand(sql, cnn);
        command.ExecuteNonQuery();
        cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Waehler\n" + ex);
      }
    }

    public Waehler GetWaehler(string firstName, string lastName) {
      Waehler waehler = null;
      try {
        cnn.Open();
        string sql = String.Format("select * from waehler where firstName = '{0}' AND lastName = '{1}'", firstName, lastName);
        SqliteCommand command = new SqliteCommand(sql, cnn);
        SqliteDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          if (reader.GetString(reader.GetOrdinal("firstName")) == firstName &&
              reader.GetString(reader.GetOrdinal("lastName")) == lastName) {
                waehler = new Waehler(reader);
              }
        }
        cnn.Close();
        return waehler;
      } catch (Exception ex) {
        Console.WriteLine("Error While Creating Waehler\n" + ex);
      }
      return waehler;
    }

    public Partei GetPartei(string name) {
      Partei partei = null;
      try {
        cnn.Open();
        string sql = String.Format("select * from partei where name = '{0}'", name);
        SqliteCommand command = new SqliteCommand(sql, cnn);
        SqliteDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          if (reader.GetString(1) == name) {
            partei = new Partei(reader);
          }
        }
        cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine("Error While Get Partei\n" + ex);
      }
      return partei;
    }

    public bool Vote(Waehler waehler, Partei partei, string key) {
      try {
        cnn.Open();
        if (waehler.key == key && !waehler.voted) {
          string sql = String.Format(@"UPDATE waehler SET voted = 1 WHERE firstName = '{0}' AND lastName = '{1}';
                                       UPDATE partei SET votes = votes + 1 WHERE name = '{2}';", waehler.firstName, waehler.lastName, partei.name);
          SqliteCommand command = new SqliteCommand(sql, cnn);
          command.ExecuteNonQuery();
        }
        cnn.Close();
        return true;
      } catch (Exception ex) {
        Console.WriteLine("Error While Updating Waehler and incrementing count on Partei\n" + ex);
				return false;
      }
      return false;
    }

    public void WeahlerAnzeigen() {
      cnn.Open();
      string sql = "select * from waehler";
      SqliteCommand command = new SqliteCommand(sql, cnn);
      SqliteDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        Console.WriteLine("Name: " + reader["name"]);
      }
      cnn.Close();
    }

    public void ParteinAnzeigen() {
      cnn.Open();
      string sql = "select * from partei";
      SqliteCommand command = new SqliteCommand(sql, cnn);
      SqliteDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        Console.WriteLine(String.Format("Name: {0} - Votes : {1}", reader.GetString(1), reader.GetInt32(3)));
      }
      cnn.Close();
    }
  }
}
