using System;
using System.Collections.Generic;
using idz1.Properties;

namespace idz1.FactoryIntefraces
{
    public interface IUnitsList: IJsonSerializable, IList<IUnit>
    {
        
    }
}
