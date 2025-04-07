using System;
using System.Collections.Generic;
using idz1.FactoryIntefraces;

namespace idz1.Controllers
{
    public class CompanyController
    {

        private readonly IFactoryList _factories;

        private readonly IUnitsList _units;

        private readonly ITankList _tanks;

        public CompanyController(IFactoryList factories, IUnitsList units, ITankList tanks)
        {
            _factories = factories;
            _units = units;
            _tanks = tanks;
        }

        public IUnit FindUnit(string tankName)
        {
            for (int i = 0; i < _units.Length; i++)
            {
                if (_tanks[i].Name == tankName)
                {
                    if (_tanks[i].UnitId <= _units.Length)
                    {
                        return _units[_tanks[i].UnitId];
                    }
                    else
                    {
                        throw new KeyNotFoundException("Unit not in the units collection.");
                    }
                }
            }
            
            throw new KeyNotFoundException("Tank has not found.");
        }
    
        public IFactory FindFactory(IUnit unit){
            for (int i = 0; i < _factories.Length; i++)
            {
                if (_factories[i].ID == unit.FactoryId)
                {
                    return _factories[i];
                }
            }
            throw new KeyNotFoundException(nameof(unit));
        }

        public uint GetTotalTanksVolume(){
            
            uint summ = 0;

            for (int i = 0; i < _tanks.Length; i++)
            {
                summ += _tanks[i].Volume;
            }
            
            return summ;
        }

    }
}
