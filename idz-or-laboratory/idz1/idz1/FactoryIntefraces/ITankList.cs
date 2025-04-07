using System;

namespace idz1.FactoryIntefraces
{
    public interface ITankList
    {
        public ITank this[int index] { get;set; }

        public int Length { get; }

        public void Add(ITank tank);

        public bool Remove(ITank tank);
    }
}
