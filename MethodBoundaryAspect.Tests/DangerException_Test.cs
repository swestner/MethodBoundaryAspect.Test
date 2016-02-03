using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MethodBoundaryAspect.Core;
using System.Threading.Tasks;

namespace MethodBoundaryAspect.Tests
{
  [TestClass]
  public class DangerException_Test
  {
    static TestStub _sut;


    [ClassInitialize]
    public static void Setup(TestContext context)
    {
      _sut = new TestStub();
    }

    [TestMethod]                 
    [ExpectedException(exceptionType:typeof(NullReferenceException))]
    public void Test_Sync_Void()
    { 
      _sut.Method();    
    }

    [TestMethod]
    [ExpectedException(exceptionType: typeof(NullReferenceException))]
    public async Task Test_Async_Task()
    {     
      await _sut.AsyncMethod();      
    }

    [TestMethod]
    public async Task Test_Async_Task_Value_Returned()
    {
      var result = await _sut.AsyncMethodWithReturn();
      Assert.AreEqual(result, TestStub.StringResult);
    }


  }
}
