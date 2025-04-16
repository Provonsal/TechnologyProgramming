using System;
using idz1.Controllers;

namespace idz1
{
    public class Engine : IDisposable
    {
        public IMenuController Menu {get;set;}

        public IInputListener Input {get;set;}

        public IPrintController Output {get;set;}

        public ICompanyController Company {get;set;}

        public Engine(IInputListener inputListener, IPrintController output, IMenuController menu, ICompanyController company){
            Menu = menu;
            Input = inputListener;
            Output = output;
            Company = company;

            Output.Logger("Engine has successfully created.");
        }

        public void StartEngine(){
            Output.ClearHandler();
            Menu.ShowCurrentMenu();
            while (ListenInput())
            {
                Menu.ShowCurrentMenu();
            }
        }

        public bool ListenInput(){
            string? input = Input.Handler?.Invoke();

            IButton? pressed_button = Menu.CurrentMenu.FindButton(input);

            if (pressed_button is not null)
            {
                Output.Logger($"User pressed \"{pressed_button.Text}\".");
                
                Menu.Handlers.StartTheChainWave(pressed_button.State.StateText, this);
                return true;
            } else{
                Output.Logger("Input unrecognized.");
                return true;
            }
        }

        public void Dispose()
        {
            Output.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
