using System;

namespace Politik.Type {
  public class Partei {
    public Partei(string name, string candidate, string counter) {
      _name = name;
      _candidate = candidate;
      _counter = counter;
    }

    private string _name;
    public string name { get => _name; set => _name = value; }

    private string _candidate;
    public string candidate { get => _candidate; set => _candidate = value; }

    private int _counter;
    public int counter { get => _counter; set => _counter = value; }
  }
}
