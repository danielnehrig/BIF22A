using System;

namespace Politik.Type {
  public class Weahler {
    public Weahler(string name, string nachname) {
      _name = name;
      _nachname = nachname;
    }

    private string _name;
    public string name { get => _name; set => _name = value; }

    private string _nachname;
    public string nachname { get => _nachname; set => _nachname = value; }

    private bool _geweahlt;
    public bool geweahlt { get => _geweahlt; set => _geweahlt = value; }
  }
}
