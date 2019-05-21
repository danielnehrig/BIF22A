using System.Data.SqlClient;

namespace Program {
  public class User {
    public User(SqlDataReader reader) {
      _username = reader.GetString(2);
      _password = reader.GetString(3);
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
    private bool _loggedIn;
    public bool loggedIn {
      set => _loggedIn = value;
      get => _loggedIn;
    }
  }
}
