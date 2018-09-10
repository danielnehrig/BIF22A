using System;

public class Cow {
  private string _kuhId;
  public string KuhId {
    get { return _kuhId; }
    set { _kuhId = value; }
  }

  private double _milchkapazitaet;
  public double Milchkapazitaet {
    get { return _milchkapazitaet; }
    set { _milchkapazitaet = value; }
  }

  public Cow(string id, double MilchStart) {
    _kuhId = id;
    _milchkapazitaet = MilchStart;
  }
  public double Milchgeben(double Milch) {
    _milchkapazitaet -= Milch;
    return _milchkapazitaet;
  }
}

class Example {
  static void Main() {
    Cow name = new Cow("19392", 32.02);
    Console.WriteLine(name.Milchgeben(10));
    Console.WriteLine(Math.random());
  }
}
