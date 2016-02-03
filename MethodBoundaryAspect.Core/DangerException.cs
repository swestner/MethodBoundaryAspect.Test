using System;

namespace MethodBoundaryAspect.Core
{
    class DangerException : Exception
    {
        public DangerException(string message, Exception ex): base (message, ex)
        {
        }
    }
}