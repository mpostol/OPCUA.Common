//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

namespace UAOOI.OPCUA.Common
{
    /// <summary>
    /// Interface used to provide path to base directory used as a root of the configuration files.
    /// </summary>
    public interface IBaseDirectoryProvider
    {
        /// <summary>
        /// Gets the base directory.
        /// </summary>
        /// <returns>string with base directory</returns>
        string GetBaseDirectory();
    }
}