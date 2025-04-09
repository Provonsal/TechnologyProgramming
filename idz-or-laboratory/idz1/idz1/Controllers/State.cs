using System;

namespace idz1.Controllers
{
    public class State : IState
    {
        public string StateText { get; set; }

        public State(string stateText)
        {
            StateText = stateText;
        }
    }
}
