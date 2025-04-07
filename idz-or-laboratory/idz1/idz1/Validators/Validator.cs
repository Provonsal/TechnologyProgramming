using System;

namespace idz1.Validators
{
    public class VolumeValidator
    {
        public static bool Validate(int volume, int maxVolume) {
            return (volume > 0) && (volume <= maxVolume);
        }
    }
}
