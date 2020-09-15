using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
/// <summary>
/// Helper is to assist with the Extension method for providing common functionality
/// </summary>
namespace WebSvc.Helper
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
        /// <summary>
        /// converts object to int32
        /// </summary>
        /// <param name="value">expects object value</param>
        /// <returns>returns int32</returns>
        public static int ConvertToInteger(this object value) => Convert.ToInt32(Convert.IsDBNull(value) ? null : string.IsNullOrEmpty(value.ToString()) ? 0 : value);
        /// <summary>
        /// converts object to double
        /// </summary>
        /// <param name="value">expects object value</param>
        /// <returns>returns double</returns>
        public static double ConvertToDouble(this object value) => Convert.ToDouble(Convert.IsDBNull(value) ? null : string.IsNullOrEmpty(value.ToString()) ? 0 : value);
        /// <summary>
        /// converts object to datetime
        /// </summary>
        /// <param name="value">expects object value</param>
        /// <returns>returns datetime</returns>
        public static DateTime ConvertToDateTime(this object value) => Convert.ToDateTime(Convert.IsDBNull(value) ? null : string.IsNullOrEmpty(value.ToString()) ? 0 : value);
        /// <summary>
        /// converts object to Epoch & Unix Timestamp
        /// </summary>
        /// <param name="value">expects unix epoch time value</param>
        /// <returns>returns Epoch & Unix Timestamp</returns>
        public static DateTime ConvertToEpochUnixTimestamp(this object value) => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToDouble(Convert.IsDBNull(value) ? null : string.IsNullOrEmpty(value.ToString()) ? 0 : value)).ToLocalTime();
        /// <summary>
        /// converts object to int64 or bigint
        /// </summary>
        /// <param name="value">expects object value</param>
        /// <returns>returns int64</returns>
        public static long ConvertToBigInteger(this object value) => Convert.ToInt64(Convert.IsDBNull(value) ? null : string.IsNullOrEmpty(value.ToString()) ? 0 : value);
        /// <summary>
        /// filter text to Alpha and Numeric text only and remove an special char other than alphabets and numeric
        /// </summary>
        /// <param name="value">expects string value</param>
        /// <returns>return filtered text</returns>
        public static string FilterTextToAlphaNumeric(this string value) => Regex.Replace(Convert.ToString(value), Constant.Expression_Alpha_Numeric, string.Empty);
        /// <summary>
        /// remove invalid xml characters from string text
        /// </summary>
        /// <param name="value">expects string value</param>
        /// <returns>returns filtered text</returns>
        public static string RemoveXmlChars(this string text) => Encoding.UTF8.GetString(Encoding.Default.GetBytes(new string(value: text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray())));
        /// <summary>
        /// generate the random text hash
        /// </summary>
        /// <param name="value">expects length (object)</param>
        /// <returns>returns random hash text</returns>
        public static string RandomText(this object length) => new string(Enumerable.Repeat(Constant.Chars, (int)length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        /// <summary>
        /// generate the random int number
        /// </summary>
        /// <param name="value">expects length (object)</param>
        /// <returns>returns random int value</returns>
        public static int RandomNumber(this object length) => ConvertToInteger(Enumerable.Repeat(Constant.Numbers, (int)length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        /// <summary>
        /// Get Description attribute value of an enum
        /// </summary>
        /// <param name="e">expects enum</param>
        /// <returns>string value</returns>
        public static string GetValue(this object e)
        {
            var attribute = e.GetType().GetTypeInfo().GetMember(e.ToString()).FirstOrDefault(member => member.MemberType == MemberTypes.Field).GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? e.ToString();
        }
    }
}