using System;
using guess_number.Game.Handlers;

namespace guess_number.Game.MenuPackages.buttons
{
    public struct Button
    {
        public States State {get;set;}
        public string Name {get;set;}

        public Button(string Name, States State){
            this.Name = Name;
            this.State = State;
        }
    }
}
