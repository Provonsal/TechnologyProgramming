using System;

namespace idz1.Controllers
{
    public interface IPrintController
    {
        void Print(string message);
        void Listen();
    }
}
