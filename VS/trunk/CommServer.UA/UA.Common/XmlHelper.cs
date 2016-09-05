//<summary>
//  Title   : XmlHelper
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.CommServer.UA.Common.Properties;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.CommServer.UA.Common
{
  /// <summary>
  /// <see cref="XmlHelper"/> provides 
  /// </summary>
  public static class XmlHelper
  {

    /// <summary>
    /// Gets the XML serializer namespaces, which contains the XML namespaces and prefixes 
    /// that the <see cref="System.Xml.Serialization.XmlSerializer"/> uses to generate qualified 
    /// names in an XML-document instance.
    /// </summary>
    /// <returns>XML namespaces and prefixes that the <see cref="System.Xml.Serialization.XmlSerializer"/> 
    /// uses to generate qualified names in an XML-document instance.</returns>
    public static XmlSerializerNamespaces GetXmlSerializerNamespaces()
    {
      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
      ns.Add( Settings.Default.XmlSDKConfigurationPrefix, Settings.Default.XmlSDKConfigurationNamespace );
      ns.Add( Settings.Default.XmlUATypesPrefix, Settings.Default.XmlUATypesNamespace );
      ns.Add( Settings.Default.XmlSchemainstancePrefix, Settings.Default.XmlSchemainstanceNamespace );
      ns.Add( Settings.Default.XmlSdkComPrefix, Settings.Default.XmlSdkComNamespace );
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
