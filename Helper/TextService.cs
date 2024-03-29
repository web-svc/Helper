﻿namespace Helper
{
    using Helper.Interface;
    using System;
    public class TextService : ITextService
    {
        public string ConvertToNumbers(string value)
        {
            throw new NotImplementedException();
        }

        public string ConvertToWords(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a random number string
        /// </summary>
        /// <returns>random string numeric value</returns>
        public string GenerateNonce()
        {
            return new Random().Next(123400, 9999999).ToString();
        }

        public string GenerateTimeStamp()
        {
            return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        }
    }
}
