using System;
using System.Collections.Generic;

namespace kontoKlasse {
  class Kontoverwaltung {
    private List<Konto> _lk = new List<Konto>();
    public List<Konto> lk {
      get { return _lk; }
      set { _lk = value; }
    }

    public void kontoErstellen(string knr, string name, double betrag, string tan) {
      _lk.Add(new Konto(knr, name, betrag, tan));
    }

    public bool kontoLoeschen(string knr) {
      bool result = false;

      foreach (Konto item in lk) {
        if (knr == item.kontonummer) {
          _lk.Remove(item);
          result = true;
        } else {
          result = false;
          throw new System.InvalidOperationException("No Konto found");
        }
      }
      return result;
    }

    public Konto anmelden(string knr, string tan) {
      Konto result = null;
      foreach (Konto item in lk) {
        if (knr == item.kontonummer) {
          if (tan == item.tan) {
            item.angemeldet = true;
            result = item;
          } else {
            throw new System.InvalidOperationException("Wrong TAN");
          }
        }
      }
      return result;
    }

    public void abmelden(string knr) {
      foreach (Konto item in lk) {
        if (knr == item.kontonummer) {
          item.angemeldet = false;
        }
      }
    }

  }
}
