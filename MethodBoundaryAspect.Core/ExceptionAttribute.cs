using MethodBoundaryAspect.Fody.Attributes;
using System;
using System.Runtime.ExceptionServices;

namespace MethodBoundaryAspect.Core
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExceptionAttribute : OnMethodBoundaryAspect
    {
        public Type ExceptionType { get; set; }
        public string TranslationKey { get; set; }

        public ExceptionAttribute()
        {

        }
        public ExceptionAttribute(Type exceptionType, string translationKey)
        {
            TranslationKey = translationKey;
            ExceptionType = exceptionType;
        }

      
        public override void OnException(MethodExecutionArgs args)
        {
            var exception = args.Exception;

            if (exception.GetType() != ExceptionType)
            {
                ExceptionDispatchInfo.Capture(exception).Throw();
            }

            throw new DangerException(TranslationKey, exception);

        }
    }
}