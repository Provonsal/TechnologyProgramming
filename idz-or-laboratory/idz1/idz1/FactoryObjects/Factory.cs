using System;
using idz1.FactoryIntefraces;

namespace idz1.FactoryObjects
{
    public class Factory : FactoryObject, IFactory
    {
        public Factory(string name, string description, int? id) : base(name, description, id)
        {

        }

    }
}
