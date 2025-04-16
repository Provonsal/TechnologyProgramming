using System;
using idz1.FactoryIntefraces;
using idz1.Validators;

namespace idz1.FactoryObjects
{
    public class Tank : FactoryObject, ITank
    {

        public uint Volume { get; set; }
        public uint MaxVolume { get; set; }
        public int UnitId { get; set; }

        public Tank(string name, string description, int volume, int maxVolume, int unitId, int? id = null) 
            : base(name, description, id)
        {
            Volume = VolumeValidator.Validate(volume, maxVolume) ? 
                (uint)volume : throw new ArgumentOutOfRangeException(nameof(maxVolume));
            
            MaxVolume = maxVolume < 0 ? 
                throw new ArgumentOutOfRangeException(nameof(maxVolume)) : (uint)maxVolume;
            
            UnitId = unitId;
        }

    }
}
