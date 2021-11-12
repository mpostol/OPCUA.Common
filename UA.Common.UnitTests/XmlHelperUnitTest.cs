//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace UAOOI.OPCUA.Common
{
    [TestClass]
    public class XmlHelperUnitTest
    {
        [TestMethod]
        [TestCategory("CAS.UA.Common")]
        public void GetXmlSerializerNamespacesTest()
        {
            XmlSerializerNamespaces _newNamespaces = XmlHelper.GetXmlSerializerNamespaces();
            Assert.AreEqual<int>(4, _newNamespaces.Count);
            Dictionary<string, XmlQualifiedName> _dic = _newNamespaces.ToArray().ToDictionary(x => x.Name);
            Assert.AreEqual<string>(@"http://opcfoundation.org/UA/2008/02/Types.xsd", _dic["ua"].Namespace);
        }
    }
}