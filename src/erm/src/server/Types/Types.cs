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

    private List<HardwareComponent> _hwComp = new List<HardwareComponent>();
    public List<HardwareComponent> hwComp {
      set { _hwComp = value; }
      get { return _hwComp; }
    }

    public Device(string name, List<HardwareComponent> components) {
      this._name = name;
      this._hwComp = components;
    }

    public float sumOfComponents() {
      float sum = 0;
      foreach (HardwareComponent Component in _hwComp) {
        sum += Component.price;
      }
      return sum;
    }
  }

  class HardwareComponent {
    private string _id;
    public string id {
      get { return _id; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
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
  }

  class Login {
  }

  abstract class User {
    private int _permission = 0;
    private string _login;
    private string _password;
  }

  class Teacher : User {
    private int _permission = 0;
  }

  class Admin : User {
    private int _permission = 1;
  }
}
