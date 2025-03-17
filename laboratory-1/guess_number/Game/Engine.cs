using System;
using System.Collections.Generic;
using guess_number.Game.Controllers;
using guess_number.Game.Exceptions;
using guess_number.Game.Handlers;
using guess_number.Game.MenuPackages;

namespace guess_number.Game
{
    public class Engine
    {
        public Menu Menu {get; set;}

        public Session GameSession;
    
        public States GameDifficulty {get; set;} = States.MediumDiff;

        public List<StatesHandler> Handlers {get; set;} = new();

        public void Start(){
            ConsoleController.Clear();
            Menu.ShowCurrentMenu();
            while (true)
            {
                try
                {
                    ListenUser();
                }
                catch (ParsingErrorException)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unknown exception!", ex);
                }
                
            }
        }

        /// <summary>
        /// Method for listen users's input.
        /// It can recognize when game mode is on and the behavior are depends on it.
        /// Parsing the I/O input to get state and pass it to `HandleState`
        /// </summary>
        /// <exception cref="ParsingErrorException">When parsing is failed throwing an ParsingErrorException</exception>
        public void ListenUser()
        {
            string? input = ConsoleController.ListenInput();

            if (!GameSession.IsActive)
            {
                if (!int.TryParse(input, out int inputParsed))
                {
                    throw new ParsingErrorException("Error parsing");
                }

                HandleState(Menu.CurrentMenu.ButtonsList[inputParsed].State);
            }
            else
            {
                if (input == "exit()")
                {
                    HandleState(States.ExitGame);
                }
                else
                {
                    if (!int.TryParse(input, out int inputParsed))
                    {
                        throw new ParsingErrorException("Error parsing");
                    }

                    GameSession.ValidateNumber(inputParsed);
                }
            }
        }

        /// <summary>
        /// Method for handle accepted state that was be validated and transcripted from user's input.
        /// It will call function associated with accepted state in handlers list.
        /// </summary>
        /// <param name="state">Trigger state</param>
        private void HandleState(States state)
        {
            foreach (var handler in Handlers)
            {
                if (handler.State == state)
                {
                    handler.Func(this);
                }
            }
        }

        /// <summary>
        /// Method for register new state handler.
        /// The States object is the state that will be like a trigger for the Action function.
        /// The Action function should be static and accept Engine object.
        /// </summary>
        /// <param name="state">Trigger for the function.</param>
        /// <param name="func">Action that will be called when state triggered.</param>
        public void RegisterNewHandler(States state, Action<Engine> func)
        {
            Handlers.Add(new StatesHandler(state, func));
        }

        /// <summary>
        /// Method for register multiple new state handlers.
        /// The States object is the state that will be like a trigger for the Action function.
        /// The Action functions should be static and accept Engine object.
        /// </summary>
        /// <param name="dict">Dictionary with all your handlers view like {state, action}</param>
        public void RegisterHandlers(Dictionary<States, Action<Engine>> dict){
            foreach (var handler in dict)
            {
                RegisterNewHandler(handler.Key, handler.Value);
            }
        }

        public Engine(){
            GameSession = new(States.MediumDiff);
            Menu = new();
        }

    }
}
