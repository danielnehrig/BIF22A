using System;
using Mono.Data.Sqlite;

namespace Politik.Type {
  public class Waehler {
    public Waehler(SqliteDataReader reader) {
      _firstName = reader.GetString(0);
      _lastName = reader.GetString(1);
      _key = reader.GetString(2);
      _voted = Convert.ToBoolean(reader.GetInt32(3));
    }

    private string _firstName;
    public string firstName { get => _firstName; set => _firstName = value; }

    private string _lastName;
    public string lastName { get => _lastName; set => _lastName = value; }

    private string _key;
    public string key { get => _key; set => _key = value; }

    private bool _voted;
    public bool voted { get => _voted; set => _voted = value; }
  }
}
