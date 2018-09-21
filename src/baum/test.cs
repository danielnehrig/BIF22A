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

  public void spring() {
    foreach (Leaf leaf in _leaf) {
      leaf.color = "light green";
    }
  }

  public void autmn() {
    foreach (Leaf leaf in _leaf) {
      leaf.color = "brown";
    }
  }

  public void sommer() {
    foreach (Leaf leaf in _leaf) {
      leaf.color = "green";
    }
  }

  public void winter() {
    _leaf.Clear();
  }
}

class Leaf {
  private string _color;
  public string color {
    set { _color = value; }
    get { return _color; }
  }

  public Leaf(string gSeason) {
    season(gSeason);
  }

  private void season(string season) {
    if (season == "autmn")
      _color = "light green";
    if (season == "spring")
      _color = "brown";
    if (season == "summer")
      _color = "green";
    if (season == null)
      _color = "error";
  }
}

class Program {
  static void Main() {
    Tree tree = new Tree(5, 10, "autmn");
    Console.WriteLine(tree.size);
  }
}
