//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

namespace UAOOI.OPCUA.Common.OpcDa
{
    /// <summary>
    /// A interface used to access result information associated with a single item/value.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// The error id for the result of an operation on an item.
        /// </summary>
        ResultID ResultID { get; set; }

        /// <summary>
        /// Vendor specific diagnostic information (not the localized error text).
        /// </summary>
        string DiagnosticInfo { get; set; }
    }
}