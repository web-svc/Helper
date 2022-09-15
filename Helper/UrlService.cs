namespace Helper
{
    using Helper.Constant;
    using Helper.Interface;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class UrlService : IUrlService
    {
        /// <summary>
        /// Encode string value
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>string</returns>
        public string UrlEncode(string value)
        {
            var stringBuilder = new StringBuilder();
            foreach (var ch in value)
            {
                if (Const.UnreservedChars.IndexOf(ch) != -1)
                    stringBuilder.Append(ch);
                else
                    stringBuilder.Append('%' + $"{(int)ch:X2}");
            }
            return stringBuilder.ToString();
        }

        public string UrlBuilder(IList<IParameters> parameters)
        {
            var stringBuilder = new StringBuilder();
            foreach (var parameter  in parameters)
            {
                stringBuilder.AppendFormat("{0}={1}", parameter.Name, parameter.Value);
                if (parameters.LastOrDefault() != parameter)
                    stringBuilder.Append("&");
            }
            return stringBuilder.ToString();
        }
    }
}
