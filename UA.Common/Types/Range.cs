//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using Opc.Da;
using Opc.Ua;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace UAOOI.OPCUA.Common.Types
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
            using (MemoryStream stream = new MemoryStream(1000))
            {
                XmlWriterSettings settings = new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment };
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                    xmlElement.WriteTo(writer);
                stream.Flush();
                stream.Position = 0;
                using (XmlReader reader = XmlReader.Create(stream))
                    return (Range)m_XmlSerializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Gets the <see cref="ExtensionObject"/> represented as the  <see cref="XmlElement"/> encapsulating the current value.
        /// </summary>
        /// <value>The <see cref="XmlElement"/> encapsulating current value as the <see cref="ExtensionObject"/>.</value>
        public XmlElement XmlElement
        {
            get
            {
                XmlDocument _xmlDocument = new XmlDocument();
                using (MemoryStream _buffer = new MemoryStream(1000))
                {
                    m_XmlSerializer.Serialize(_buffer, this);
                    _buffer.Flush();
                    _buffer.Position = 0;
                    _xmlDocument.Load(_buffer);
                }
                return ExtensionObject.GetXmlElement(ObjectIds.Range_Encoding_DefaultXml, _xmlDocument.DocumentElement);
            }
        }

        /// <summary>
        /// Creates the range.
        /// </summary>
        /// <param name="highEu">The high engineering unit.</param>
        /// <param name="lowEu">The low engineering unit.</param>
        /// <returns></returns>
        public static Range CreateRange(ItemProperty highEu, ItemProperty lowEu)
        {
            Range rng = new Range()
            {
                High = Convert.ToDouble(highEu.Value),
                Low = Convert.ToDouble(lowEu.Value)
            };
            return rng;
        }

        private static XmlSerializer m_XmlSerializer = new XmlSerializer(typeof(Range));
    }
}