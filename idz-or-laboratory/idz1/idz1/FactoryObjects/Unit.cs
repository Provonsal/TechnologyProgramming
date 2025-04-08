using System;
using idz1.FactoryIntefraces;

namespace idz1.FactoryObjects
{
    public class Unit : FactoryObject, IUnit
    {
        public int FactoryId { get; set; }

        public Unit(string name, string description, int factId, int? id = null) 
            : base(name, description, id)
        {
            FactoryId = factId;
        }

        public override string ToString()
        {
            return'{' + $"{ID}, {Name}, {Description}, {FactoryId}" + '}';
        }
    }
}
