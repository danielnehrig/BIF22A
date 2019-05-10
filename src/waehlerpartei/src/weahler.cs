using System;

namespace Politik.Type {
  public class Weahler {
    public Weahler(string name, string nachname, bool voted) {
      _firstName = name;
      _secondName = nachname;
      _voted = voted;
    }

    private string _firstName;
    public string firstName { get => _firstName; set => _firstName = value; }

    private string _secondName;
    public string _secondName { get => _secondName; set => _secondName = value; }

    private bool _voted;
    public bool voted { get => _voted; set => _voted = value; }
  }
}
