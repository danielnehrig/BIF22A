using System;
using System.Reactive.Linq;
using ReactiveUI;
using Coffee.Models;
using Coffee.Services;
using Coffee.Types;
using Coffee;

namespace Coffee.ViewModels {
  class MainWindowViewModel : ViewModelBase {
		ViewModelBase content;

    public MainWindowViewModel(Administration admin) {
      // Content = List = new TodoListViewModel(db.GetItems());
      // Content = Login = new LoginViewModel(admin);
      Content = CoffeeLog = new CoffeeLogViewModel(admin);
    }

    public ViewModelBase Content {
      get => content;
      private set => this.RaiseAndSetIfChanged(ref content, value);
    }

    public LoginViewModel Login { get; }
    public CoffeeLogViewModel CoffeeLog { get; }
    public TodoListViewModel List { get; }

    public void AddItem() {
      var vm = new AddItemViewModel();

      Observable.Merge(
          vm.Ok,
          vm.Cancel.Select(_ => (TodoItem)null))
          .Take(1)
          .Subscribe(model => {
            if (model != null) {
              List.Items.Add(model);
            }

            Content = List;
          });

      Content = vm;
    }
  }
}
