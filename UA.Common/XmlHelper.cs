//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UAOOI.OPCUA.Common.Properties;

namespace UAOOI.OPCUA.Common
{
    /// <summary>
    /// <see cref="XmlHelper"/> provides
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Gets the XML serializer namespaces, which contains the XML namespaces and prefixes
        /// that the <see cref="XmlSerializer"/> uses to generate qualified
        /// names in an XML-document instance.
        /// </summary>
        /// <returns>XML namespaces and prefixes that the <see cref="XmlSerializer"/>
        /// uses to generate qualified names in an XML-document instance.</returns>
        public static XmlSerializerNamespaces GetXmlSerializerNamespaces()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(Settings.Default.XmlSDKConfigurationPrefix, Settings.Default.XmlSDKConfigurationNamespace);
            ns.Add(Settings.Default.XmlUATypesPrefix, Settings.Default.XmlUATypesNamespace);
            ns.Add(Settings.Default.XmlSchemainstancePrefix, Settings.Default.XmlSchemainstanceNamespace);
            ns.Add(Settings.Default.XmlSdkComPrefix, Settings.Default.XmlSdkComNamespace);
            return ns;
        }

        /// <summary>
        /// Gets the extension object.
        /// </summary>
        /// <param name="xmlElement">The XML element.</param>
        /// <returns></returns>
        public static type GetObject<type>(XmlElement xmlElement)
        {
            using (MemoryStream _memoryBuffer = new MemoryStream(1000))
            {
                XmlWriterSettings _settings = new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment };
                using (XmlWriter wrt = XmlWriter.Create(_memoryBuffer, _settings))
                    xmlElement.WriteTo(wrt);
                _memoryBuffer.Flush();
                _memoryBuffer.Position = 0;
                type m_Value;
                XmlSerializer _serializer = new XmlSerializer(typeof(type));
                using (XmlReader _reader = XmlReader.Create(_memoryBuffer))
                    m_Value = (type)_serializer.Deserialize(_reader);
                return m_Value;
            }
        }
    }
}