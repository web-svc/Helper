namespace Helper
{
    using Helper.Constant;
    using Helper.Extentsion;
    using Helper.Interface;
    using Helper.Model;
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

        /// <summary>
        /// Url Builder create query path for Uri.
        /// </summary>
        /// <param name="parameters">Paramaters:Name and Value</param>
        /// <returns>string query path</returns>
        public string QueryBuilder(IList<IParameters> parameters)
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

        /// <summary>
        /// Parse a query string into IParameter: Name and Value
        /// </summary>
        /// <param name="query">Url Query path</param>
        /// <returns>List of Parameters: Name and Value</returns>
        public List<IParameters> ParseQueryString(string query)
        {
            var ParameterList = new List<IParameters>();
            if (string.IsNullOrEmpty(query)) return ParameterList;
            query = query.StartsWith("?") ? query.Remove(0, 1) : query;
            var chArray = new[] { '&' };
            foreach (var name in query.Split(chArray))
            {
                if (name.IsEmpty() || name.StartsWith("oauth_")) continue;
                if (name.IndexOf('=') > -1)
                {
                    var strArray = name.Split('=');
                    ParameterList.Add(new Parameters() { Name = strArray[0], Value = strArray[1] });
                }
                else
                    ParameterList.Add(new Parameters() { Name = name, Value = string.Empty });
            }
            return ParameterList;
        }
    }
}
