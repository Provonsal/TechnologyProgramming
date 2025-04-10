using System;
using System.Collections.Generic;

namespace idz1.Controllers
{
    public class HandlersController: IHandlersController
    {
        public IList<IHandler> Handlers {get; set;}

        public void AttachHandler(IHandler newChainMember){
            
            if (Handlers.Count == 0)
            {
                Handlers.Add(newChainMember);
            } else {
                Handlers[Handlers.Count-1].NextHandler = newChainMember;
                Handlers.Add(newChainMember);
            }



        }

        public void StartTheChainWave(string state, Engine eng){
            if (Handlers.Count > 0)
            {
                Handlers[0].Catch(state, eng);
            }
        }

        public HandlersController(params KeyValuePair<string, Act>[] handlers){
            
            Handlers = new List<IHandler>();

            for (int i = 0; i < handlers.Length; i++)
            {
                AttachHandler(new Handler(handlers[i].Key, handlers[i].Value));
            }
        }
    }
}
