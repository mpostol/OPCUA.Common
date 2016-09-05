
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CAS.CommServer.UA.Common.UnitTest
{
  [TestClass]
  public class BaseDirectoryHelperUnitTest
  {

    [TestMethod]
    [TestCategory("CAS.CommServer.UA.Common")]
    public void BaseDirectoryHelperTestMethod()
    {
      BaseDirectoryHelper _bd = BaseDirectoryHelper.Instance;
      Assert.IsNotNull(_bd);
      Assert.IsTrue(String.IsNullOrEmpty(_bd.GetBaseDirectory()));
      _bd.SetBaseDirectoryProvider(new BaseDirectoryProvider());
      Assert.AreEqual<string>("BaseDirectoryProvider", _bd.GetBaseDirectory());
      _bd.SetBaseDirectoryProvider(null);
    }
    [TestMethod]
    [TestCategory("CAS.CommServer.UA.Common")]
    public void SetBaseDirectoryProviderNullTestMethod()
    {
      BaseDirectoryHelper _bd = BaseDirectoryHelper.Instance;
      _bd.SetBaseDirectoryProvider(new BaseDirectoryProvider());
      Assert.AreEqual<string>("BaseDirectoryProvider", _bd.GetBaseDirectory());
      _bd.SetBaseDirectoryProvider(null);
      Assert.IsTrue(String.IsNullOrEmpty(_bd.GetBaseDirectory()));
    }
    //private definitions.
    private class BaseDirectoryProvider : IBaseDirectoryProvider
    {
      public string GetBaseDirectory()
      {
        return typeof(BaseDirectoryProvider).Name;
      }
    }
  }
}
