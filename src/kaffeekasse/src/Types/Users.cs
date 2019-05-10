namespace Program {
  public class User {
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
