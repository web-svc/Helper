namespace Helper.Interface
{
    using System.Collections.Generic;
    public interface IUrlService
    {
        string UrlEncode(string value);
        string UrlBuilder(IList<IParameters> parameters);
    }
}
