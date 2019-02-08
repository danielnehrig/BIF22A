using System;
using System.Collections.Generic;
using BKTMManager.Helper;
using BKTMManager.Types;
using BKTMManager.Administration;

namespace BKTMManager {
  class Program {
    public static int Main(string[] args) {
      try {
        // Read the Config which holds Database connection information
        Config config = new Config("config.cfg");
        Dictionary<string, string> cnnInfo = config.cnnInfo;

        // Load Administration manager
        AdministrationManager manager = new AdministrationManager(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);

        // Load Administration manager v2 with repo design pattern
        Manager manager2 = new Manager(cnnInfo);

        // Output Table
        // Room Testing
        // Output all Rooms
        Console.WriteLine("Outputing all Rooms from the Database");
        Utils.LoopListOutput(manager2.room.GetAll());
        // Insert a new Room
        Console.WriteLine("Creating a new Room");
        manager.CreateRoom("C401", "PC Room");
        // Modify a Room
        Console.WriteLine("Update a Room C105 to C666");
        manager.UpdateRoomByName("C105", "C666");
        // Output all Rooms with new added and Updated stuff
        Console.WriteLine("Outputing all Rooms from the Database");
        Utils.LoopListOutput(manager2.room.GetAll());
        // Delete a Room
        Console.WriteLine("Delete a Room called C401");
        manager.DeleteRoom("C401");
        // Output all Rooms with new added and Updated stuff
        Console.WriteLine("Outputing all Rooms without the Deleted one");
        Utils.LoopListOutput(manager2.room.GetAll());
        // Reset updated Room
        manager.UpdateRoomByName("C666", "C105");

        // HardwareComponent Testing
        // Output all Components
        Console.WriteLine("Hardware Table");
        Utils.LoopListOutput(manager2.hardware.GetAll());

        // Category Testing
        // Output all Categorys
        Console.WriteLine("Category Table");
        Utils.LoopListOutput(manager2.category.GetAll());

        // Device Testing
        // Output all Devices
        Console.WriteLine("Device Table");
        Utils.LoopListOutput(manager2.device.GetAll());

      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
