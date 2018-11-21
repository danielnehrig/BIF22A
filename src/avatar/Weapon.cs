using System;
using System.Collections.Generic;

namespace Game {
  interface IWeapon {
    int damage {
      get;
      set;
    }
    int speed {
      get;
      set;
    }
  }

  abstract class Weapon : Item, IWeapon {
    public Weapon(int damage, int speed, int gold, string name) : base(gold, name) {
      this.speed = speed;
      this.damage = damage;
    }

    protected int _damage;
    public int damage {
      get { return _damage; }
      set { _damage = value; }
    }

    protected int _speed;
    public int speed {
      get { return _speed; }
      set { _speed = value; }
    }
  }

  class Sword : Weapon {
    public Sword(int damage, int speed) : base(damage, speed) {
    }
  }
}
