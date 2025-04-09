using System;

namespace idz1.Controllers
{
    public class Handler : IHandler
    {
        public string State { get; set; }

        public IHandler? NextHandler { get; set; }

        public Act Handle { get; set; }

        public void Catch(string state)
        {
            if (state == State)
            {
                Handle(state);
            }

            NextHandler?.Catch(state);

        }

        public Handler(string state, Act func)
        {
            Handle = func;
            State = state;
        }
    }
}
