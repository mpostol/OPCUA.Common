//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

using System;
using System.Xml.Serialization;

namespace UAOOI.OPCUA.Common.OpcDa
{
    /// <summary>
    /// Contains a description of a single item property.
    /// </summary>
    [Serializable]
    public class ItemProperty : ICloneable, IResult
    {
        /// <summary>
        /// The property identifier.
        /// </summary>
        public PropertyID ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// A short description of the property.
        /// </summary>
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        /// <summary>
        /// The data type of the property.
        /// </summary>
        [XmlIgnore]
        public System.Type DataType
        {
            get { return m_datatype; }
            set { m_datatype = value; }
        }

        /// <summary>
        /// The value of the property.
        /// </summary>
        public object Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        /// <summary>
        /// The primary identifier for the property if it is directly accessible as an item.
        /// </summary>
        public string ItemName
        {
            get { return m_itemName; }
            set { m_itemName = value; }
        }

        /// <summary>
        /// The secondary identifier for the property if it is directly accessible as an item.
        /// </summary>
        public string ItemPath
        {
            get { return m_itemPath; }
            set { m_itemPath = value; }
        }

        #region IResult Members

        /// <summary>
        /// The error id for the result of an operation on an property.
        /// </summary>
        public ResultID ResultID
        {
            get { return m_resultID; }
            set { m_resultID = value; }
        }

        /// <summary>
        /// Vendor specific diagnostic information (not the localized error text).
        /// </summary>
        public string DiagnosticInfo
        {
            get { return m_diagnosticInfo; }
            set { m_diagnosticInfo = value; }
        }

        #endregion IResult Members

        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        public virtual object Clone()
        {
            ItemProperty clone = (ItemProperty)MemberwiseClone();
            clone.Value = Convert.Clone(Value);
            return clone;
        }

        #endregion ICloneable Members

        #region Private Members

        private PropertyID m_id;
        private string m_description = null;
        private System.Type m_datatype = null;
        private object m_value = null;
        private string m_itemName = null;
        private string m_itemPath = null;
        private ResultID m_resultID = ResultID.S_OK;
        private string m_diagnosticInfo = null;

        #endregion Private Members
    }
}