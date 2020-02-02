using System;

namespace Fluke_Test_Project.Repository
{
    public class EonetResponseException : Exception
    {
        public EonetResponseException(string message)
            : base(message)
        {
        }
    }
}
