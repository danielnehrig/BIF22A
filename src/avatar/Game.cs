using System;
using System.Collections.Generic;
using System.Reflection;

namespace Game {
  interface IGame {
    List<Player> players {
      get;
      set;
    }
    List<Player> ai {
      get;
      set;
    }
    void setup();
  }

  class Game : IGame {
    private List<Player> _players = new List<Player>();
    public List<Player> players {
      get { return _players; }
      set { _players = value; }
    }

    private List<Ai> _ai = new List<Ai>();
    public List<Ai> ai {
      get { return _ai; }
      set { _ai = value; }
    }

    public void setup() {
      _players.Add(new Player("curb"));
      _ai.Add(new Ai("kokot"));
      Player curb = _players.Find(x => x.name == "curb");
      Console.WriteLine(curb.name);
      curb.pos.move("right");
      Console.WriteLine("Position X : " + curb.pos.fullPosition()[0] + " Y : " + curb.pos.fullPosition()[1]);
    }
  }

  class Program {
    static void Main(string[] args) {
      Game newGame = new Game();
      newGame.setup();
    }
  }
}
