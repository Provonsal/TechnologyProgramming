using System;
using System.Collections.Generic;
using idz1.Collections;
using idz1.FactoryIntefraces;
using idz1.FactoryObjects;

namespace idz1.Controllers
{
    public class CompanyController : ICompanyController
    {

        public  IFactoryList Factories { get; private set; }

        public IUnitsList Units { get; private set; }

        public ITankList Tanks { get; private set; }

        public CompanyController(IFactoryList factories, IUnitsList units, ITankList tanks)
        {
            Factories = factories;
            Units = units;
            Tanks = tanks;
        }

        public IUnit FindUnit(string tankName)
        {
            for (int i = 0; i < Units.Count; i++)
            {
                if (Tanks[i].Name == tankName)
                {
                    if (Tanks[i].UnitId <= Units.Count)
                    {
                        return Units[Tanks[i].UnitId];
                    }
                    else
                    {
                        throw new KeyNotFoundException("Unit not in the units collection.");
                    }
                }
            }

            throw new KeyNotFoundException("Tank has not found.");
        }

        public IFactory FindFactory(int FactoryId)
        {
            for (int i = 0; i < Factories.Count; i++)
            {
                if (Factories[i].ID == FactoryId)
                {
                    return Factories[i];
                }
            }
            throw new KeyNotFoundException(nameof(FactoryId));
        }

        public uint GetTotalTanksVolume()
        {

            uint summ = 0;

            for (int i = 0; i < Tanks.Count; i++)
            {
                summ += Tanks[i].Volume;
            }

            return summ;
        }

    }
}
