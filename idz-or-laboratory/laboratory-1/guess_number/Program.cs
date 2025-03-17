using System;
using System.Threading;
using guess_number.Game;
using guess_number.Game.Controllers;
using guess_number.Game.Handlers;
using guess_number.Game.MenuPackages.buttons;

namespace guess_number
{
    class Program
    {

        static void ASettingsDraw(Engine eng){
            eng.Menu.PreviousMenus.Push(eng.Menu.CurrentMenu);
            eng.Menu.CurrentMenu = eng.Menu.AllMenuButtonsDict["SettingsMenuButtons"];
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void AChoosingDiffDraw(Engine eng){
            eng.Menu.PreviousMenus.Push(eng.Menu.CurrentMenu);
            eng.Menu.CurrentMenu = eng.Menu.AllMenuButtonsDict["SettingDifficultyMenuButtons"];
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void AComingBack(Engine eng){
            if (!eng.Menu.PreviousMenus.TryPop(out ButtonsMenu prevMenu)){
                ConsoleController.Clear();
                ConsoleController.PrintTextLine("There is no way back :)\n");
                eng.Menu.ShowCurrentMenu();
                return;
            }
            eng.Menu.CurrentMenu = prevMenu;
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void AExit(Engine eng){
            ConsoleController.Clear();
            Console.WriteLine("Exiting. See you next time!");
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write("\n");
            ConsoleController.Clear();
            Environment.Exit(0);
        }

        static void AStartGame(Engine eng){
            eng.GameSession = new(eng.GameDifficulty);
            eng.Menu.PreviousMenus.Push(eng.Menu.CurrentMenu);
            eng.Menu.CurrentMenu = eng.GameSession.AllMenuButtonsDict["AfterGameActions"];
            eng.GameSession.ResetTries();
            eng.GameSession.MakeActive();
            eng.GameSession.DrawGameInfo();
        }

        static void ASetEasyDiff(Engine eng){
            eng.GameDifficulty = States.EasyDiff;
            ConsoleController.Clear();
            ConsoleController.PrintTextLine($"Difficulty has changed to \"Easy difficulty\"");
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetMediumDiff(Engine eng){
            eng.GameDifficulty = States.MediumDiff;
            ConsoleController.Clear();
            ConsoleController.PrintTextLine($"Difficulty has changed to \"Medium difficulty\"");
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetHardDiff(Engine eng){
            eng.GameDifficulty = States.HardDiff;
            ConsoleController.Clear();
            ConsoleController.PrintTextLine($"Difficulty has changed to \"Hard difficulty\"");
            eng.Menu.ShowCurrentMenu();
        }

        static void AStopGame(Engine eng){
            eng.GameSession.MakeUnactive();
            AComingBack(eng);
        }

        static void AShowMainmenu(Engine eng){
            eng.GameSession.MakeUnactive();
            eng.Menu.CurrentMenu = eng.Menu.AllMenuButtonsDict["MainMenuButtons"];
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void APrintEasterEgg(Engine eng)
        {
            ConsoleController.Clear();
            ConsoleController.PrintTextLine("$$$_____$$$$$$$_$$$$$$$_$$$_______$$$_$$$$$$$$$$\n$$$____$$$____$$$____$$$_$$$_____$$$__$$$_______\n$$$____$$$_____$_____$$$_$$$_____$$$__$$$_______\n$$$_____$$$_________$$$___$$$___$$$___$$$$$$$$__\n$$$______$$$_______$$$_____$$$_$$$____$$$_______\n$$$_______$$$_____$$$______$$$_$$$____$$$_______\n$$$$$$$$$___$$$$$$$_________$$$$$_____$$$$$$$$$$");
            ConsoleController.PrintTextLine("                Liza i love you");
            ConsoleController.PrintTextLine("        (type \"menu()\" to come back)");
        }

        static void AChangeBackColor(Engine eng){
            eng.Menu.PreviousMenus.Push(eng.Menu.CurrentMenu);
            eng.Menu.CurrentMenu = eng.Menu.AllMenuButtonsDict["SettingBackgroundColor"];
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetGreenColor(Engine eng){
            Console.BackgroundColor = ConsoleColor.Green;
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetBlueColor(Engine eng){
            Console.BackgroundColor = ConsoleColor.Blue;
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetRedColor(Engine eng){
            Console.BackgroundColor = ConsoleColor.Red;
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetMagentaColor(Engine eng){
            Console.BackgroundColor = ConsoleColor.Magenta;
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void ASetdefaultColor(Engine eng){
            Console.ResetColor();
            ConsoleController.Clear();
            eng.Menu.ShowCurrentMenu();
        }

        static void Main(string[] args)
        {
            Engine eng = new();
            eng.RegisterHandlers(new(){
                {States.Settings, ASettingsDraw},
                {States.ChoiceDifficult, AChoosingDiffDraw},
                {States.Back, AComingBack},
                {States.Exit, AExit},
                {States.StartGame, AStartGame},
                {States.ExitGame, AStopGame},
                {States.Mainmenu, AShowMainmenu},
                {States.EasyDiff, ASetEasyDiff},
                {States.MediumDiff, ASetMediumDiff},
                {States.HardDiff, ASetHardDiff},
                {States.ChangeColor, AChangeBackColor},
                {States.ColorRed, ASetRedColor}, 
                {States.ColorGreen, ASetGreenColor},
                {States.ColorBlue, ASetBlueColor},
                {States.ResetColor, ASetdefaultColor},
                {States.ColorMagenta, ASetMagentaColor},
                {States.EasterEgg, APrintEasterEgg}
            });
            eng.Start(); 
        }
    }
}
