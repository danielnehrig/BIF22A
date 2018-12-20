using System;
using System.Collections.Generic;

namespace BKTMManager.Types {
  class HardwareComponent {
    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    private string _description;
    public string description {
      set { _description = value; }
      get { return _description; }
    }

    private float _price;
    public float price {
      set { _price = value; }
      get { return _price; }
    }

    public HardwareComponent(string name, float price) {
      this._name = name;
      this._price = price;
    }

    public HardwareComponent(int id, string name, float price) {
      this._name = name;
      this._price = price;
    }

    public HardwareComponent() {
    }
  }
}
