using System;

namespace Task1
{
    public static class Guard
    {
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if(argumentValue is null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
