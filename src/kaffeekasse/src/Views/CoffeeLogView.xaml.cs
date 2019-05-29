using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Coffee.Views {
  public class CoffeeLogView : UserControl {
    public CoffeeLogView() {
      this.InitializeComponent();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
