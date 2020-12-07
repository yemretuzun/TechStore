using System;

namespace TechStoreAPI.Exceptions
{
    /// <summary>
    /// Aynı mail ile kullanıcı kayıtlıysa throw
    /// </summary>
    public class UserExistException : Exception
    {
        public UserExistException() : base("Bu email ile zaten bir kullanıcı kayıtlı!")
        {
        }
    }
}
