using System;
using System.Globalization;

namespace idz1.Controllers
{
    public interface IButton
    {
        public string Text {get; set;}
        public IState State {get;set;}
    }
}
