//<summary>
//  Title   : XML helper for ExtensionObject
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

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.UA.Common.Types
{
  /// <summary>
  /// XML helper for <see cref="ExtensionObject"/> 
  /// </summary>
  public partial class ExtensionObject
  {
    /// <summary>
    /// Gets the XML element.
    /// </summary>
    /// <param name="identifier">The identifier.</param>
    /// <param name="body">The body.</param>
    /// <returns></returns>
    public static XmlElement GetXmlElement(Opc.Ua.NodeId identifier, XmlElement body)
    {
      ExtensionObject me = new ExtensionObject() { TypeId = new ExpandedNodeId() { Identifier = identifier.Format() } };
      me.Body = body;
      XmlDocument xmldoc = new XmlDocument();
      using ( MemoryStream buffer = new MemoryStream( 1000 ) )
      {
        m_Serializer.Serialize( buffer, me );
        buffer.Flush();
        buffer.Position = 0;
        xmldoc.Load( buffer );
      }
      return xmldoc.DocumentElement;
    }
    /// <summary>
    /// Gets the extension object.
    /// </summary>
    /// <param name="xmlElement">The XML element.</param>
    /// <returns></returns>
    public static ExtensionObject GetExtensionObject(XmlElement xmlElement)
    {
      using ( MemoryStream buffer = new MemoryStream( 1000 ) )
      {
        XmlWriterSettings stngs = new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment };
        using ( XmlWriter wrt = XmlWriter.Create( buffer, stngs ) )
          xmlElement.WriteTo( wrt );
        buffer.Flush();
        buffer.Position = 0;
        ExtensionObject m_Value;
        using ( XmlReader rdr = XmlReader.Create( buffer ) )
          m_Value = (ExtensionObject)m_Serializer.Deserialize( rdr );
        return m_Value;
      }
    }
    /// <summary>
    /// The local name
    /// </summary>
    public static readonly string LocalName = typeof(ExtensionObject).Name;
    private readonly static XmlSerializer m_Serializer = new XmlSerializer( typeof( ExtensionObject ) );
  }
}
