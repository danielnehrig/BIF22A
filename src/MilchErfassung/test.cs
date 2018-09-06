using System;

public class Cow {
  public string kuhId;
  public double Milchkapazitaet;

  public Cow(string id, double MilchStart) {
    this.kuhId = id;
    this.Milchkapazitaet = MilchStart;
  }
  public double Milchgeben(double Milch) {
    this.Milchkapazitaet -= Milch;
    return this.Milchkapazitaet;
  }
}

class Example {
  static void Main() {
    Cow name = new Cow("19392", 32.02);
    Console.WriteLine(name.Milchgeben(10));
  }
}
