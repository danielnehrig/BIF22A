using System;
using System.Collections.Generic;

namespace Program {
  abstract class Tier {
    private double _size;
    public double size {
      set { _size = value; }
      get { return _size; }
    }

    private Herz _herz;
    public Herz herz {
      set { _herz = value; }
      get { return _herz; }
    }

    public Tier() {
      _herz = new Herz();
    }
  }

  class Organ {
    private double _blut;
    public double blut {
      set { _blut = value; }
      get { return _blut; }
    }
  }

  class Herz : Organ {
    public void schlaegt() {
      Console.WriteLine("Herz Pumpt");
    }
  }

  class Saeugetier : Tier {
    public Saeugetier(double gSize) {
      size = gSize;
    }
    public void ichBin() {
      Console.WriteLine("Saeugetier");
    }
  }

  class Reptil : Tier {
    public Reptil(double gSize) {
      size = gSize;
    }
    public void ichBin() {
      Console.WriteLine("Retpil");
    }
  }
  
  class Fisch : Tier {
    public Fisch(double gSize) {
      size = gSize;
    }
    public void ichBin() {
      Console.WriteLine("Fisch");
    }
  }

  class Program {
    public static void Main() {
      Saeugetier hund = new Saeugetier(10);
      hund.ichBin();
      hund.herz.schlaegt();
      Console.WriteLine(hund.size);
      Reptil vogel = new Reptil(10);
      vogel.ichBin();
      vogel.herz.schlaegt();
      Console.WriteLine(vogel.size);
      Fisch karpfen = new Fisch(10);
      karpfen.ichBin();
      karpfen.herz.schlaegt();
      Console.WriteLine(karpfen.size);
    }
  }
}
