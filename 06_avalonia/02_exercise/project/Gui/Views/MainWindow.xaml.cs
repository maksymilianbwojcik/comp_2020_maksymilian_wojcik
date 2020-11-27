using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Gui.Views
{
    public class MainWindow : Window
    {
        [ExcludeFromCodeCoverage]
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}