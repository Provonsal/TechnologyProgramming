using System;
using System.Collections.Generic;

namespace guess_number.Game.MenuPackages.buttons
{

    public struct ButtonsMenu
    {
        public readonly string MenuName;
        public List<Button> ButtonsList { get; set; }
        public ButtonsMenu(string MenuName, List<Button> ButtonsList) {
            this.MenuName = MenuName;
            this.ButtonsList = ButtonsList;
        }
    }
}
