﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bulanik_Mantik_Odev {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.13.0.0")]
    internal sealed partial class Giris : global::System.Configuration.ApplicationSettingsBase {
        
        private static Giris defaultInstance = ((Giris)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Giris())));
        
        public static Giris Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double hassaslık {
            get {
                return ((double)(this["hassaslık"]));
            }
            set {
                this["hassaslık"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double kirlilik {
            get {
                return ((double)(this["kirlilik"]));
            }
            set {
                this["kirlilik"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double miktar {
            get {
                return ((double)(this["miktar"]));
            }
            set {
                this["miktar"] = value;
            }
        }
    }
}
