using System;

namespace idz1.FactoryIntefraces
{
    public interface ITank : IFactoryObject
    {
        public uint Volume { get; set; }
        
        public uint MaxVolume {get; set;}

        public int UnitId {get; set;}

    }
}
