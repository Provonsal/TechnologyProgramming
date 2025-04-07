using System;

namespace idz1.FactoryIntefraces
{
    public interface IFactoryList
    {
        public IFactory this[int index] { get; set; }

        public int Length { get; }

        public void Add(IFactory fact);

        public bool Remove(IFactory fact);

    }
}
