using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MethodBoundaryAspect.Core;
using System.Threading.Tasks;

namespace MethodBoundaryAspect.Tests
{
  [TestClass]
  public class Exception_Test
  {
    static TestStub _sut;


    [ClassInitialize]
    public static void Setup(TestContext context)
    {
      _sut = new TestStub();
    }

    [TestMethod]                 
    [ExpectedException(exceptionType:typeof(DangerException))]
    public void Test_Sync_Void()
    { 
      _sut.Method();    
    }

    [TestMethod]
    [ExpectedException(exceptionType: typeof(DangerException))]
    public async Task Test_Async_Task()
    {     
      await _sut.AsyncMethod();      
    }
  }
}
