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
        List<Room> l = manager2.room.GetAll();
        foreach(Room room in l) {
          Console.WriteLine(String.Format("Room {0} {1} {2}", room.id, room.name, room.description));
        }

        List<Device> l2 = manager2.device.GetAll();
        foreach(Device device in l2) {
          Console.WriteLine(String.Format("Room {0} {1}", device.id, device.price));
        }

        // Output Table
        // Room Testing
        // Output all Rooms
        Console.WriteLine("Outputing all Rooms from the Database");
        Utils.LoopListOutput(manager.GetAllRooms());
        // Insert a new Room
        Console.WriteLine("Creating a new Room");
        manager.CreateRoom("C401", "PC Room");
        // Modify a Room
        Console.WriteLine("Update a Room");
        manager.UpdateRoomByName("C105", "C666");
        // Output all Rooms with new added and Updated stuff
        Console.WriteLine("Outputing all Rooms from the Database");
        Utils.LoopListOutput(manager.GetAllRooms());
        // Delete a Room
        Console.WriteLine("Delete a Room");
        manager.DeleteRoom("C401");
        // Output all Rooms with new added and Updated stuff
        Console.WriteLine("Outputing all Rooms without the Deleted one");
        Utils.LoopListOutput(manager.GetAllRooms());
        // Reset updated Room
        manager.UpdateRoomByName("C666", "C105");

        // HardwareComponent Testing

        // Category Testing

        // Device Testing

      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
