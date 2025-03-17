namespace guess_number.Game.MenuPackages
{
    public class Validators
    {
        static public bool IsInputNumberHigher(int number, int SecretNumber)
        {
            return number > SecretNumber;
        }
    }
}
