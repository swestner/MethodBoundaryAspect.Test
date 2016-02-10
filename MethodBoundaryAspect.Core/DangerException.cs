using System;

namespace MethodBoundaryAspect.Core
{
    public class DangerException : Exception
    {
        public DangerException(string message, Exception ex): base (message, ex)
        {
        }
    }
}