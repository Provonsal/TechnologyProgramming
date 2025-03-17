using System;
using guess_number.Game.Handlers;

namespace guess_number.Game.MenuPackages.buttons
{
    /// <summary>
    /// Struct for represent a button.
    /// </summary>
    public struct Button
    {
        /// <summary>
        /// State of the button. Used for binding button to an action.
        /// </summary>
        public States State {get;set;}

        /// <summary>
        /// Name or in other words text of the button that will be displayed in the console.
        /// </summary>
        public string Name {get;set;}

        public Button(string Name, States State){
            this.Name = Name;
            this.State = State;
        }
    }
}
