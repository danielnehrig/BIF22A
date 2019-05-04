using System;

namespace Program {
  class Restaurant : IRestaurant {
    private string _name;
    private Veggies _veggie;
    private double _purchaseThreeeeshold;

    public Restaurant(string name, double purchaseThreeeeshold) {
      _name = name;
      _purchaseThreeeeshold = purchaseThreeeeshold;
    }

    public void Update(Veggies veggie) {
      Console.WriteLine("Notified {0} of {1}");
      if(veggie.PricePerPound < _purchaseThreeeeshold) {
        Console.WriteLine(_name + " wants to buy some " + veggie.GetType().Name + "!");
      }
    }

  }
}
