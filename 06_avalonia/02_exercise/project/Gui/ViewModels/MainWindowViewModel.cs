using System;
using System.Reactive;
using ReactiveUI;

namespace Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; private set; }

        private string _name;
        public string Name 
        { 
            get => _name; 
            set => this.RaiseAndSetIfChanged(ref _name, value); 
        }

        public MainWindowViewModel()
        {
            _name = "World";
            Greeting = "Hello " + _name;
            
            DoClickCommand = ReactiveCommand.Create(OnClickCommand); 
        }


        public ReactiveCommand<Unit, Unit> DoClickCommand { get; }


        public void OnClickCommand()
        {
            Greeting = "Hello " + _name;
            _name = "";

            Console.WriteLine(Greeting);
        }
    }
}