using System;
using idz1.Controllers;

namespace idz1
{
    public class Engine
    {
        public IMenuController Menu {get;set;}

        public IInputListener Input {get;set;}

        public IPrintController Output {get;set;}

        public Engine(IInputListener inputListener, IPrintController output, IMenuController menu){
            Menu = menu;
            Input = inputListener;
            Output = output;

            Output.Handler?.Invoke("Engine has successfully created.");
        }

        public void ListenInput(){
            string? input = Input.Handler?.Invoke();

            IButton? pressed_button = Menu.CurrentMenu.FindButton(input);

            if (pressed_button is not null)
            {
                Output.Handler?.Invoke($"User pressed \"{pressed_button.Text}\"");
                
                Menu.Handlers.StartTheChainWave(pressed_button.State.StateText);
            } else{
                Output.Handler?.Invoke("Input unrecognized");
            }
        }

        
    }
}
