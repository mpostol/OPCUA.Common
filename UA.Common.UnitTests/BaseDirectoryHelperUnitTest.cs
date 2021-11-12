//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UAOOI.OPCUA.Common
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