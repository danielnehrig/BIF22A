using Coffee.Types;

namespace Coffee.Models {
  public class UserItem {
    public string Username { get; set; }
    public bool Loggedin { get; set; }

    public UserItem(User user) {
      Username = user.username;
      Loggedin = user.loggedIn;
    }
  }
}
