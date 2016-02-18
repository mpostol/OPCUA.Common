//<summary>
//  Title   : Implements Range standard type
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

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.UA.Common.Types
{
  /// <summary>
  /// Implements Range standard type
  /// </summary>
  public partial class Range
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Range"/> class.
    /// </summary>
    /// <param name="xmlElement">The XML element containing the value.</param>
    /// <returns></returns>
    public static Range CreateRange(XmlElement xmlElement)
    {
      using ( MemoryStream stream = new MemoryStream( 1000 ) )
      {
        XmlWriterSettings settings = new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment };
        using ( XmlWriter writer = XmlWriter.Create( stream, settings ) )
          xmlElement.WriteTo( writer );
        stream.Flush();
        stream.Position = 0;
        using ( XmlReader reader = XmlReader.Create( stream ) )
          return (Range)m_XmlSerializer.Deserialize( reader );
      }
    }
    /// <summary>
    /// Gets the XML element representing the current value.
    /// </summary>
    /// <value>The XML element.</value>
    public XmlElement XmlElement
    {
      get
      {
        XmlDocument xmldoc = new XmlDocument();
        using ( MemoryStream buffer = new MemoryStream( 1000 ) )
        {
          m_XmlSerializer.Serialize( buffer, this );
          buffer.Flush();
          buffer.Position = 0;
          xmldoc.Load( buffer );
        }
        return ExtensionObject.GetXmlElement( Opc.Ua.ObjectIds.Range_Encoding_DefaultXml, xmldoc.DocumentElement );
      }
    }
    /// <summary>
    /// Creates the range.
    /// </summary>
    /// <param name="higheu">The high engineering unit.</param>
    /// <param name="loweu">The low engineering unit.</param>
    /// <returns></returns>
    public static Range CreateRange(Opc.Da.ItemProperty higheu, Opc.Da.ItemProperty loweu)
    {
      Range rng = new Range()
      {
        High = Convert.ToDouble( higheu.Value ),
        Low = Convert.ToDouble( loweu.Value )
      };
      return rng;
    }
    private static XmlSerializer m_XmlSerializer = new XmlSerializer( typeof( Range ) );
  }

}
