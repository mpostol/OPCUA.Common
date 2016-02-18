//<summary>
//  Title   : Provides access to the instance node configuration
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

namespace CAS.UA.IServerConfiguration
{
  /// <summary>
  /// Provides access to the instance node configuration editor
  /// </summary>
  public interface IInstanceConfiguration
  {
    /// <summary>
    /// Edits this instance.
    /// </summary>
    void Edit();
    /// <summary>
    /// Create new empty data bindings configuration for this instance node to store proprietary information of the UA server.
    /// </summary>
    void ClearConfiguration();
  }
}
