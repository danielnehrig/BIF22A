using System;
using System.Collections.Generic;
using BKTMManager.Administration;
using BKTMManager.Helper;
using BKTMManager.Types;

namespace BKTMManager.ConsoleApp {
  public class ConsoleApp {
    public ConsoleApp() { }
    public static int start(string[] args) {
      try {
        // Read the Config which holds Database connection information
        Config config = new Config("config.cfg");
        Dictionary<string, string> cnnInfo = config.cnnInfo;

        // Load Administration manager v2 with repo design pattern
        Manager manager = new Manager(cnnInfo);

        Console.Clear();
        Console.Write("Login: ");
        string username = Console.ReadLine();
        Console.Write("PW: ");
        string password = Console.ReadLine();

        User user = manager.user.Login(username, password);

        if (user == null) {
          return 0;
        }

        string x = "";
        while (x != "x") {
          Console.WriteLine("BKTMManager\nWelcome\n\n");
          Console.WriteLine("Your Options:\n1.User Manager\n2.Device Manager\n3.Room Manager\n4.Category Manager\n5.Hardware Manager\n6.Damaged Manager\nx.Exit\n");

          Console.Write("Awaiting input : ");
          x = Console.ReadLine();
          string values = "";
          string a = "";
          string col = "";
          string change = "";
          string options = "Your Options:\n1.GetAll\n2.GetById\n3.Create\n4.Update\n5.Delete\nx.Stop\n\n";
          string id = "1";

          switch (x) {
            case "1":
              Console.Clear();
              Console.WriteLine("Welcome to the User Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch (a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager.user.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager.user.GetById(Convert.ToInt32(id))); break;
                case "3":
                  Console.WriteLine(String.Format("Format: {0}", manager.user.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager.user.Create(values);
                  break;
                case "4":
                  Console.WriteLine(String.Format("Format: {0}", manager.user.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine();
                  manager.user.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager.user.Delete(Convert.ToInt32(id)); Console.WriteLine("ID " + id + " deleted"); break;
              }
              break;
            case "2":
              Console.Clear();
              Console.WriteLine("Welcome to the Device Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch (a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager.device.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager.device.GetById(Convert.ToInt32(id))); break;
                case "3":
                  Console.WriteLine(String.Format("Format: {0}", manager.device.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager.device.Create(values);
                  break;
                case "4":
                  Console.WriteLine(String.Format("Format: {0}", manager.device.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine();
                  manager.device.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager.device.Delete(Convert.ToInt32(id)); Console.WriteLine("ID " + id + " deleted"); break;
              }
              break;
            case "3":
              Console.Clear();
              Console.WriteLine("Welcome to the Room Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch (a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager.room.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager.room.GetById(Convert.ToInt32(id))); break;
                case "3":
                  Console.WriteLine(String.Format("Format: {0}", manager.room.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager.room.Create(values);
                  break;
                case "4":
                  Console.WriteLine(String.Format("Format: {0}", manager.room.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine();
                  manager.room.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager.room.Delete(Convert.ToInt32(id)); Console.WriteLine("ID " + id + " deleted"); break;
              }
              break;
            case "4":
              Console.Clear();
              Console.WriteLine("Welcome to the Category Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch (a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager.category.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager.category.GetById(Convert.ToInt32(id))); break;
                case "3":
                  Console.WriteLine(String.Format("Format: {0}", manager.category.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager.category.Create(values);
                  break;
                case "4":
                  Console.WriteLine(String.Format("Format: {0}", manager.category.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine();
                  manager.category.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager.category.Delete(Convert.ToInt32(id)); Console.WriteLine("ID " + id + " deleted"); break;
              }
              break;
            case "5":
              Console.Clear();
              Console.WriteLine("Welcome to the Hardware Manager");
              Console.WriteLine(options);
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch (a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager.hardware.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager.hardware.GetById(Convert.ToInt32(id))); break;
                case "3":
                  Console.WriteLine(String.Format("Format: {0}", manager.hardware.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager.hardware.Create(values);
                  break;
                case "4":
                  Console.WriteLine(String.Format("Format: {0}", manager.hardware.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine();
                  manager.hardware.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager.hardware.Delete(Convert.ToInt32(id)); Console.WriteLine("ID " + id + " deleted"); break;
              }
              break;
            case "6":
              Console.Clear();
              Console.WriteLine("Welcome to the Damaged Manager");
              Console.WriteLine(options + "6.GetAllPopulated");
              Console.Write("Awaiting input : ");
              a = Console.ReadLine();
              switch (a) {
                case "1": Console.Clear(); Utils.LoopListOutput(manager.damaged.GetAll()); break;
                case "2": id = Console.ReadLine(); Console.Clear(); Utils.Output(manager.damaged.GetById(Convert.ToInt32(id))); break;
                case "3":
                  Console.WriteLine(String.Format("Format: {0}", manager.damaged.columNames));
                  Console.Write("Awaiting value input: ");
                  values = Console.ReadLine();
                  manager.damaged.Create(values);
                  break;
                case "4":
                  Console.WriteLine(String.Format("Format: {0}", manager.damaged.columNames));
                  Console.Write("Awaiting Input ID: ");
                  id = Console.ReadLine();
                  Console.Write("Awaiting Input Colum Name: ");
                  col = Console.ReadLine();
                  Console.Write("Awaiting Input to change TO: ");
                  change = Console.ReadLine();
                  manager.damaged.Update(Convert.ToInt32(id), col, change);
                  break;
                case "5": Console.Write("Awaiting input ID: "); id = Console.ReadLine(); Console.Clear(); manager.damaged.Delete(Convert.ToInt32(id)); Console.WriteLine("ID " + id + " deleted"); break;
                case "6": Console.Clear(); Utils.LoopPopulatedListOutput(manager.damaged.GetAllPopulated()); break;
              }
              break;
          }
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
