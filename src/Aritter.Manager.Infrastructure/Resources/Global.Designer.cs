﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aritter.Manager.Infrastructure.Resources {
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
    public class Global {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Global() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Aritter.Manager.Infrastructure.Resources.Global", typeof(Global).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirme a senha.
        /// </summary>
        public static string ChangePasswordViewModel_ConfirmNewPassword {
            get {
                return ResourceManager.GetString("ChangePasswordViewModel_ConfirmNewPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha atual.
        /// </summary>
        public static string ChangePasswordViewModel_CurrentPassword {
            get {
                return ResourceManager.GetString("ChangePasswordViewModel_CurrentPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nova senha.
        /// </summary>
        public static string ChangePasswordViewModel_NewPassword {
            get {
                return ResourceManager.GetString("ChangePasswordViewModel_NewPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email.
        /// </summary>
        public static string ForgotPasswordViewModel_MailAddress {
            get {
                return ResourceManager.GetString("ForgotPasswordViewModel_MailAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha.
        /// </summary>
        public static string LoginViewModel_Password_Senha {
            get {
                return ResourceManager.GetString("LoginViewModel_Password_Senha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Continuar conectado.
        /// </summary>
        public static string LoginViewModel_RememberMe_Continuar_conectado {
            get {
                return ResourceManager.GetString("LoginViewModel_RememberMe_Continuar_conectado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário.
        /// </summary>
        public static string LoginViewModel_Username {
            get {
                return ResourceManager.GetString("LoginViewModel_Username", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário ou senha inválidos..
        /// </summary>
        public static string Message_InvalidUserPassword {
            get {
                return ResourceManager.GetString("Message_InvalidUserPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A senha não corresponde aos requisitos mínimos exigidos.
        /// </summary>
        public static string Message_PasswordPolicyNotMatch {
            get {
                return ResourceManager.GetString("Message_PasswordPolicyNotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O usuário está bloqueado. Contate o administrador do sistema..
        /// </summary>
        public static string Message_UserLocked {
            get {
                return ResourceManager.GetString("Message_UserLocked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário não encontrado..
        /// </summary>
        public static string Message_UserNotFound {
            get {
                return ResourceManager.GetString("Message_UserNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha expirada. Você deve alterar sua senha..
        /// </summary>
        public static string Message_UserPasswordExpired {
            get {
                return ResourceManager.GetString("Message_UserPasswordExpired", resourceCulture);
            }
        }
    }
}
