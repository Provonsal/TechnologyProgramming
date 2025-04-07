using System;

namespace idz1.FactoryIntefraces
{
    public interface IUnitsList
    {
        public IUnit this[int index] { get; set; }

        public int Length { get; }

        public void Add(IUnit fact);

        public bool Remove(IUnit fact);
    }
}
