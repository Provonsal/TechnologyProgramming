using System;

namespace idz1.Controllers
{
    public class Handler : IHandler
    {
        public string State { get; set; }

        public IHandler? NextHandler { get; set; }

        public Act Handle { get; set; }

        public void Catch(string state, Engine eng)
        {
            if (state == State)
            {
                Handle(eng);
            }

            NextHandler?.Catch(state, eng);

        }

        public Handler(string state, Act func)
        {
            Handle = func;
            State = state;
        }
    }
}
