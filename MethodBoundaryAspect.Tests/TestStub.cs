using System;
using System.Threading.Tasks;
using MethodBoundaryAspect.Core;

namespace MethodBoundaryAspect.Tests
{
    public class TestStub
    {
        public static string StringResult => "success";
        public static int DelayInterval => 100;

        [ExceptionAttribute(ExceptionType = typeof(NullReferenceException), TranslationKey = "EN_WHATEVER")]
        public void Method()
        {
            throw new NullReferenceException();
        }

        [ExceptionAttribute(ExceptionType = typeof(NullReferenceException), TranslationKey = "EN_WHATEVER")]
        public async Task AsyncMethod()
        {
            await Delay();
            throw new NullReferenceException();
        }       

        public Task Delay()
        {
            return Task.Delay(DelayInterval);
        }
    }
}