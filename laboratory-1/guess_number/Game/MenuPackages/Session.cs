using System;
using System.Collections.Generic;
using System.Text;
using guess_number.Game.Controllers;
using guess_number.Game.Handlers;
using guess_number.Game.MenuPackages.buttons;


namespace guess_number.Game.MenuPackages
{
    public enum Difficulties
    {
        Easy,
        Medium,
        Hard
    }

    public class Session
    {
        static public Difficulties difficulty = Difficulties.Medium;

        private int upBorder;
        private int downBorder;

        public Dictionary<Difficulties, List<int>> BorderDatas = new() {
            {Difficulties.Easy, new(){0, 30}},
            {Difficulties.Medium, new(){0, 100}},
            {Difficulties.Hard, new(){0, 1000}}
        };

        private int SecretNumber;

        public int Tries { get; set; } = 1;

        public bool IsActive = false;

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

        public Session(States diff)
        {

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
                ConsoleController.DrawMenu(AllMenuButtonsList["AfterGameActions"].ButtonsList);
            }
        }

        public void DrawGameInfo()
        {

            ConsoleController.Clear();

            StringBuilder info = new();
            info.AppendLine($"Difficulty is {difficulty}.");
            info.AppendLine($"Try №{Tries}.");
            ConsoleController.PrintTextLine(info.ToString());
        }

    }
}
