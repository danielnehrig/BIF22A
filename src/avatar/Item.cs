using System;

namespace Game {
  interface IItem {
    string name {
      get;
      set;
    }
    int goldValue {
      get;
      set;
    }
    bool useable {
      get;
      set;
    }
    bool tradeable {
      get;
      set;
    }
    bool collectable {
      get;
      set;
    }
  }

  abstract class Item : IItem {
    public Item(int gold, string name) {
      this.goldValue = gold;
      this.name = name;
    }

    private string _name;
    public string name {
      get { return _name; }
      set { _name = value; }
    }

    private int _goldValue;
    public int goldValue {
      get { return _goldValue; }
      set { _goldValue = value; }
    }

    private bool _useable;
    public bool useable {
      get { return _useable; }
      set { _useable = value; }
    }

    private bool _tradeable;
    public bool tradeable {
      get { return _tradeable; }
      set { _tradeable = value; }
    }

    private bool _collectable;
    public bool collectable {
      get { return _collectable; }
      set { _collectable = value; }
    }
  }
}
