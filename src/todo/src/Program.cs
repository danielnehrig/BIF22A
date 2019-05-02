using System;
using System.Collections.Generic;

namespace Program {

  public interface ITodo {
    string status {
      get;
      set;
    }

    string description {
      get;
      set;
    }

    void changeStatus(int status);
    bool addItem(AbstractTodo t);
    bool getItem();
    bool removeItem();
  }

  public abstract class AbstractTodo {
    private string _status = "Open";
    public string status {
      get { return _status; }
      set { _status = value; }
    }

    private string _description;
    public string description {
      get { return _description; }
      set { _description = value; }
    }

    public AbstractTodo(string description) {
      this._description = description;
    }

    public abstract void display(int depth);
    public abstract void changeStatus(int status);
    // public abstract void getItem(int t);
    public abstract void addItem(AbstractTodo t);
    public abstract void removeItem(AbstractTodo t);
  }

  public class TodoList : AbstractTodo {
    public List<AbstractTodo> _todoChild = new List<AbstractTodo>();

    public TodoList(string description) : base(description) {}

    public override void changeStatus(int status) {
    }

    public override void addItem(AbstractTodo t) {
      _todoChild.Add(t);
    }

    public override void removeItem(AbstractTodo t) {
      _todoChild.Remove(t);
    }

    public override void display(int depth)
    {
      Console.WriteLine(new String('-', depth) + description);

      foreach (AbstractTodo item in _todoChild) {
        item.display(depth + 2);
      }
    }
  }

  public class Todo : AbstractTodo {
    public Todo(string description) : base(description) {}

    public override void changeStatus(int status) {
      switch(status) {
        case 1 : this.status = "InProgress"; break;
        case 2 : this.status = "Done"; break;
        default: this.status = "Open"; break;
      }
    }

    public override void addItem(AbstractTodo t) {
      Console.WriteLine("Can not add item from Todo");
    }

    public override void removeItem(AbstractTodo t) {
      Console.WriteLine("Can not remove item from Todo");
    }

    public override void display(int depth) {
      Console.WriteLine(new String('-', depth) + description);
    }
  }

  public class Program {
    public static void Main(string[] args) {
      TodoList todoList = new TodoList("Repair List");
      todoList.addItem(new Todo("pc"));
      todoList.addItem(new Todo("lamp"));
      TodoList todoList2 = new TodoList("Buy List");
      todoList2.addItem(new Todo("Sandwhich"));
      todoList2.addItem(new Todo("Cheese"));
      TodoList todoList3 = new TodoList("Tech List");
      todoList3.addItem(new Todo("TV"));
      todoList2.addItem(todoList3);
      todoList.addItem(todoList2);
      todoList.addItem(new Todo("Bike"));

      todoList.display(2);

    }
  }
}
