using System;
using System.Collections.Generic;

class Tree {
  private List<Leaf> _leaf = new List<Leaf>();
  public List<Leaf> leaf {
    set { _leaf = value; }
    get { return _leaf; }
  }

  private double _size;
  public double size {
    set { _size = value; }
    get { return _size; }
  }

  public Tree(double size, int leafAmount, string season) {
    _size = size;
    generateLeafes(leafAmount, season);
  }

  private void generateLeafes(int leafAmount, string season) {
    for (int i=0; i < leafAmount; i++) {
      _leaf.Add(new Leaf(season));
    }
  }

  public void getAllLeafs() {
    foreach (Leaf leaf in _leaf) {
      Console.WriteLine("Leaf Color: " + leaf.color);
    }
  }

  public void spring() {
    foreach (Leaf leaf in _leaf) {
      leaf.color = "light green";
    }
    Console.WriteLine("We have now Spring");
  }

  public void autmn() {
    foreach (Leaf leaf in _leaf) {
      leaf.color = "brown";
    }
    Console.WriteLine("We have now Autmn");
  }

  public void summer() {
    foreach (Leaf leaf in _leaf) {
      leaf.color = "green";
    }
    Console.WriteLine("We have now Summer");
  }

  public void winter() {
    _leaf.Clear();
    Console.WriteLine("We have now Winter all leafs are gone :(");
  }
}

class Leaf {
  private string _color;
  public string color {
    set { _color = value; }
    get { return _color; }
  }

  public Leaf(string season) {
    setSeason(season);
  }

  private void setSeason(string season) {
    switch(season) {
      case "autmn": _color = "brown"; break;
      case "spring": _color = "light green"; break;
      case "summer": _color = "green"; break;
      default: _color = "error"; break;
    }
  }
}

class Program {
  static void Main() {
    Tree tree = new Tree(5, 10, "autmn");
    Console.WriteLine("Tree Size: " + tree.size + "m");
    tree.getAllLeafs();
    tree.spring();
    tree.getAllLeafs();
    tree.summer();
    tree.getAllLeafs();
    tree.winter();
    tree.getAllLeafs();
  }
}
