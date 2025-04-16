using System;
using System.Collections;
using System.Collections.Generic;
using idz1.Properties;

namespace idz1.FactoryIntefraces
{
    public interface IFactoryList: IJsonSerializable, IList<IFactory>
    {
        

    }
}
