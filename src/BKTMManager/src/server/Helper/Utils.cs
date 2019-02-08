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
    public static void LoopListOutput<T>(List<T> items) where T : IGlobalType {
      try {
        foreach (var item in items) {
          Console.WriteLine(item.WhatAmI());
        }
      } catch(Exception ex) {
        Console.WriteLine(ex);
      }
    }
  }
}
