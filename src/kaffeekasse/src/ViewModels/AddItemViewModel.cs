using System.Reactive;
using ReactiveUI;
using Coffee.Models;

namespace Coffee.ViewModels {
	class AddItemViewModel : ViewModelBase {
		public string description;

    public AddItemViewModel() {
      var okEnabled = this.WhenAnyValue(
          x => x.Description,
          x => !string.IsNullOrWhiteSpace(x));

      Ok = ReactiveCommand.Create(
          () => new TodoItem { Description = Description },
          okEnabled);

      Cancel = ReactiveCommand.Create(() => {  });
    }

    public string Description {
      get => description;
      set => this.RaiseAndSetIfChanged(ref description, value);
    }

    public ReactiveCommand<Unit, TodoItem> Ok { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
  }
}
