using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika1.validators
{
    ///  <summary> 
    /// Class for validating string values. 
    ///  </summary>
    public class StringValidator
    {
        /// <summary>
        /// Checks if a string value is not empty.
        /// </summary>
        ///
        ///  <param name="value">The string value to check.</param>
        /// 
        /// <returns>
        /// true if the value is not empty, false otherwise.
        /// </returns>
        public static bool IsNotEmpty(string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }
    }

}
