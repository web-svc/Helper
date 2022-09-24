namespace Helper.Interface
{
    public interface ITextService
    {
        string ConvertToWords(int value);
        string ConvertToNumbers(string value);
        string GenerateNonce();
        string GenerateTimeStamp();
    }
}
