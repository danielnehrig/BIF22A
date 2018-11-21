using System.Collections.Generic;

namespace Game {
  interface IPosition {
    int x {
      get;
      set;
    }
    int y {
      get;
      set;
    }
    int[] fullPosition();
    void movePlayer(string movement);
  }

  class Position {
    public Position(int startX, int startY) {
      this.x = startX;
      this.y = startY;
    }

    private int _x;
    public int x {
      get { return _x; }
      set { _x = value; }
    }

    private int _y;
    public int y {
      get { return _y; }
      set { _y = value; }
    }

    public int[] fullPosition() {
      int[] posValues = new int[] { this.x , this.y };
      return posValues;
    }

    public void move(string movement) {
      switch(movement) {
        case "up": ++_y; break;
        case "down": --_y; break;
        case "left": --_x; break;
        case "right": ++_x; break;
      }
    }
  }
}
