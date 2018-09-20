using System;
using System.Collections.Generic;

public class Cow {
  private int _cowId;
  public int cowId {
    get { return _cowId; }
    set { _cowId = value; }
  }

  private Euter _euter;
  public Euter euter {
    get { return _euter; }
    //set { _euter = value; }
  }

  public Cow(int id, double milkstart) {
    _cowId = id;
    _euter = new Euter(milkstart);
  }
}

public class Euter {
  private double _milkvolume;
  public double Milkvolume {
    get { return _milkvolume; }
    set { _milkvolume = value; }
  }
  public Euter(double milkstart) {
    _milkvolume = milkstart;
  }
  public double giveMilk(double Milk) {
    _milkvolume -= Milk;
    return _milkvolume;
  }
}

public class Stall {
  private List<Cow> _place = new List<Cow>();
  public List<Cow> place {
    get { return _place; }
    set { _place = value; }
  }
  public void addToList(Cow cow) {
    _place.Add(cow);
  }
}

class Example {
  static void Main() {
    int amount = 5;
    Stall stall = new Stall();
    for (int i=0; i < amount; i++) {
      Cow name = new Cow(i, 32.02);
      stall.addToList(name);
    }
    Console.WriteLine(stall.place[0].euter.giveMilk(10));
  }
}
