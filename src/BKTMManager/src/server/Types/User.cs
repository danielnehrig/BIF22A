using System.ComponentModel.DataAnnotations;

namespace BKTMManager.Types {
  abstract class User {
    private string _username;
    public string username {
      get { return _username; }
      set { _username = value; }
    }

    private string _email;
    public string email {
      get { return _email; }
      set { 
        if (this.validateEmail(value)) {
          _email = value;
        } else {
          Console.WriteLine("Error Bad Email");
        }
      }
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
        if (new EmailAddressAttribute().IsValid(email)) {
          return true;
        }
      }
      catch {
        return false;
      }
    }
  }
}
