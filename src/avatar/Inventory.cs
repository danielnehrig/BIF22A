using System;
using System.Collections.Generic;

namespace Game {
  interface IInventory {
    int inventorySize {
      get;
      set;
    }

    List<Item> items {
      get;
      set;
    }

    void showInventory();
    void addToInventory(Item item);
  }

  class Inventory : IInventory {
    public Inventory() {
    }

    private int _inventorySize;
    public int inventorySize {
      get { return _inventorySize; }
      set { _inventorySize = value; }
    }

    private List<Item> _items = new List<Item>();
    public List<Item> items {
      get { return _items; }
      set { _items = value; }
    }

    public void addToInventory(Item item) {
      this.items.Add(item);
    }

    public void showInventory() {
      this.items.ForEach(x => Console.WriteLine(x.name));
    }
  }
}
