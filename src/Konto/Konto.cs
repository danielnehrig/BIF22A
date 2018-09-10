using System;

namespace kontoKlasse {
  class Konto {
    private string _name;
    public string name {
      get { return _name; }
      set { _name = value; }
    }

    private string _kontonummer;
    public string kontonummer {
      get { return _kontonummer; }
    }

    private string _tan;
    public string tan {
      get { return _tan; }
      set { _tan = value; }
    }

    private bool _angemeldet;
    public bool angemeldet {
      get { return _angemeldet; }
      set { _angemeldet = value; }
    }

    private bool loggedIn() {
      if (_angemeldet == true) {
        return true;
      } else {
        throw new System.InvalidOperationException("Not logged in");
      }
    }

    private double _betrag;
    public double betrag {
      get { return _betrag; }
    }

    public Konto(string knr, string name, double betrag, string tan) {
      _kontonummer = knr;
      _tan = tan;
      _name = name;
      _betrag = betrag;
    }

    public bool einzahlen(double einzahlung) {
      if (loggedIn()) {
        if (einzahlung > 0) {
          _betrag += einzahlung;
          return true;
        }
        return false;
      }
      return false;
    }

    public double kontostand() {
      if (loggedIn()) {
        return _betrag;
      }
      return 0;
    }
  }
}
