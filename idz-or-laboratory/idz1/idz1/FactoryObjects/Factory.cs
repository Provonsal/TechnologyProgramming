using System;
using idz1.FactoryIntefraces;

namespace idz1.FactoryObjects
{
    public class Factory : FactoryObject, IFactory
    {
        public Factory(string name, string desc) : base(name, desc)
        {

        }

    }
}
