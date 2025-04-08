using System;

namespace idz1
{
    public class Engine
    {
        public delegate void Log(string message); 
        public event Log? Logger;

        public Engine(){
            
        }
    }
}
