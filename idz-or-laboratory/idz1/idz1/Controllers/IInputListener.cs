using System;

namespace idz1.Controllers
{
    public delegate string In();

    public interface IInputListener
    {

        public In? Handler { get; set; }

        public event In OutputHandler
        {
            add
            {
                Handler += value;
            }
            remove
            {
                Handler -= value;
            }
        }
    }
}
