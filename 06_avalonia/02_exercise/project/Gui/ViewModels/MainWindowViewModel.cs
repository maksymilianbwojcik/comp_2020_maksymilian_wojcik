using System;
using System.Reactive;
using ReactiveUI;

namespace Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string? _greeting;
        public string? Greeting 
        { 
            get => _greeting; 
            set => this.RaiseAndSetIfChanged(ref _greeting, value); 
        }
        private string? _name;
        public string? Name 
        { 
            get => _name; 
            set => this.RaiseAndSetIfChanged(ref _name, value); 
        }

        public MainWindowViewModel()
        {
            var button = this.WhenAnyValue(
                x => x.Name,
                x => !string.IsNullOrWhiteSpace(x));

            GreetingCommand = ReactiveCommand.Create<string>(
                DisplayGreeting,
                button);
        }

        public ReactiveCommand<string, Unit> GreetingCommand { get; }

        private void DisplayGreeting(string name)
        {
            Greeting = $"Hello {name}!";
            Name = null;
        }

    }
}