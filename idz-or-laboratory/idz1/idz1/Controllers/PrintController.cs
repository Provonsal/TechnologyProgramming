using System;

namespace idz1.Controllers
{
    public class PrintController : IPrintController
    {
        public Out Handler { get; set; }

        public PrintController(Out handler){
            Handler = handler;
        }
    }
}
