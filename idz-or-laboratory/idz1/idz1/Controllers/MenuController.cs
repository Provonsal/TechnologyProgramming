using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static idz1.Controllers.IPrintController;

namespace idz1.Controllers
{
    public class MenuController : IMenuController
    {
        public IButtonsMenu CurrentMenu { get; set; }

        public Stack<IButtonsMenu> PreviousMenus { get; set; }

        public IDictionary<string, IButtonsMenu> AllMenus { get; set; }

        public IPrintController Output { get; set; }

        public IHandlersController Handlers { get; set; }

        public void AppendMenuButtons(IDictionary<string, IDictionary<string, string>> TextCallbackPairs)
        {
            foreach (KeyValuePair<string, IDictionary<string, string>> menu in TextCallbackPairs)
            {              
                AllMenus[menu.Key] = new ButtonsMenu(menu.Key, menu.Value);
            }
        }

        public void ChangeMenu(string menuName)
        {
            PreviousMenus.Push(CurrentMenu);
            CurrentMenu = AllMenus[menuName];
        }

        public void Back()
        {
            if (PreviousMenus.TryPop(out IButtonsMenu? prevMenu))
            {
                if (prevMenu is not null)
                {
                    CurrentMenu = prevMenu;
                }
                else
                {
                    throw new Exception("something gone wrong");
                }
            }
            else
            {
                throw new Exception("No way back");
            }
        }

        public void ShowCurrentMenu()
        {
            Output.ClearHandler();
            Output.PrintHandler(CurrentMenu.ToString());
        }

        public override string ToString()
        {
            return CurrentMenu.ToString();
        }

        public MenuController(
            IDictionary<string, IDictionary<string, string>> TextCallbackPairs,
            IPrintController output,
            IHandlersController handlers,
            string? mainMenuName = null
        )
        {
            Handlers = handlers;

            Output = output;

            AllMenus = new Dictionary<string, IButtonsMenu>();
            AppendMenuButtons(TextCallbackPairs);

            PreviousMenus = new Stack<IButtonsMenu>();

            if (mainMenuName is not null)
            {
                if (AllMenus.ContainsKey(mainMenuName))
                {
                    CurrentMenu = AllMenus[mainMenuName];
                }
                else
                {
                    Output.PrintHandler?.Invoke($"Menu with name {mainMenuName} not found");
                    throw new Exception($"Menu with name {mainMenuName} not found");
                }
            }
            else
            {
                CurrentMenu = new ButtonsMenu("DefaultMenuName", new KeyValuePair<string, string>());
            }
        }
    }
}
