using System;
using System.Collections.Generic;

namespace Game {
  interface IActor {
    float livePoints {
      get;
      set;
    }
    string name {
      get;
      set;
    }
    int armor {
      get;
      set;
    }
    Position pos {
      get;
      set;
    }
    Inventory inventory {
      get;
      set;
    }
    bool isControlable {
      get;
      set;
    }
  }

  abstract class Actor : IActor {
    public Actor(string name) {
      this.name = name;
    }

    protected Inventory _inventory = new Inventory();
    public Inventory inventory {
      get { return _inventory; }
      set { _inventory = value;}
    }

    protected bool _isControlable = false;
    public bool isControlable {
      get { return _isControlable; }
      set { _isControlable = value; }
    }

    protected float _livePoints = 100;
    public float livePoints {
      get { return _livePoints; }
      set { _livePoints = value; }
    }

    protected int _armor = 0;
    public int armor {
      get { return _armor; }
      set { _armor = value; }
    }

    protected string _name;
    public string name {
      get { return _name; }
      set { _name = value; }
    }

    protected Position _pos = new Position(0, 0);
    public Position pos {
      get { return _pos; }
      set { _pos = value; }
    }
  }
}
