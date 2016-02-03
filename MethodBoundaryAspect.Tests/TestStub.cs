using System;
using System.Threading.Tasks;
using MethodBoundaryAspect.Core;

namespace MethodBoundaryAspect.Tests
{
    public class TestStub
    {
        public static string StringResult => "success";
        public static int DelayInterval => 100;

        [ExceptionAttribute(TranslationKey = "fun")]
        public void Method()
        {
            throw new NullReferenceException();
        }

        //[ExceptionAttribute(ExceptionType = typeof(NullReferenceException), TranslationKey = "EN_WHATEVER")]
        public async Task AsyncMethod()
        {
            await Delay();
            throw new NullReferenceException();
        }

        //[ExceptionAttribute(ExceptionType = typeof(NullReferenceException), TranslationKey = "EN_WHATEVER")]
        public async Task<string> AsyncMethodWithReturn()
        {
            await Delay();
            return StringResult;
        }

        public Task Delay()
        {
            return Task.Delay(DelayInterval);
        }
    }
}