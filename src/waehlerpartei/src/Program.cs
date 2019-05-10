using System;
using Politik.Type;
using Politik.Admin;

namespace Program {
  public class MainProgram {
    public static void Main(string[] args) {
      Administration admin = new Administration();
      admin.WeahlerErstellen("Kevin", "Peters");
      admin.WeahlerErstellen("Daniel", "Nehrig");
      admin.WeahlerErstellen("Bjarne", "Christel");
      admin.ParteiErstellen("CDU", "MERKEL");
      admin.ParteiErstellen("SPD", "KLOPPERT");
      admin.ParteiErstellen("AFD", "MONGA");
      admin.ParteiErstellen("DIE PARTEI", "TONKA");
      Weahler waehler = admin.GetWeahler("Daniel", "Nehrig");
      admin.Vote(waehler);
      admin.ParteinAnzeigen();
    }
  }
}
