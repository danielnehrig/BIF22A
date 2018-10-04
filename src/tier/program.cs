using System;
using System.Collections.Generic;

namespace Program {
  abstract class Animal {
    private double _size;
    public double size {
      set { _size = value; }
      get { return _size; }
    }

    private Heart _heart;
    public Heart heart {
      set { _heart = value; }
      get { return _heart; }
    }

    public Animal() {
      _heart = new Heart();
    }
  }

  class Organ {
    private double _blood;
    public double blood {
      set { _blood = value; }
      get { return _blood; }
    }
  }

  class Heart : Organ {
    public void beat() {
      Console.WriteLine("Heart Pumpt");
    }
  }

  class Saeugetier : Animal {
    public Saeugetier(double gSize) {
      size = gSize;
    }
    public void iAm() {
      Console.WriteLine("Saeugetier");
    }
  }

  class Reptil : Animal {
    public Reptil(double gSize) {
      size = gSize;
    }
    public void iAm() {
      Console.WriteLine("Retpil");
    }
  }
  
  class Fisch : Animal {
    public Fisch(double gSize) {
      size = gSize;
    }
    public void iAm() {
      Console.WriteLine("Fisch");
    }
  }

  class Program {
    public static void Main() {
      Saeugetier hund = new Saeugetier(10);
      hund.iAm();
      hund.heart.beat();
      Console.WriteLine(hund.size);
      Reptil vogel = new Reptil(10);
      vogel.iAm();
      vogel.heart.beat();
      Console.WriteLine(vogel.size);
      Fisch karpfen = new Fisch(10);
      karpfen.iAm();
      karpfen.heart.beat();
      Console.WriteLine(karpfen.size);
    }
  }
}
