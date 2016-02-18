//<summary>
//  Title   : Enum that is used to enumerate all node classes
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20090126: mzbrzezny: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

namespace CAS.UA.IServerConfiguration
{
  /// <summary>
  /// Enumeration of the node classes that can be a source of process data.
  /// </summary>
  public enum InstanceNodeClassesEnum
  {
    /// <summary>
    /// Object NodeClasses
    /// </summary>
    Object,
    /// <summary>
    /// Variable NodeClasses
    /// </summary>
    Variable,
    /// <summary>
    /// Method NodeClasses
    /// </summary>
    Method,
    /// <summary>
    /// View NodeClasses
    /// </summary>
    View,
    /// <summary>
    /// Not defined or nor relevant
    /// </summary>
    NotDefined
  }
}