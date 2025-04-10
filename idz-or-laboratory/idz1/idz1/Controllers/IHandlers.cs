using System;
using System.Collections;
using System.Collections.Generic;

namespace idz1.Controllers
{
    public interface IHandlersController
    {
        public IList<IHandler> Handlers {get; set;}

        public void AttachHandler(IHandler newChainMember);

        public void StartTheChainWave(string state, Engine eng);
    }
}
