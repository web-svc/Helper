namespace Helper.Interface
{
    using System.Collections.Generic;
    public interface IUrlService
    {
        string UrlEncode(string value);
        string QueryBuilder(IList<IParameters> parameters);
        List<IParameters> ParseQueryString(string query);
    }
}
