using System;

namespace praktika1.validators
{
    ///  <summary>
    /// Class for validating integer values.
    /// </summary>
    public class IntValidator
    {
        /// <summary>
        /// Checks if an integer value is below zero.
        /// </summary>
        ///
        /// <param name="value">The integer value to check.</param>
        /// 
        /// <returns>
        /// True if the value is below zero, false otherwise.
        /// </returns>
        public static bool IsBelowZero(int value)
        {
            return value < 0;
        }
    }

}
