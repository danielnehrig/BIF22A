using System;
using System.Collections.Generic;

namespace BKTMManager.Types {
  class Device {
    private int _id;
    public int id {
      set { _id = value; }
      get { return _id; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    public Device() {
    }

    public Device(int id, string name) {
      this._id = id;
      this._name = name;
    }
  }
}
