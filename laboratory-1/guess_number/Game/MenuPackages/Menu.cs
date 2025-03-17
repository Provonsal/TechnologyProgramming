using System;
using System.Collections.Generic;
using guess_number.Game.Controllers;
using guess_number.Game.Handlers;
using guess_number.Game.MenuPackages.buttons;

namespace guess_number.Game.MenuPackages
{
    public class Menu
    {
        public ButtonsMenu CurrentMenu { get; set; }
        public Stack<ButtonsMenu> PreviousMenus = new();

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

        public Dictionary<string, ButtonsMenu> AllMenuButtonsList = new();

        void InitButtons()
        {
            foreach (var item in TextCallbackPairs)
            {
                List<Button> tmp = new();

                foreach (var item2 in item.Value)
                {
                    tmp.Add(new Button(item2.Key, item2.Value));
                }

                AllMenuButtonsList[item.Key] = new ButtonsMenu(item.Key, tmp);
            }
        }

        public void ShowCurrentMenu()
        {
            ConsoleController.DrawMenu(CurrentMenu.ButtonsList);
        }

        public Menu()
        {
            InitButtons();
            CurrentMenu = AllMenuButtonsList["MainMenuButtons"];
        }
    }
}
