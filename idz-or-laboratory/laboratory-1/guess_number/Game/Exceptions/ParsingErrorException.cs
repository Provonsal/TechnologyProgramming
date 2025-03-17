using System;

namespace guess_number.Game.Exceptions{
    /// <summary>
    /// An exception for parsing errors during parsing player's input.
    /// </summary>
    public class ParsingErrorException : Exception
    {
        public ParsingErrorException() : base() { }
        public ParsingErrorException(string message) : base(message) { }
        public ParsingErrorException(string message, Exception inner) : base(message, inner) { }

        public override string ToString(){
            return "Parsing error";
        }
    }
}


