using System.Data.SqlClient;

namespace Program {
  public class Teacher : User {
    public Teacher(SqlDataReader reader) {
      _firstName = reader.GetString(0);
      _lastName = reader.GetString(1);
      _username = reader.GetString(2);
      _password = reader.GetString(3);
      _accAmount = reader.GetDouble(4);
      _isActive = Convert.ToBool(reader.GetInt(5));
    }

    private string _firstName;
    public string firstName {
      set => _firstName = value;
      get => _firstName;
    }

    private string _lastName;
    public string lastName {
      set => _lastName = value;
      get => _lastName;
    }

    private bool _isActive;
    public bool isActive {
      set => _isActive = value;
      get => _isActive;
    }

    private double _accAmount;
    public double accAmount {
      set => _accAmount = value;
      get => _accAmount;
    }
  }
}
