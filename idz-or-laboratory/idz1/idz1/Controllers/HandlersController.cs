using System;
using System.Collections.Generic;

namespace idz1.Controllers
{
    public class HandlersController: IHandlersController
    {
        public IList<IHandler> Handlers {get; set;}

        public void AttachHandler(IHandler newChainMember){
            Handlers.Add(newChainMember);
        }

        public void StartTheChainWave(string state){
            if (Handlers.Count > 0)
            {
                Handlers[0].Catch(state);
            }
        }

        public HandlersController(params KeyValuePair<string, Act>[] handlers){
            
            Handlers = (IList<IHandler>) new List<Handler>();

            for (int i = 0; i < handlers.Length; i++)
            {
                AttachHandler(new Handler(handlers[i].Key, handlers[i].Value));
            }
        }
    }
}
