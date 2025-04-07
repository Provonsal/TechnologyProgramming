using System;
using idz1.FactoryIntefraces;

namespace idz1.FactoryObjects
{
    public class FactoryObject : IFactoryObject
    {
        public int? ID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public FactoryObject(string name, string desc)
        {
            ID = null;
            Name = name;
            Description = desc;
        }

        public override string ToString()
        {
            return '{' + $"{ID}, {Name}, {Description}" + '}';
        }
    }
}
