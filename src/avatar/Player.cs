using System;
using System.Collections.Generic;

namespace Game {
  interface IPlayer {
    void getPlayerName();
  }

  class Player : Actor {
    public Player(string name) : base(name) {
    }

    public void getPlayerName() {
      Console.WriteLine("Player name is : " + this.name);
    }
  }
}
