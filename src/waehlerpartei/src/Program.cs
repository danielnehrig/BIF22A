using System;
using Politik.Type;
using Politik.Admin;

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
      Weahler waehler = admin.GetWaehler("Daniel", "Nehrig");
      Partei partei = admin.GetPartei("SPD");
      admin.Vote(waehler, partei, "13371337");
      admin.ParteinAnzeigen();
    }
  }
}
