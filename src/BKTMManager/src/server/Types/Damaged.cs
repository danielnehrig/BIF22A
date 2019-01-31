using System;

namespace BKTMManager.Types {
  public class Damaged {
    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }
    private DateTime _date;
    public DateTime date {
      get { return _date; }
      set { _date = value; }
    }
    private string _description;
    public string description {
      get { return _description; }
      set { _description = value; }
    }
  }
}
