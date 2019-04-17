using System;

namespace Politik.Type {
  public class Partei {
    public Partei(string name) {
      _name = name;
    }

    private string _name;
    public string name { get => _name; set => _name = value; }
  }
}
