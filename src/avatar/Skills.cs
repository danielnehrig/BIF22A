using System;
using System.Collections.Generic;

namespace Game {
  interface ISkill {
    int damage {
      get;
      set;
    }
  }

  abstract class Skill : ISkill {
    public Skill(int damage) {
      this.damage = damage;
    }

    protected int _damage;
    public int damage {
      get { return _damage; }
      set { _damage = value; }
    }
  }
}
