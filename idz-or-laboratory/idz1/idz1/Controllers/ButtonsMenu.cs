using System;
using System.Collections.Generic;

namespace idz1.Controllers
{
    public class ButtonsMenu : IButtonsMenu
    {
        public IList<IButton> Buttons { get; set ; }
        public string MenuName { get; set; }

        public IButton? FindButton(string? index)
        {
            
            if (index is not null)
            {

                if (int.TryParse(index, out int int_index))
                {
                    if (int_index < Buttons.Count)
                    {
                        return Buttons[int_index];
                    }
                    else
                    {
                        return null;
                    }
                } 
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void Add(IButton button){
            Buttons.Add(button);
        }

        public bool Remove(IButton button){
            return Buttons.Remove(button);
        }

        public IEnumerator<IList<IButton>> GetEnumerator()
        {
            return (IEnumerator<IList<IButton>>)Buttons.GetEnumerator();
        }

        public ButtonsMenu(string menuName, params KeyValuePair<string, string>[] buttons){
            
            MenuName = menuName;

            Buttons = (IList<IButton>) new List<Button>();

            for (int i = 0; i < buttons.Length; i++)
            {
                Add(new Button(buttons[i].Key, buttons[i].Value));
            }
        }
    }
}
