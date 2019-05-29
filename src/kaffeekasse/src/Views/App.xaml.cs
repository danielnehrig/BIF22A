using Avalonia;
using Avalonia.Markup.Xaml;

namespace Coffee.Views {
    public class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }
   }
}
