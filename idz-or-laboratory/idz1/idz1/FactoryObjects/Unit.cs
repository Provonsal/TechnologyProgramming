using System;
using idz1.FactoryIntefraces;

namespace idz1.FactoryObjects
{
    public class Unit : FactoryObject, IUnit
    {
        public int FactoryId { get; set; }

        public Unit(string name, string desc, int factId) : base(name, desc)
        {
            FactoryId = factId;
        }

        public Unit(string name, string desc, int? factId) : base(name, desc)
        {
            FactoryId = factId ?? throw new ArgumentNullException(nameof(factId));
        }

        public override string ToString()
        {
            return'{' + $"{ID}, {Name}, {Description}, {FactoryId}" + '}';
        }
    }
}
