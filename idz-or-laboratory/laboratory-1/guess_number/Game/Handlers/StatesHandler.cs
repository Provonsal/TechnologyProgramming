using System;

namespace guess_number.Game.Handlers
{
    /// <summary>
    /// Struct that contains state that binded to a button or can be called straight.
    /// </summary>
    public struct StatesHandler
    {
        public States State;
        public Action<Engine> Func;
        
        public StatesHandler(States State, Action<Engine> Func){
            this.State = State;
            this.Func = Func;
        }
    }
}
