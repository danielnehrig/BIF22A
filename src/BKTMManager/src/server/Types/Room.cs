namespace BKTMManager.Types {
  interface IRoom {
    int id { get; set; }
    string name { get; set; }
  }

  public class Room : IRoom {
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

    public Room() {
    }

    public Room(int id, string name) {
      this._id = id;
      this._name = name;
    }
  }
}
