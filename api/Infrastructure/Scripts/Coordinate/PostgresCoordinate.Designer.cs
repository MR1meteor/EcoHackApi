﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Scripts.Coordinate {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PostgresCoordinate {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PostgresCoordinate() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Scripts.Coordinate.PostgresCoordinate", typeof(PostgresCoordinate).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM coordinates
        ///WHERE id = @Id.
        /// </summary>
        internal static string Delete {
            get {
                return ResourceManager.GetString("Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM coordinates
        ///WHERE id = any(@Ids).
        /// </summary>
        internal static string DeleteByBookElement {
            get {
                return ResourceManager.GetString("DeleteByBookElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///    c.id          as &quot;Id&quot;,
        ///    c.element_id  as &quot;ElementId&quot;,
        ///    c.coordinates as &quot;Coordinates&quot;
        ///FROM coordinates c
        ///WHERE element_id = @ElementId.
        /// </summary>
        internal static string GetByBookElement {
            get {
                return ResourceManager.GetString("GetByBookElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///    c.id          as &quot;Id&quot;,
        ///    c.element_id  as &quot;ElementId&quot;,
        ///    c.coordinates as &quot;Coordinates&quot;
        ///FROM coordinates c
        ///WHERE c.id = @Id.
        /// </summary>
        internal static string GetById {
            get {
                return ResourceManager.GetString("GetById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO coordinates (element_id, coordinates)
        ///VALUES (@ElementId, @Coordinates)
        ///RETURNING
        ///    id          as &quot;Id&quot;,
        ///    element_id  as &quot;ElementId&quot;,
        ///    coordinates as &quot;Coordinates&quot;.
        /// </summary>
        internal static string Insert {
            get {
                return ResourceManager.GetString("Insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE coordinates c
        ///SET
        ///    c.element_id    = @ElementId,
        ///    c.coordinates   = @Coordinates
        ///WHERE c.id = @Id
        ///RETURNING
        ///    c.id            as &quot;Id&quot;,
        ///    c.element_id    as &quot;ElementId&quot;,
        ///    c.coordinates   as &quot;Coordinates&quot;.
        /// </summary>
        internal static string Update {
            get {
                return ResourceManager.GetString("Update", resourceCulture);
            }
        }
    }
}
