﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.DomainModels.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Store.DomainModels.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to خطا در لایه دسترسی به داده ها.
        /// </summary>
        internal static string DataAccessException {
            get {
                return ResourceManager.GetString("DataAccessException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to خطا در آماده سازی دیتابیس.
        /// </summary>
        internal static string InitializeDataBaseException {
            get {
                return ResourceManager.GetString("InitializeDataBaseException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام محصول تکراری می باشد.
        /// </summary>
        internal static string ProductNameDuplicateException {
            get {
                return ResourceManager.GetString("ProductNameDuplicateException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to محصول مورد نظر یافت نشد.
        /// </summary>
        internal static string ProductNotFoundException {
            get {
                return ResourceManager.GetString("ProductNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام آپشن محصول تکراری می باشد.
        /// </summary>
        internal static string ProductOptionNameDuplicateException {
            get {
                return ResourceManager.GetString("ProductOptionNameDuplicateException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to آپشن محصول مورد نظر یافت نشد.
        /// </summary>
        internal static string ProductOptionNotFoundException {
            get {
                return ResourceManager.GetString("ProductOptionNotFoundException", resourceCulture);
            }
        }
    }
}
