using System;
using System.Collections.Generic;

namespace Program {
  public class Program {
    public static void Main(string[] args) {
      Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
      List<string> dog = new List<string>();
      List<string> cat = new List<string>();
      for
      string dogIn = "";
      string catIn = "";

      while(dogIn != "x") {
        Console.Write("Enter Dog Name (x = abort): ");
        dogIn = Console.ReadLine();
        dog.Add(dogIn);
      }

      while(catIn != "x") {
        Console.Write("Enter Cat Name (x = abort): ");
        catIn = Console.ReadLine();
        cat.Add(catIn);
      }

      dict.Add("Hund", dog);
      dict.Add("Katze", cat);

      foreach(var item in dict) {
        Console.Write(String.Format("{0}: ", item.Key));
        item.Value.ForEach(x => {Console.Write(x + " ");});
        Console.WriteLine("\n");
      }
    }
  }
}
