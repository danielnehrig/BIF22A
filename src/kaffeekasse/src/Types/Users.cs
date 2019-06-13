using System;
using System.Data;
using System.Data.SqlClient;

namespace Coffee.Types {
  public class User {
    public User(SqlDataReader reader) {
      _kzl = reader.GetString(reader.GetOrdinal("kzl"));
      _username = reader.GetString(reader.GetOrdinal("username"));
      _password = reader.GetString(reader.GetOrdinal("password"));
      _firstName = reader.GetString(reader.GetOrdinal("firstName"));
      _lastName = reader.GetString(reader.GetOrdinal("lastName"));
      _lastName = reader.GetString(reader.GetOrdinal("lastName"));
      _accAmount = reader.GetDouble(reader.GetOrdinal("accAmount"));
      _isActive = Convert.ToBoolean(reader.GetByte(reader.GetOrdinal("isActive")));
    }

    private string _kzl;
    public string kzl {
      set => _kzl = value;
      get => _kzl;
    }

    private string _username;
    public string username {
      set => _username = value;
      get => _username;
    }

    private string _password;
    public string password {
      set => _password = value;
      get => _password;
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

    private double _accAmount;
    public double accAmount {
      set => _accAmount = value;
      get => _accAmount;
    }

    private bool _isActive;
    public bool isActive {
      set => _isActive = value;
      get => _isActive;
    }
  }
}
