using System;

namespace idz1.FactoryIntefraces
{
    public interface IFactoryObject
    {
        public int? ID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string ToString();
    }
}
