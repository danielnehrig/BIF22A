using System;

namespace Program {
  class Program {
    public static void Main(string[] args) {
      Carrots carrots = new Carrots(0.90);
      carrots.Attach(new Restaurant("Mackays", 0.77));
      carrots.Attach(new Restaurant("Johnnys", 0.70));
      carrots.Attach(new Restaurant("Salad King", 0.75));

      carrots.PricePerPound = 0.79;
      carrots.PricePerPound = 0.76;
      carrots.PricePerPound = 0.74;
      carrots.PricePerPound = 0.79;
      carrots.PricePerPound = 0.90;

      Console.ReadKey();
    }
  }
}
