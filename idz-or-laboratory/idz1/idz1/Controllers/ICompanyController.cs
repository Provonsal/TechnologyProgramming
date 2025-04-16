using System;
using System.Collections.Generic;
using idz1.FactoryIntefraces;

namespace idz1.Controllers
{
    public interface ICompanyController
    {
        IFactoryList Factories { get; }
        IUnitsList Units { get; }
        ITankList Tanks { get; }
        public IUnit FindUnit(string tankName);
        public IFactory FindFactory(int FactoryId);
        public uint GetTotalTanksVolume();
    }
}
