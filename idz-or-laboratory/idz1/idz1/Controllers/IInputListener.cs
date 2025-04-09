using System;

namespace idz1.Controllers
{
    public interface IInputListener
    {
        public delegate string In();

        public In Handler { get; set; }

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
