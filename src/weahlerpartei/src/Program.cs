using System;
using Politik.Type;
using Politik.Admin;

namespace Program {
  public class MainProgram {
    public static void Main(string[] args) {
      Administration admin = new Administration();
      admin.WeahlerErstellen(new Weahler("Kevin", "Peters"));
      admin.WeahlerErstellen(new Weahler("Daniel", "Nehrig"));
      admin.WeahlerErstellen(new Weahler("Bjarne", "Christel"));
    }
  }
}
