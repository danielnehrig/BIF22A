using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BKTMManager.Types;

namespace BKTMManager.Helper {
  public static class Utils {
    public static void LoopListOutput(List<Room> items) {
      try {
        Console.WriteLine("ID ; ROOM");
        foreach (Room item in items) {
          Console.WriteLine(item.id + " " + item.name);
        }
      } catch(Exception ex) {
        Console.WriteLine(ex);
      }
    }
  }
}
