//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace UAOOI.OPCUA.Common.Types
{
    /// <summary>
    /// XML helper for <see cref="ExtensionObject"/>
    /// </summary>
    public partial class ExtensionObject
    {
        /// <summary>
        /// Gets the XML element encapsulating the <see cref="ExtensionObject"/> containing inner value represented by the <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="body">The body encapsulating target value.</param>
        /// <returns></returns>
        public static XmlElement GetXmlElement(Opc.Ua.NodeId identifier, XmlElement body)
        {
            ExtensionObject _newExtensionObject = new ExtensionObject() { TypeId = new ExpandedNodeId() { Identifier = identifier.Format() } };
            _newExtensionObject.Body = body;
            XmlDocument _xmlDocument = new XmlDocument();
            using (MemoryStream _buffer = new MemoryStream(1000))
            {
                m_Serializer.Serialize(_buffer, _newExtensionObject);
                _buffer.Flush();
                _buffer.Position = 0;
                _xmlDocument.Load(_buffer);
            }
            return _xmlDocument.DocumentElement;
        }

        /// <summary>
        /// Gets the extension object encapsulated by the <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="xmlElement">The <see cref="XmlElement"/> instance encapsulating <see cref="ExtensionObject"/> as the xml format.</param>
        /// <returns></returns>
        public static ExtensionObject GetExtensionObject(XmlElement xmlElement)
        {
            using (MemoryStream _buffer = new MemoryStream(1000))
            {
                XmlWriterSettings _settings = new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment };
                using (XmlWriter _xmlWriter = XmlWriter.Create(_buffer, _settings))
                    xmlElement.WriteTo(_xmlWriter);
                _buffer.Flush();
                _buffer.Position = 0;
                ExtensionObject _returnValue;
                using (XmlReader _xmlReader = XmlReader.Create(_buffer))
                    _returnValue = (ExtensionObject)m_Serializer.Deserialize(_xmlReader);
                return _returnValue;
            }
        }

        /// <summary>
        /// The local name
        /// </summary>
        public static readonly string LocalName = typeof(ExtensionObject).Name;

        private static readonly XmlSerializer m_Serializer = new XmlSerializer(typeof(ExtensionObject));
    }
}