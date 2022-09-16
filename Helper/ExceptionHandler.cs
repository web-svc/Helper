namespace Helper
{
    using System;
    public static class ExceptionHandler
    {
        public static void ThrowIfNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }
        public static void ThrowIfNull(this object obj, string objName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), string.Format("{0} is null.", objName));
        }
        public static void ThrowIfNullOrEmpty(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }
        public static void ThrowIfNullOrEmpty(this string obj, string objName)
        {
            if (string.IsNullOrEmpty(obj))
                throw new ArgumentNullException(nameof(obj), string.Format("{0} is null.", objName));
        }
        public static void ThrowUnauthorizedAccess(string message)
        {
            throw new UnauthorizedAccessException(message);
        }
        public static void ThrowError(string message)
        {
            throw new Exception(message);
        }
    }
}
