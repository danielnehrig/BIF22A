using System;
using System.Collections.Generic;

namespace BKTMManager.Types {
  class Device {
    private string _id;
    public string id {
      get { return _id; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    public Device(string name) {
      this._name = name;
    }
  }
}
