using System;

namespace idz1.FactoryIntefraces
{
    public interface IUnit : IFactoryObject
    {
        public int FactoryId { get; set; }
    }
}
