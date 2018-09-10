using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontoKlasse {
  class Program {
    static void Main() {
      Kontoverwaltung kv = new Kontoverwaltung();
      kv.kontoErstellen("1287783", "Hannes", 120.6, "4132");
      kv.kontoErstellen("1287782", "Kevin", 120.6, "4992");


      try {
        // Test if logged in
        Konto tmpKonto = kv.anmelden("1287782", "4992");
        tmpKonto.einzahlen(20);
        Console.WriteLine("Kontostand : " + tmpKonto.kontostand());

        // Test if wrong tan
        Konto tmpKonto2 = kv.anmelden("1287782", "4991");
        tmpKonto2.einzahlen(10);
      } catch (InvalidCastException err) {
        Console.WriteLine(err);
      }
    }
  }
}
