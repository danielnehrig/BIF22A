using System;
using Politik.Type;
using Politik.Admin;

namespace Program {
  public class MainProgram {
    public static void Main(string[] args) {
      Administration admin = new Administration();
      admin.WeahlerErstellen("Kevin", "Peters", "123242");
      admin.WeahlerErstellen("Daniel", "Nehrig", "13371337");
      admin.WeahlerErstellen("Bjarne", "Christel", "44448888");
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
