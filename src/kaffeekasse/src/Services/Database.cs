using System.Collections.Generic;
using Coffee.Models;

namespace Coffee.Services {
  public class Database {
    public IEnumerable<TodoItem> GetItems() => new[] {
      new TodoItem { Description = "Walk the dog" },
      new TodoItem { Description = "Buy some milk" },
      new TodoItem { Description = "Learn Avalonia", IsChecked = true },
    };
  }
}
