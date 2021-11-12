//__________________________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GitHub: https://github.com/mpostol/OPC-UA-OOI/discussions
//__________________________________________________________________________________________________

namespace UAOOI.OPCUA.Common
{
    /// <summary>
    /// Helper class that provides information about base directory.
    /// </summary>
    public class BaseDirectoryHelper
    {
        #region singleton

        static BaseDirectoryHelper()
        {
            BaseDirectoryHelper.Instance = new BaseDirectoryHelper();
        }

        /// <summary>
        /// Gets or sets the instance of BaseDirectoryHelper singleton.
        /// </summary>
        /// <value>The instance.</value>
        public static BaseDirectoryHelper Instance { get; private set; }

        #endregion singleton

        /// <summary>
        /// Gets the base directory. If the default <see cref="IBaseDirectoryProvider"/> is used <see cref="string.Empty"/> is used.
        /// </summary>
        /// <returns>string with base directory</returns>
        public string GetBaseDirectory()
        {
            if (myProvider != null)
                return myProvider.GetBaseDirectory();
            return string.Empty;
        }

        /// <summary>
        /// Sets the base directory provider <see cref="IBaseDirectoryProvider"/>.
        /// </summary>
        /// <param name="provider">The provider of teh base directory <see cref="IBaseDirectoryProvider"/>.</param>
        public void SetBaseDirectoryProvider(IBaseDirectoryProvider provider)
        {
            myProvider = provider;
        }

        //private
        private IBaseDirectoryProvider myProvider = null;
    }
}