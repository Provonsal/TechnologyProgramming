using System;

namespace idz1.Controllers
{
    public delegate void Out(string message);
    public interface IPrintController
    {

        public Out Handler { get; set; }

        public event Out Print
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
