//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml;
using UAOOI.OPCUA.Common.OpcDa;

namespace UAOOI.OPCUA.Common.Types
{
    [TestClass()]
    public class RangeTests
    {
        [TestMethod()]
        public void CreateRangeTest()
        {
            ItemProperty _valueHigh = new TestItemProperty();
            ItemProperty _valueLow = new TestItemProperty();
            Range _newOne = Range.CreateRange(_valueHigh, _valueLow);
            Assert.AreEqual<double>((double)_valueHigh.Value, _newOne.High);
        }

        [TestMethod()]
        public void XmlElementTest()
        {
            ItemProperty _highValue = new TestItemProperty();
            ItemProperty _lowValue = new TestItemProperty();
            Range _newOne = Range.CreateRange(_highValue, _lowValue);
            XmlElement _xml = _newOne.XmlElement;
            Assert.AreEqual<int>(3, _xml.Attributes.Count);
            Assert.IsTrue(String.IsNullOrEmpty(_xml.BaseURI));
            Assert.AreEqual<int>(2, _xml.ChildNodes.Count);
            Assert.AreEqual<string>("ExtensionObject", _xml.LocalName);
            Assert.AreEqual<string>("ExtensionObject", _xml.Name);
            Assert.AreEqual<string>(@"http://opcfoundation.org/UA/2008/02/Types.xsd", _xml.NamespaceURI);
            Assert.AreEqual<XmlNodeType>(XmlNodeType.Element, _xml.NodeType);
            Assert.AreEqual<string>(null, _xml.Value);
            //Type
            XmlNode _Type = _xml.FirstChild;
            Assert.AreEqual<String>("TypeId", _Type.Name);
            Assert.AreEqual<XmlNodeType>(XmlNodeType.Element, _Type.NodeType);
            Assert.AreEqual<string>(Opc.Ua.ObjectIds.Range_Encoding_DefaultXml.Format(), _Type.InnerText);
            //Body
            XmlNode _body = _Type.NextSibling;
            Assert.AreEqual<String>("Body", _body.Name);
            Assert.AreEqual<XmlNodeType>(XmlNodeType.Element, _Type.NodeType);
            Assert.IsTrue(_body.InnerXml.Contains("Range"));
            //Range
            XmlNode _range = _body.FirstChild;
            Assert.AreEqual<String>("Range", _range.Name);
            Assert.AreEqual<XmlNodeType>(XmlNodeType.Element, _Type.NodeType);
            //Low
            XmlNode _low = _range.FirstChild;
            Assert.AreEqual<String>("Low", _low.Name);
            Assert.AreEqual<XmlNodeType>(XmlNodeType.Element, _Type.NodeType);
            double _recoveredLowValue = XmlConvert.ToDouble(_low.InnerText);
            Assert.AreEqual<double>((double)_lowValue.Value, _recoveredLowValue);
            //High
            XmlNode _high = _low.NextSibling;
            Assert.AreEqual<String>("High", _high.Name);
            Assert.AreEqual<XmlNodeType>(XmlNodeType.Element, _Type.NodeType);
            double _recoveredHighValue = XmlConvert.ToDouble(_high.InnerText);
            Assert.AreEqual<double>((double)_highValue.Value, _recoveredHighValue);
        }

        [TestMethod]
        public void DeserializationTestMethod()
        {
            ItemProperty _highValue = new TestItemProperty();
            ItemProperty _lowValue = new TestItemProperty();
            Range _newOne = Range.CreateRange(_highValue, _lowValue);
            XmlElement _xmlExtensionObject = _newOne.XmlElement;
            ExtensionObject _extensionObject = ExtensionObject.GetExtensionObject(_xmlExtensionObject);
            Assert.AreEqual<string>(Opc.Ua.ObjectIds.Range_Encoding_DefaultXml.Format(), _extensionObject.TypeId.Identifier);
            Range _recoveredRange = Range.CreateRange(_extensionObject.Body);
            Assert.AreEqual<double>((double)_lowValue.Value, _recoveredRange.Low);
            Assert.AreEqual<double>((double)_highValue.Value, _recoveredRange.High);
        }

        //Private test instrumentations
        private class TestItemProperty : ItemProperty
        {
            public TestItemProperty()
            {
                this.DataType = typeof(long);
                this.Description = "Descriptionh";
                this.DiagnosticInfo = String.Empty;
                this.ID = new PropertyID(100);
                this.ItemName = nameof(ItemName);
                this.ItemPath = nameof(ItemPath);
                this.ResultID = ResultID.S_OK;
                this.Value = m_Random.NextDouble();
            }

            private static Random m_Random = new Random();
        }
    }
}