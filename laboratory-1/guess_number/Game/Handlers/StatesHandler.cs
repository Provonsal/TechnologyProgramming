using System;

namespace guess_number.Game.Handlers
{
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
