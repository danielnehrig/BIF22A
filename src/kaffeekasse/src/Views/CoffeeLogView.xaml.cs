using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Coffee.Views {
  public class CoffeeLogView : UserControl {
    public CoffeeLogView() {
      this.InitializeComponent();

      // var dg = this.FindControl<DataGrid>("dataGrid1");
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
