using System;
using System.Collections.Generic;
using BKTMManager.Types;

namespace BKTMManager.Helper {
  static class Utils {
    public static void LoopListOutput(List<Room> rooms) {
      try {
        Console.WriteLine("ID ; ROOM NAME");
        foreach (Room room in rooms) {
          Console.WriteLine(room.id + " " + room.name);
        }
      } catch(Exception ex) {
        Console.WriteLine(ex);
      }
    }
  }
}
