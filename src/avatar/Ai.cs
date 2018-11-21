using System;
using System.Collections.Generic;

namespace Game {
  class Ai : Actor {
    public Ai(string name) : base(name) {
    }

    public void getAiName() {
      Console.WriteLine("Ai name is : " + _name);
    }
  }
}
