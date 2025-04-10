using System;

namespace idz1.Controllers
{
    public class InputListener : IInputListener
    {
        public In? Handler { get; set; }

        public InputListener(In? handler){
            Handler = handler;
        }
    }
}
