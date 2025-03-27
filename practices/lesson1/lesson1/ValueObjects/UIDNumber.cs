using System;


namespace lesson1.ValueObjects
{
    struct UIDNumber
    {
        public long Number { get; set; }

        public UIDNumber(long num)
        {
            if (num < 1000000000 || num >= 10000000000)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(num),
                    "Wrong number. The number is out of range.");
            }
            else
            {
                Number = num;
            }
        }
    }
}
