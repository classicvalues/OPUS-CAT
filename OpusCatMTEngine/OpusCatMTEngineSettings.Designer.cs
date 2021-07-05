﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpusCatMTEngine {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class OpusCatMTEngineSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static OpusCatMTEngineSettings defaultInstance = ((OpusCatMTEngineSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new OpusCatMTEngineSettings())));
        
        public static OpusCatMTEngineSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://object.pouta.csc.fi/OPUS-MT-models/")]
        public string OpusModelStorageUrl {
            get {
                return ((string)(this["OpusModelStorageUrl"]));
            }
            set {
                this["OpusModelStorageUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("opuscat/")]
        public string LocalOpusCatDir {
            get {
                return ((string)(this["LocalOpusCatDir"]));
            }
            set {
                this["LocalOpusCatDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8477")]
        public string MtServicePort {
            get {
                return ((string)(this["MtServicePort"]));
            }
            set {
                this["MtServicePort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("customize.yml")]
        public string CustomizationBaseConfig {
            get {
                return ((string)(this["CustomizationBaseConfig"]));
            }
            set {
                this["CustomizationBaseConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("translations.sqlite")]
        public string TranslationDBName {
            get {
                return ((string)(this["TranslationDBName"]));
            }
            set {
                this["TranslationDBName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("logs")]
        public string LogDir {
            get {
                return ((string)(this["LogDir"]));
            }
            set {
                this["LogDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Marian")]
        public string MarianDir {
            get {
                return ((string)(this["MarianDir"]));
            }
            set {
                this["MarianDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Preprocessing")]
        public string PreprocessingDir {
            get {
                return ((string)(this["PreprocessingDir"]));
            }
            set {
                this["PreprocessingDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public int ModelTagMaxLength {
            get {
                return ((int)(this["ModelTagMaxLength"]));
            }
            set {
                this["ModelTagMaxLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool StartWcfHttpService {
            get {
                return ((bool)(this["StartWcfHttpService"]));
            }
            set {
                this["StartWcfHttpService"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TatoebaTestsets")]
        public string TatoebaDir {
            get {
                return ((string)(this["TatoebaDir"]));
            }
            set {
                this["TatoebaDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int OODValidSetSize {
            get {
                return ((int)(this["OODValidSetSize"]));
            }
            set {
                this["OODValidSetSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("train.log")]
        public string TrainLogName {
            get {
                return ((string)(this["TrainLogName"]));
            }
            set {
                this["TrainLogName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int IDValidSetSize {
            get {
                return ((int)(this["IDValidSetSize"]));
            }
            set {
                this["IDValidSetSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("postfinetune.txt")]
        public string PostFinetuneBatchName {
            get {
                return ((string)(this["PostFinetuneBatchName"]));
            }
            set {
                this["PostFinetuneBatchName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("custom_model_packages")]
        public string CustomModelZipPath {
            get {
                return ((string)(this["CustomModelZipPath"]));
            }
            set {
                this["CustomModelZipPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8500")]
        public string HttpMtServicePort {
            get {
                return ((string)(this["HttpMtServicePort"]));
            }
            set {
                this["HttpMtServicePort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool StoreOpusCatDataInLocalAppdata {
            get {
                return ((bool)(this["StoreOpusCatDataInLocalAppdata"]));
            }
            set {
                this["StoreOpusCatDataInLocalAppdata"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("models")]
        public string ModelDir {
            get {
                return ((string)(this["ModelDir"]));
            }
            set {
                this["ModelDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://object.pouta.csc.fi/Tatoeba-MT-models/")]
        public string TatoebaModelStorageUrl {
            get {
                return ((string)(this["TatoebaModelStorageUrl"]));
            }
            set {
                this["TatoebaModelStorageUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("14")]
        public int DatabaseRemovalInterval {
            get {
                return ((int)(this["DatabaseRemovalInterval"]));
            }
            set {
                this["DatabaseRemovalInterval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CacheMtInDatabase {
            get {
                return ((bool)(this["CacheMtInDatabase"]));
            }
            set {
                this["CacheMtInDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseDatabaseRemoval {
            get {
                return ((bool)(this["UseDatabaseRemoval"]));
            }
            set {
                this["UseDatabaseRemoval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AllowRemoteUse {
            get {
                return ((bool)(this["AllowRemoteUse"]));
            }
            set {
                this["AllowRemoteUse"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DisplayOverlay {
            get {
                return ((bool)(this["DisplayOverlay"]));
            }
            set {
                this["DisplayOverlay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int OverlayFontsize {
            get {
                return ((int)(this["OverlayFontsize"]));
            }
            set {
                this["OverlayFontsize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1000")]
        public int FinetuningSetMinSize {
            get {
                return ((int)(this["FinetuningSetMinSize"]));
            }
            set {
                this["FinetuningSetMinSize"] = value;
            }
        }
    }
}
