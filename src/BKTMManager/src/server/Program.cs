using System;
using System.Collections.Generic;
using BKTMManager.Helper;
using BKTMManager.Administration;

namespace BKTMManager {
  class Program {
    public static int Main(string[] args) {
      try {
        // Read the Config
        Config config = new Config("config.cfg");
        Dictionary<string, string> cnnInfo = config.cnnInfo;

        // Load Administration manager
        AdministrationManager manager = new AdministrationManager(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);

        // Load Administration manager v2 with repo design pattern
        Manager manager2 = new Manager(cnnInfo);
        manager2.room.GetAll();

        // Output Table
         Utils.LoopListOutput(manager.GetAllRooms());


         // Main Programm Logic
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
