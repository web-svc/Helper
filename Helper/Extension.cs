using System;
/// <summary>
/// Helper is to assist with the Extension method for providing common functionality
/// </summary>
namespace Helper
{
    /// <summary>
    /// Extension method for Convert operation
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// converts object to boolean
        /// </summary>
        /// <param name="value">expects object value</param>
        /// <returns>returns either true/ false</returns>
        public static bool ConvertToBoolean(this object value) => Convert.ToBoolean(value);
        /// <summary>
        /// converts object to string
        /// </summary>
        /// <param name="value">expects object value</param>
        /// <returns>returns string</returns>
        public static string ConvertToString(this object value) => Convert.ToString(value);
    }
}
