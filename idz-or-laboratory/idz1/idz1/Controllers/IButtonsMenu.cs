using System;
using System.Collections.Generic;

namespace idz1.Controllers
{
    public interface IButtonsMenu
    {
        public IList<IButton> Buttons {get;set;}

        public string MenuName {get;set;}

        public IEnumerator<IList<IButton>> GetEnumerator();

        public IButton? FindButton(string? index);
    }
}
