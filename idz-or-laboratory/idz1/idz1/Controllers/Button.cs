using System;

namespace idz1.Controllers
{
    public class Button : IButton
    {
        public string Text {get;set;}

        public IState State {get;set;}

        public Button(string text, string state){
            Text = text;
            State = new State(state);
        }
    }
}
