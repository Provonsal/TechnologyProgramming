using System;
using System.Collections.Generic;

namespace guess_number.Game.MenuPackages.buttons
{

    /// <summary>
    /// Struct for storing menu of buttons signed with a name.
    /// </summary>
    public struct ButtonsMenu
    {
        /// <summary>
        /// The name of the menu.
        /// </summary>
        public readonly string MenuName;

        /// <summary>
        /// List of `Button` objects.
        /// </summary>
        public List<Button> ButtonsList { get; set; }

        public ButtonsMenu(string MenuName, List<Button> ButtonsList) {
            this.MenuName = MenuName;
            this.ButtonsList = ButtonsList;
        }
    }
}
