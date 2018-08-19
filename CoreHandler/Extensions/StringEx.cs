using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreHandler.Extensions
{
    public static class StringEx
    {
        /// <summary>
        /// Checks if the string is null or empty or just white space
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// Returns true if the string has any value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this string value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// Returns string.empty if the value is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EmptyIfNull(this string value)
        {
            return value ?? String.Empty;
        }

        /// <summary>
        /// Compares two string without considering the culture and case (case insensitive)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string value, string compareValue)
        {
            return value.EmptyIfNull().Equals(compareValue, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns a dynamic object in the JSON format
        /// </summary>
        /// <param name="value">The value which is to be converted to JSON</param>
        /// <param name="exposeError">True if you want to throw the conversion error</param>
        /// <returns></returns>
        public static dynamic AsJson(this string value, bool exposeError = false)
        {
            try
            {
                return JsonConvert.DeserializeObject<dynamic>(value);
            }
            catch (Exception)
            {
                if (exposeError)
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns Double value from the string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double AsDouble(this string value)
        {
            return Convert.ToDouble(value);
        }
    }
}
