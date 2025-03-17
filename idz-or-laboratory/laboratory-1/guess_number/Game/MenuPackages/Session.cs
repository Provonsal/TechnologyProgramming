using System;
using System.Collections.Generic;
using System.Text;
using guess_number.Game.Controllers;
using guess_number.Game.Handlers;
using guess_number.Game.MenuPackages.buttons;


namespace guess_number.Game.MenuPackages
{
    /// <summary>
    /// Enumeration for game difficulties.
    /// </summary>
    public enum Difficulties
    {
        Easy,
        Medium,
        Hard
    }

    /// <summary>
    /// Class representeting of game session. Every new started game should be from a new game session. Otherwise the number will be the same every time.
    /// Dont forget to recreate session.
    /// </summary>
    public class Session
    {
        static public Difficulties difficulty = Difficulties.Medium;

        private int upBorder;
        private int downBorder;

        /// <summary>
        /// Dictionary for difficulties and their ranges.
        /// </summary>
        public Dictionary<Difficulties, List<int>> BorderDatas = new() {
            {Difficulties.Easy, new(){0, 30}},
            {Difficulties.Medium, new(){0, 100}},
            {Difficulties.Hard, new(){0, 1000}}
        };

        private int SecretNumber;

        public int Tries { get; set; } = 1;

        public bool IsActive = false;

        /// <summary>
        /// Dictionary for menu buttons. 
        /// The format is {`MenuName`: {`ButtonText`: `StateOfTheButton`}}. 
        /// </summary>
        public readonly Dictionary<string, Dictionary<string, States>> TextCallbackPairs = new(){
            {
                "AfterGameActions",
                new() {
                    {"Retry", States.StartGame},
                    {"Settings", States.Settings},
                    {"Exit to mainmenu", States.Mainmenu}
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
        private void InitButtons()
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
        /// Gains the difficulty and creating session and range based on the gained difficulty.
        /// Have bad implementation. Need to be reworked.
        /// </summary>
        /// <param name="diff">One of 3 options: `States.EasyDiff`, `States.MediumDiff`, `States.HardDiff`.</param>
        public Session(States diff)
        {


            // Bad way to translate one enum to another but other decisions will be more complex.
            switch (diff)
            {
                case States.EasyDiff:
                    difficulty = Difficulties.Easy;
                    break;
                case States.MediumDiff:
                    difficulty = Difficulties.Medium;
                    break;
                case States.HardDiff:
                    difficulty = Difficulties.Hard;
                    break;
                default:
                    difficulty = Difficulties.Easy;
                    break;
            }
            downBorder = BorderDatas[difficulty][0];
            upBorder = BorderDatas[difficulty][1];
            SecretNumber = new Random().Next(downBorder, upBorder);
            InitButtons();

        }

        public void IncTries()
        {
            Tries += 1;
        }

        public void ResetTries(){
            Tries = 1;
        }

        public void MakeActive(){
            IsActive = true;
        }

        public void MakeUnactive(){
            IsActive = false;
        }

        /// <summary>
        /// Checking the number entered by user and deciding what to do: congrats the player or give a hint.
        /// </summary>
        /// <param name="number">Entered by player number.</param>
        public void ValidateNumber(int number)
        {

            const string Higher = "above";
            const string Lower = "below";

            DrawGameInfo();
            ConsoleController.PrintTextLine($"Prev number: {number}\n");
            if (number != SecretNumber)
            {
                ConsoleController.PrintTextLine($"The number is {(Validators.IsInputNumberHigher(number, SecretNumber) ? Lower : Higher)}.");
                IncTries();
            }
            else
            {
                IsActive = false;
                ConsoleController.Clear();
                ConsoleController.PrintTextLine($"Congrats! You guessed the number!\nThe number was {SecretNumber}.\nYou have used {Tries} tries to guess.\n");
                ConsoleController.DrawMenu(AllMenuButtonsDict["AfterGameActions"].ButtonsList);
            }
        }

        /// <summary>
        /// Method for drawing current game info in to console.
        /// </summary>
        public void DrawGameInfo()
        {

            ConsoleController.Clear();

            StringBuilder info = new();
            info.AppendLine($"Difficulty is {difficulty}.");
            info.AppendLine($"Try №{Tries}.");
            info.AppendLine("Type exit() to exit the game.");
            ConsoleController.PrintTextLine(info.ToString());
        }

    }
}
