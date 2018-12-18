using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.net;

namespace BKTMManager {
  class Program {
    public static int Main(string[] args) {
      try {
        // Read the Config
        Config config = new Config("config.cfg");
        // Load DeviceAdmin manager
        DeviceAdministration inventory = new DeviceAdministration(config.cnnInfo["ip"], config.cnnInfo["db"], config.cnnInfo["user"], config.cnnInfo["pw"]);
        inventory.getRoomById("1");
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 0;
      }
      return 1;
    }
  }
}
