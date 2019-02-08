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
        // Deprecated but still in use for inserting and updating data if i can't get the new design done by the deadline
        // AdministrationManager manager = new AdministrationManager(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);

        // Load Administration manager v2 with repo design pattern
        Manager manager2 = new Manager(cnnInfo);

        Console.Clear();
        string x = "";
        while(x != "x") {
          Console.WriteLine("BKTMManager\nWelcome\n\n");
          Console.WriteLine("Your Options:\n1.User Manager\n2.Device Manager\n3.Room Manager\n4.Category Manager\n5.Hardware manager\nx.Exit\n");

          Console.Write("Awaiting input : ");
          x = Console.ReadLine();
          string values = "";
          string a = "";
          string col = "";
          string change = "";
          string options = "Your Options:\n1.GetAll\n2.GetById\n3.Create\n4.Update\n5.Delete\nx.Stop\n\n";
          string id = "1";
          
          switch(x) {
            case "1":
              Console.Clear();
              Console.WriteLine("Welcome to the User Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch(a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager2.user.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager2.user.GetById(Convert.ToInt32(id))); break;
                case "3": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.user.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager2.user.Create(values);
                  break;
                case "4": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.user.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine(); 
                  manager2.user.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager2.user.Delete(Convert.ToInt32(id)); Console.WriteLine("ID "+id+" deleted"); break;
              }
              break;
            case "2":
              Console.Clear();
              Console.WriteLine("Welcome to the Device Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch(a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager2.device.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager2.device.GetById(Convert.ToInt32(id))); break;
                case "3": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.device.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager2.device.Create(values);
                  break;
                case "4": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.device.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine(); 
                  manager2.device.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager2.device.Delete(Convert.ToInt32(id)); Console.WriteLine("ID "+id+" deleted"); break;
              }
              break;
            case "3":
              Console.Clear();
              Console.WriteLine("Welcome to the Room Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch(a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager2.room.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager2.room.GetById(Convert.ToInt32(id))); break;
                case "3": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.room.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager2.room.Create(values);
                  break;
                case "4": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.room.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine(); 
                  manager2.room.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager2.room.Delete(Convert.ToInt32(id)); Console.WriteLine("ID "+id+" deleted"); break;
              }
              break;
            case "4":
              Console.Clear();
              Console.WriteLine("Welcome to the Category Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch(a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager2.category.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager2.category.GetById(Convert.ToInt32(id))); break;
                case "3": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.category.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager2.category.Create(values);
                  break;
                case "4": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.category.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine(); 
                  manager2.category.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager2.category.Delete(Convert.ToInt32(id)); Console.WriteLine("ID "+id+" deleted"); break;
              }
              break;
            case "5":
              Console.Clear();
              Console.WriteLine("Welcome to the Hardware Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch(a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager2.hardware.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager2.hardware.GetById(Convert.ToInt32(id))); break;
                case "3": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.hardware.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager2.hardware.Create(values);
                  break;
                case "4": 
                  Console.WriteLine(String.Format("Format: {0}", manager2.hardware.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine(); 
                  manager2.hardware.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager2.hardware.Delete(Convert.ToInt32(id)); Console.WriteLine("ID "+id+" deleted"); break;
              }
              break;
          }
        }

      //  // Deprecated Program Run structure

      //  // Output Table
      //  // Room Testing
      //  // Output all Rooms
      //  Console.WriteLine("Outputing all Rooms from the Database");
      //  Utils.LoopListOutput(manager2.room.GetAll());
      //  // Insert a new Room
      //  Console.WriteLine("Creating a new Room");
      //  manager.CreateRoom("C401", "PC Room");
      //  // Modify a Room
      //  Console.WriteLine("Update a Room C105 to C666");
      //  manager.UpdateRoomByName("C105", "C666");
      //  // Output all Rooms with new added and Updated stuff
      //  Console.WriteLine("Outputing all Rooms from the Database");
      //  Utils.LoopListOutput(manager2.room.GetAll());
      //  // Delete a Room
      //  Console.WriteLine("Delete a Room called C401");
      //  manager.DeleteRoom("C401");
      //  // Output all Rooms with new added and Updated stuff
      //  Console.WriteLine("Outputing all Rooms without the Deleted one");
      //  Utils.LoopListOutput(manager2.room.GetAll());
      //  // Reset updated Room
      //  manager.UpdateRoomByName("C666", "C105");

      //  // HardwareComponent Testing
      //  // Output all Components
      //  Console.WriteLine("Hardware Table");
      //  Utils.LoopListOutput(manager2.hardware.GetAll());

      //  // Category Testing
      //  // Output all Categorys
      //  Console.WriteLine("Category Table");
      //  Utils.LoopListOutput(manager2.category.GetAll());

      //  // Device Testing
      //  // Output all Devices
      //  Console.WriteLine("Device Table");
      //  Utils.LoopListOutput(manager2.device.GetAll());

      //  // User Testing
      //  // Output all Users
      //  Console.WriteLine("User Table");
      //  Utils.LoopListOutput(manager2.user.GetAll());
      //  Console.WriteLine("Updateing User Table root to test");
      //  manager2.user.Update(1, "username", "'test'");
      //  Utils.LoopListOutput(manager2.user.GetAll());
      //  manager2.user.Update(1, "username", "'root'");

      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
