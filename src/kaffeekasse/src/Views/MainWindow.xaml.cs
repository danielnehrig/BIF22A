using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Coffee.Views {
  public class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
