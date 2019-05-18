using System;
using Politik.Admin;
using Politik.Type;

namespace Program {
  public class MainProgram {
    public static void Main(string[] args) {
      Administration admin = new Administration();
      admin.WaehlerErstellen("Kevin", "Peters", "123242");
      admin.WaehlerErstellen("Daniel", "Nehrig", "13371337");
      admin.WaehlerErstellen("Bjarne", "Christel", "44448888");
      admin.ParteiErstellen("CDU", "MERKEL");
      admin.ParteiErstellen("SPD", "KLOPPERT");
      admin.ParteiErstellen("AFD", "MONGA");
      admin.ParteiErstellen("DIE PARTEI", "TONKA");

      Console.WriteLine("Login");
      Console.WriteLine("Firstname : ");
      string firstName = Console.ReadLine();
      Console.WriteLine("Lastname : ");
      string lastName = Console.ReadLine();
      Console.WriteLine("Key : ");
      string key = Console.ReadLine();
      Waehler waehler = admin.GetWaehler(firstName, lastName);

      Console.WriteLine("Vote for : CDU, SPD, AFD");
      Console.WriteLine("Vote : ");
      string parteiName = Console.ReadLine();
      Partei partei = admin.GetPartei(parteiName);

      admin.Vote(waehler, partei, key);
      admin.ParteinAnzeigen();
    }
  }
}
