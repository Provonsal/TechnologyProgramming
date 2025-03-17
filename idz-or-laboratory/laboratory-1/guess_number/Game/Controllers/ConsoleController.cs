using System;
using System.Collections.Generic;
using System.Text;
using guess_number.Game.MenuPackages.buttons;

namespace guess_number.Game.Controllers
{
    /// <summary>
    /// Abstract layer for interacting with console.
    /// </summary>
    public class ConsoleController
    {
        public static string? ListenInput(){
            Console.Write("> ");
            return Console.ReadLine();
        }

        public static void PrintTextLine(string text){
            Console.WriteLine(text);
        }

        public static void Clear(){
            Console.Clear();
        }

        public static void DrawMenu(List<Button> buttons){

            short i = 0;

            StringBuilder ResultString = new();

            foreach (Button btn in buttons)
            {
                ResultString.AppendLine(Convert.ToString(i++) + ". " + btn.Name);
            }

            PrintTextLine(ResultString.ToString());
        }

    }
}
