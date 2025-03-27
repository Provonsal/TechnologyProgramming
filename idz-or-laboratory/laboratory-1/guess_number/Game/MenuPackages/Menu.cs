using System;
using System.Collections.Generic;
using guess_number.Game.Controllers;
using guess_number.Game.Handlers;
using guess_number.Game.MenuPackages.buttons;

namespace guess_number.Game.MenuPackages
{
    /// <summary>
    /// Class for representation a gaming menu with buttons and their states.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Current active menu on the screen.
        /// </summary>
        public ButtonsMenu CurrentMenu { get; set; }

        /// <summary>
        /// LIFO Stack of previous menus.
        /// </summary>
        public Stack<ButtonsMenu> PreviousMenus = new();

        /// <summary>
        /// Dictionary for menu buttons. 
        /// The format is {`MenuName`: {`ButtonText`: `StateOfTheButton`}}. 
        /// </summary>
        public readonly Dictionary<string, Dictionary<string, States>> TextCallbackPairs = new(){
        {
            "MainMenuButtons",
            new() {
                {"New Game", States.StartGame},
                {"Settings", States.Settings},
                {"Exit", States.Exit}
            }
        },

        {
            "SettingsMenuButtons",
            new() {
                {"Choise difficulty", States.ChoiceDifficult},
                {"Change background color", States.ChangeColor},
                {"Back", States.Back}
            }
        },

        {
            "SettingDifficultyMenuButtons",
            new() {
                {"Easy", States.EasyDiff},
                {"Medium", States.MediumDiff},
                {"Hard", States.HardDiff},
                {"Back", States.Back}
            }
        },
        {
            "SettingBackgroundColor",
            new () {
                {"Red", States.ColorRed},
                {"Green", States.ColorGreen},
                {"Blue", States.ColorBlue},
                {"Magenta", States.ColorMagenta},
                {"Reset color", States.ResetColor},
                {"Back", States.Back}
            }
        }
        };

        /// <summary>
        /// Dictionary for auto generated buttons from the previuos dictionary with button texts and states.
        /// The format is {`MenuName`: `ButtonsMenuObj`}.
        /// </summary>
        public Dictionary<string, ButtonsMenu> AllMenuButtonsDict = new();

        /// <summary>
        /// Method for generating buttons from `TextCallbackPairs` dict.
        /// </summary>
        void InitButtons()
        {
            foreach (var item in TextCallbackPairs)
            {
                List<Button> tmp = new();

                foreach (var item2 in item.Value)
                {
                    tmp.Add(new Button(item2.Key, item2.Value));
                }

                AllMenuButtonsDict[item.Key] = new ButtonsMenu(item.Key, tmp);
            }
        }

        /// <summary>
        /// Method for printing current menu to console.
        /// </summary>
        public void ShowCurrentMenu()
        {
            ConsoleController.DrawMenu(CurrentMenu.ButtonsList);
        }

        /// <summary>
        /// Initializating Menu object. While doing it, cycling through `TextCallbackPairs` and filling 
        /// `AllMenuButtonsDict` with generated `ButtonsMenu` objects.
        /// Setting as current menu "MainMenuButtons" value from AllMenuButtonsDict.
        /// </summary>
        public Menu()
        {
            InitButtons();
            CurrentMenu = AllMenuButtonsDict["MainMenuButtons"];
        }
    }
}
