using System;
using BKTMManager.Helper;
using BKTMManager.Administration;

namespace BKTMManager {
  class Program {
    public static int Main(string[] args) {
      try {
        // Read the Config
        Config config = new Config("config.cfg");

        // Load Administration manager
        AdministrationManager manager = new AdministrationManager(config.cnnInfo["ip"], config.cnnInfo["db"], config.cnnInfo["user"], config.cnnInfo["pw"]);

        // Output Table
        Utils.LoopListOutput(manager.GetAllRooms());
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
