using System;
using Mono.Data.Sqlite;

namespace Politik.Type {
  public class Partei {
    public Partei(SqliteDataReader reader) {
      _name = reader.GetString(0);
      _candidate = reader.GetString(1);
      _counter = reader.GetInt32(2);
    }

    private string _name;
    public string name { get => _name; set => _name = value; }

    private string _candidate;
    public string candidate { get => _candidate; set => _candidate = value; }

    private int _counter;
    public int counter { get => _counter; set => _counter = value; }
  }
}
