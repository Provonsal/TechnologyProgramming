namespace guess_number.Game.MenuPackages
{
    public class Validators
    {
        /// <summary>
        /// Method that telling you: are the left argument is higher than right one.
        /// </summary>
        /// <param name="number">The number entered by user</param>
        /// <param name="SecretNumber">Generated random secret number of game session.</param>
        /// <returns></returns>
        static public bool IsInputNumberHigher(int number, int SecretNumber)
        {
            return number > SecretNumber;
        }
    }
}
