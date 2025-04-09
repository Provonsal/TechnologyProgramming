using System;

namespace idz1.Controllers
{
    public delegate void Act(string state);
    
    public interface IHandler
    {
        public string State { get; set; }

        public IHandler? NextHandler { get; set; }

        public Act Handle {get;set;}

        public void Catch(string state);
    }
}
