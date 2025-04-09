using System;
using System.Collections;
using System.Collections.Generic;

namespace idz1.Controllers
{
    public interface IMenuController
    {
        public IButtonsMenu CurrentMenu { get; set; }

        public Stack<IButtonsMenu> PreviousMenus { get; set; }

        public IDictionary<string, IButtonsMenu> AllMenus { get; set; }

        public IPrintController Output {get;set;}

        public IHandlersController Handlers { get; set; }

        public void LoadMenuButtons(Dictionary<string, Dictionary<string, string>> TextCallbackPairs);

        public void ChangeMenu(string button_id);

        public void Back();

        public void ShowCurrentMenu();

    }
}
