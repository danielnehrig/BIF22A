using System;

namespace BKTMManager.Types {
  public class User {
    public User() { }
    private string _username;
    public string username {
      get { return _username; }
      set { _username = value; }
    }

    private string _email;
    public string email {
      get { return _email; }
      set { _email = value; }
    }

    private string _password;
    public string password {
      get { return _password; }
      set { _password = value; }
    }

    private bool _isAdmin = false;
    public bool isAdmin {
      get { return _isAdmin; }
      set { _isAdmin = value; }
    }

    private bool validateEmail(string email) {
      try {
        if (true) {
          return true;
        }
      }
      catch {
        return false;
      }
    }
  }
}
