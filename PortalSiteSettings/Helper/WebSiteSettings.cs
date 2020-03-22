using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using System.ComponentModel.DataAnnotations;

namespace Futurez.XrmToolBox
{
    public class WebSiteSettings // : INotifyPropertyChanged
    {
        internal Guid _websiteId = Guid.Empty;

        public WebSiteSettings(Guid websiteId)
        {
            _websiteId = websiteId;
        }

        [Browsable(false)]

        #region Properties

        #region Privates 
        //private bool _searchEnabled = false;
        #endregion

        #region Search
        [Category("Search")]
        [DisplayName("Search Enabled")]
        [Description("Enable Search?")]
        [SiteSettings(@"Search/Enabled")]
        public bool? SearchEnabled { get; set; } = true;

        [Category("Search")]
        [DisplayName("Faceted View")]
        [Description("Enable Faceted View?")]
        [SiteSettings(@"Search/FacetedView")]
        public bool? FacetedView { get; set; } = true;

        [Category("Search")]
        [DisplayName("Index Notes Attachments")]
        [Description("Index Notes Attachments?")]
        [SiteSettings(@"Search/IndexNotesAttachments")]
        public bool? IndexNotesAttachments { get; set; } = false;

        [Category("Search")]
        [DisplayName("Index Query Name")]
        [Description("Index Query Name")]
        [SiteSettings(@"Search/IndexQueryName")]
        public string IndexQueryName { get; set; } = "Portal Search";

        [Category("Search")]
        [DisplayName("Filters")]
        [Description("Search Filters")]
        [SiteSettings(@"search/filters")]
        public string SearchFilters { get; set; }

        [Category("Search")]
        [DisplayName("Query String")]
        [Description("Search Query String")]
        [SiteSettings(@"search/query")]
        public string SearchQuery { get; set; } = @"+(@Query) _title:(@Query) _logicalname:knowledgearticle~0.9^0.3 _logicalname:annotation~0.9^0.25 _logicalname:adx_webpage~0.9^0.2 -_logicalname:adx_webfile~0.9 adx_partialurl:(@Query) _logicalname:adx_blogpost~0.9^0.1 -_logicalname:adx_communityforumthread~0.9";
        #endregion

        #region Bingmaps
        [Category("Bingmaps")]
        [DisplayName("Credentials")]
        [Description("Bingmaps Credentials String")]
        [SiteSettings(@"Bingmaps/credentials")]
        public string BingmapsCredentials { get; set; }

        [Category("Bingmaps")]
        [DisplayName("Rest URL")]
        [Description("Bingmaps Rest URL")]
        [SiteSettings(@"Bingmaps/restURL")]
        [RegularExpression(Constants.RegEx_URL, ErrorMessage = "Bingmaps Rest URL expects a valid URL string")]
        public string BingmapsRestURL { get; set; }
        #endregion

        #region Other
        [Category("Customer Support")]
        [DisplayName("Display User Activities")]
        [Description("Display All User Activities On Timeline?")]
        [SiteSettings(@"CustomerSupport/DisplayAllUserActivitiesOnTimeline")]
        public bool? DisplayUserActivities { get; set; } = false;

        [Category("HTTP")]
        [DisplayName("X-Frame Options")]
        [Description("X-Frame-Options is part of the HTTP response header and can be used by the web server to control who can display your content directly in an iframe.")]
        [SiteSettings(@"HTTP/X-Frame-Options")]
        public string XFrameOptions { get; set; } = "SAMEORIGIN";

        [Category("Knowledge Management")]
        [DisplayName("Notes Filter")]
        [Description("Notes Filter String")]
        [SiteSettings(@"KnowledgeManagement/NotesFilter")]
        public string NotesFilter { get; set; } = "*WEB*";

        [Category("General")]
        [DisplayName("Online Domains")]
        [Description("Online Domains List")]
        [SiteSettings(@"OnlineDomains", ';')]
        public string[] OnlineDomains { get; set; } = new string[] { "sharepoint.com", "microsoftonline.com" };
        #endregion

        #region Multi Language
        [Category("Multi Language")]
        [DisplayName("Display Language Code")]
        [Description("Display Language Code In URL")]
        [SiteSettings(@"MultiLanguage/DisplayLanguageCodeInURL")]
        public bool? DisplayLanguageCodeInURL { get; set; } = false;

        [Category("Multi Language")]
        [DisplayName("Maximum Depth To Clone")]
        [Description("Maximum Depth To Clone")]
        [SiteSettings(@"MultiLanguage/MaximumDepthToClone")]
        public int? MaximumDepthToClone { get; set; } = 3;
        #endregion

        #region Header/Footer
        [Category("Header/Footer")]
        [DisplayName("Footer Output Cache Enabled")]
        [Description("Enable Footer Output Cache?")]
        [SiteSettings(@"Footer/OutputCache/Enabled")]
        public bool? FooterOutputCacheEnabled { get; set; } = true;

        [Category("Header/Footer")]
        [DisplayName("Header Output Cache Enabled")]
        [Description("Enable Header Output Cache?")]
        [SiteSettings(@"Header/OutputCache/Enabled")]
        public bool? HeaderOutputCacheEnabled { get; set; } = true;

        #endregion

        #region Profile
        [Category("Profile")]
        [DisplayName("Force Signup")]
        [Description("Force Signup for Portal users?")]
        [SiteSettings(@"Profile/ForceSignUp")]
        public bool? ForceSignUp { get; set; } = false;

        [Category("Profile")]
        [DisplayName("Show Marketing Options")]
        [Description("Show Marketing Options Panel")]
        [SiteSettings(@"Profile/ShowMarketingOptionsPanel")]
        public bool? ShowMarketingOptionsPanel { get; set; } = true;
        #endregion

        #region Authenticaton

        #region Registration
        [Category("Authenticaton/Registration")]
        [DisplayName("AzureAD Login Enabled")]
        [Description("	Enables or disables Azure AD as an external identity provider. By default, it is set to true.")]
        [SiteSettings(@"Authentication/Registration/AzureADLoginEnabled")]
        public bool? AzureADLoginEnabled { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Deny Minors")]
        [Description("Denies use of the portal by minors. By default, it is set to false.")]
        [SiteSettings(@"Authentication/Registration/DenyMinors")]
        public bool? DenyMinors { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Deny Minors Without Parental Consent")]
        [Description("Denies use of the portal by minors without parental consent. By default, it is set to false.")]
        [SiteSettings(@"Authentication/Registration/DenyMinorsWithoutParentalConsent")]
        public bool? DenyMinorsWithoutParentalConsent { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Email Confirmation Enabled")]
        [Description("Specifies whether email validation is required. By default, it is set to true.")]
        [SiteSettings(@"Authentication/Registration/EmailConfirmationEnabled")]
        public bool? EmailConfirmationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Registration Enabled")]
        [Description("Enables or disables all forms of user registration. Registration must be enabled for the other settings in this section to take effect. Default: true")]
        [SiteSettings(@"Authentication/Registration/Enabled")]
        public bool? RegistrationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("External Login Enabled")]
        [Description("Enables or disables external account sign-in and registration. Default: true")]
        [SiteSettings(@"Authentication/Registration/ExternalLoginEnabled")]
        public bool? ExternalLoginEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Reset Password Enabled")]
        [Description("Enables or disables the password reset feature. Default: true")]
        [SiteSettings(@"Authentication/Registration/ResetPasswordEnabled")]
        public bool? ResetPasswordEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Reset Password Requires Confirmed Email")]
        [Description("Enables or disables password reset for confirmed email addresses only. If enabled, unconfirmed email addresses cannot be used to send password reset instructions. Default: false")]
        [SiteSettings(@"Authentication/Registration/ResetPasswordRequiresConfirmedEmail")]
        public bool? ResetPasswordRequiresConfirmedEmail { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Remember Me Enabled")]
        [Description("Selects or clears a Remember me? check box on local sign-in to allow authenticated sessions to persist even when the web browser is closed. Default: true")]
        [SiteSettings(@"Authentication/Registration/RememberMeEnabled")]
        public bool? RememberMeEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Remember Browser Enabled")]
        [Description("Selects or clears a Remember browser? check box on second-factor validation (email code) to persist the second-factor validation for the current browser. The user will not be required to pass the second-factor validation for subsequent sign-ins as long as the same browser is being used. Default: true")]
        [SiteSettings(@"Authentication/Registration/RememberBrowserEnabled")]
        public bool? RememberBrowserEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Trigger Lockout On Failed Password")]
        [Description("Enables or disables recording of failed password attempts. If disabled, user accounts will not be locked out. Default: true")]
        [SiteSettings(@"Authentication/Registration/TriggerLockoutOnFailedPassword")]
        public bool? TriggerLockoutOnFailedPassword { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Is Demo Mode")]
        [Description("Enables or disables a demo mode flag to be used in development or demonstration environments only. Do not enable this setting on production environments. Demo mode also requires the web browser to be running locally to the web application server. When demo mode is enabled, the password reset code and second-factor code are displayed to the user for quick access. Default: false")]
        [SiteSettings(@"Authentication/Registration/IsDemoMode")]
        public bool? IsDemoMode { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Invitation Enabled")]
        [Description("Enables or disables the sign-up registration form for creating new local users. The sign-up form allows any anonymous visitor to the portal to create a new user account. Default: true")]
        [SiteSettings(@"Authentication/Registration/InvitationEnabled")]
        public bool? InvitationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Local Login Deprecated")]
        [Description("Disable Local Login for Users")]
        [SiteSettings(@"Authentication/Registration/LocalLoginDeprecated")]
        public bool? LocalLoginDeprecated { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Local Login Enabled")]
        [Description("Enables or disables local account sign-in based on a username (or email) and password. Default: false")]
        [SiteSettings(@"Authentication/Registration/LocalLoginEnabled")]
        public bool? LocalLoginEnabled { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Login Button Auth Type")]
        [Description("If a portal only requires a single external identity provider (to handle all authentication), this allows the Sign-In button of the header nav bar to link directly to the sign-in page of that external identity provider")]
        [SiteSettings(@"Authentication/Registration/LoginButtonAuthenticationType")]
        public string LoginButtonAuthenticationType { get; set; } = "";

        [Category("Authenticaton/Registration")]
        [DisplayName("Open Registration Enabled")]
        [Description("Enables or disables the sign-up registration form for creating new local users. The sign-up form allows any anonymous visitor to the portal to create a new user account. Default: true")]
        [SiteSettings(@"Authentication/Registration/OpenRegistrationEnabled")]
        public bool? OpenRegistrationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Profile Redirect Enabled")]
        [Description("	Specifies whether the portal can redirect users to the profile page after successful sign-in. By default, it is set to true.")]
        [SiteSettings(@"Authentication/Registration/ProfileRedirectEnabled")]
        public bool? ProfileRedirectEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Terms Publication Date")]
        [Description("A date/time value in GMT format to represent the effective date of the current published terms and conditions. If the terms agreement is enabled, portal users that have not accepted the terms after this date will be asked to accept them the next time they sign in. If the date is not provided, and the terms agreement is enabled, the terms will be presented every time portal users sign in.")]
        [SiteSettings(@"Authentication/Registration/TermsPublicationDate")]
        public DateTime? TermsPublicationDate { get; set; } = null;

        [Category("Authenticaton/Registration")]
        [DisplayName("Terms Agreement Enabled")]
        [Description("	A true or false value. If set to true, the portal will display the terms and conditions of the site. Users must agree to the terms and conditions before they are considered authenticated and can use the site. By default, it is set to false.")]
        [SiteSettings(@"Authentication/Registration/TermsAgreementEnabled")]
        public bool? TermsAgreementEnabled { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Local Login By Email")]
        [Description("Enables or disables local account sign-in using an email address field instead of a username field. Default: false")]
        [SiteSettings(@"Authentication/Registration/LocalLoginByEmail")]
        public bool? LocalLoginByEmail { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Captcha Enabled")]
        [Description("Enables or disables captcha on the user registration page. Default: false")]
        [SiteSettings(@"Authentication/Registration/CaptchaEnabled")]
        public bool? CaptchaEnabled { get; set; } = false;
        #endregion

        #region Login
        [Category("Authenticaton/Login")]
        [DisplayName("IP Address Timeout TimeSpan")]
        [Description("IP Address Timeout TimeSpan")]
        [SiteSettings(@"Authentication/LoginThrottling/IpAddressTimeoutTimeSpan")]
        public TimeSpan IpAddressTimeoutTimeSpan { get; set; } = new TimeSpan(00, 10, 00);

        [Category("Authenticaton/Login")]
        [DisplayName("Max Attempts Time Limit TimeSpan")]
        [Description("Enables or disables captcha on the user registration page. Default: false")]
        [SiteSettings(@"Authentication/LoginThrottling/MaxAttemptsTimeLimitTimeSpan")]
        public TimeSpan MaxAttemptsTimeLimitTimeSpan { get; set; } = new TimeSpan(00, 03, 00);

        [Category("Authenticaton/Login")]
        [DisplayName("Max Invaild Attempts From IP Address")]
        [Description("Max Invaild Attempts From IP Address")]
        [SiteSettings(@"Authentication/LoginThrottling/MaxInvaildAttemptsFromIPAddress")]
        public int? MaxInvaildAttemptsFromIPAddress { get; set; } = 1000;

        [Category("Authenticaton/Login")]
        [DisplayName("Login Tracking Enabled")]
        [Description("Login Tracking Enabled")]
        [SiteSettings(@"Authentication/LoginTrackingEnabled")]
        public bool? LoginTrackingEnabled { get; set; } = false;
        #endregion
        
        #region OpenAuth
        [Category("Authenticaton/OpenAuth")]
        [DisplayName("OpenAuth Providers")]
        [Description(@"OpenAuth Provider details.  NOTE: Settings have changed for Microsoft, Facebook, LinkedIn, Twitter, Google, and Yahoo. All now conform to the same format of ClientId/ClientSecret.  More details here: https://docs.microsoft.com/en-us/powerapps/maker/portals/configure/configure-oauth2-settings")]
        public OpenAuthProvider[] OpenAuthProviders { get; set; } = new OpenAuthProvider[0];
        #endregion

        #region WS-Federation
        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/MetadataAddress")]
        [DisplayName("MetadataAddress")]
        [Description("Required. The WS-Federation metadata URL of the AD FS (STS) server. Commonly ending with the path:/FederationMetadata/2007-06/FederationMetadata.xml . Example:https://adfs.contoso.com/FederationMetadata/2007-06/FederationMetadata.xml. For more information: WsFederationAuthenticationOptions.MetadataAddress.")]
        public string WsFed_MetadataAddress { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/AuthenticationType")]
        [DisplayName("AuthenticationType")]
        [Description("Required. The OWIN authentication middleware type. Specify the value of the entityID attribute at the root of the federation metadata XML. Example: https://adfs.contoso.com/adfs/services/trust. For more information: AuthenticationOptions.AuthenticationType.")]
        public string WsFed_AuthenticationType { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/Wtrealm")]
        [DisplayName("Wtrealm")]
        [Description("Required. The AD FS relying party identifier. Example: https://portal.contoso.com/. For more information: WsFederationAuthenticationOptions.Wtrealm.")]
        public string WsFed_Wtrealm { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/Wreply")]
        [DisplayName("Wreply")]
        [Description("Required. The AD FS WS-Federation passive endpoint. Example: https://portal.contoso.com/signin-federation. For more information: WsFederationAuthenticationOptions.Wreply.")]
        public string WsFed_Wreply { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/Caption")]
        [DisplayName("Caption")]
        [Description("Recommended. The text that the user can display on a sign in user interface. Default: ADFS. For more information: WsFederationAuthenticationOptions.Caption.")]
        public string WsFed_Caption { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/CallbackPath")]
        [DisplayName("CallbackPath")]
        [Description("An optional constrained path on which to process the authentication callback. For more information: WsFederationAuthenticationOptions.CallbackPath.")]
        public string WsFed_CallbackPath { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/SignOutWreply")]
        [DisplayName("SignOutWreply")]
        [Description("The 'wreply' value used during sign-out. For more information: WsFederationAuthenticationOptions.SignOutWreply.")]
        public string WsFed_SignOutWreply { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/BackchannelTimeout")]
        [DisplayName("BackchannelTimeout")]
        [Description("Timeout value for back channel communications. Example: 00:05:00 (5 mins). For more information: WsFederationAuthenticationOptions.BackchannelTimeout.")]
        public TimeSpan WsFed_BackchannelTimeout { get; set; } = new TimeSpan(00, 5, 00);

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/RefreshOnIssuerKeyNotFound")]
        [DisplayName("RefreshOnIssuerKeyNotFound")]
        [Description("Determines if a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. For more information: WsFederationAuthenticationOptions.RefreshOnIssuerKeyNotFound.")]
        public string WsFed_RefreshOnIssuerKeyNotFound { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/UseTokenLifetime")]
        [DisplayName("UseTokenLifetime")]
        [Description("Indicates that the authentication session lifetime (e.g. cookies) should match that of the authentication token. WsFederationAuthenticationOptions.UseTokenLifetime.")]
        public string WsFed_UseTokenLifetime { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/AuthenticationMode")]
        [DisplayName("AuthenticationMode")]
        [Description("The OWIN authentication middleware mode. For more information: AuthenticationOptions.AuthenticationMode.")]
        public AuthenticationMode WsFed_AuthenticationMode { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/SignInAsAuthenticationType")]
        [DisplayName("SignInAsAuthenticationType")]
        [Description("The AuthenticationType used when creating the System.Security.Claims.ClaimsIdentity. For more information: WsFederationAuthenticationOptions.SignInAsAuthenticationType.")]
        public string WsFed_SignInAsAuthenticationType { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidAudiences", ',')]
        [DisplayName("ValidAudiences")]
        [Description("Comma separated list of audience URLs. For more information: TokenValidationParameters.AllowedAudiences.")]
        public string[] WsFed_ValidAudiences { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidIssuers", ',')]
        [DisplayName("ValidIssuers")]
        [Description("Comma separated list of issuer URLs. For more information: TokenValidationParameters.ValidIssuers.")]
        public string[] WsFed_ValidIssuers { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ClockSkew")]
        [DisplayName("ClockSkew")]
        [Description("The clock skew to apply when validating times.")]
        public string WsFed_ClockSkew { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/NameClaimType")]
        [DisplayName("NameClaimType")]
        [Description("The claim type used by the ClaimsIdentity to store the name claim.")]
        public string WsFed_NameClaimType { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/RoleClaimType")]
        [DisplayName("RoleClaimType")]
        [Description("The claim type used by the ClaimsIdentity to store the role claim.")]
        public string WsFed_RoleClaimType { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/RequireExpirationTime")]
        [DisplayName("RequireExpirationTime")]
        [Description("A value indicating whether tokens must have an 'expiration' value.")]
        public bool? WsFed_RequireExpirationTime { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/RequireSignedTokens")]
        [DisplayName("RequireSignedTokens")]
        [Description("A value indicating whether a System.IdentityModel.Tokens.SecurityToken xmlns=https://ddue.schemas.microsoft.com/authoring/2003/5 can be valid if not signed.")]
        public bool? WsFed_RequireSignedTokens { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/SaveSigninToken")]
        [DisplayName("SaveSigninToken")]
        [Description("A Boolean to control if the original token is saved when a session is created.")]
        public bool? WsFed_SaveSigninToken { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidateActor")]
        [DisplayName("ValidateActor")]
        [Description("A value indicating whether the System.IdentityModel.Tokens.JwtSecurityToken.Actor should be validated.")]
        public bool? WsFed_ValidateActor { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidateAudience")]
        [DisplayName("ValidateAudience")]
        [Description("A Boolean to control if the audience will be validated during token validation.")]
        public bool? WsFed_ValidateAudience { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidateIssuer")]
        [DisplayName("ValidateIssuer")]
        [Description("A Boolean to control if the issuer will be validated during token validation.")]
        public bool? WsFed_ValidateIssuer { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidateLifetime")]
        [DisplayName("ValidateLifetime")]
        [Description("A Boolean to control if the lifetime will be validated during token validation.")]
        public bool? WsFed_ValidateLifetime { get; set; }
        
        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/ValidateIssuerSigningKey")]
        [DisplayName("ValidateIssuerSigningKey")]
        [Description("A Boolean that controls if validation of the System.IdentityModel.Tokens.SecurityKey that signed the securityToken xmlns=https://ddue.schemas.microsoft.com/authoring/2003/5 is called.")]
        public bool? WsFed_ValidateIssuerSigningKey { get; set; }

        [Category("Authentication/WsFederation/ADFS")]
        [SiteSettings("Authentication/WsFederation/ADFS/Whr")]
        [DisplayName("Whr")]
        [Description("Specifies a \"whr\" parameter in the identity provider redirect URL. For more information: wsFederation.")]
        public string WsFed_Whr { get; set; }

        #endregion

        [Category("Authenticaton/OpenIdConnect")]
        [DisplayName("Open ID Connect Providers")]
        [Description("Collection of OpenId Connect Identity Providers")]
        public OpenIdConnect[] OpenIdConnectProviders { get; set; } = new OpenIdConnect[0];

        [Category("Authenticaton/SAML 2.0")]
        [DisplayName("SAML 2.0 Providers")]
        [Description("Collection of SAML 2.0 Identity Providers")]
        public SAML20[] SAML20Providers { get; set; } = new SAML20[0];

        #endregion
        #endregion

        #region Methods 
        /// <summary>
        /// Load the entity collection into the structure 
        /// </summary>
        /// <param name="entities"></param>
        public void LoadSettings(EntityCollection entities)
        {
            // iterate on the records and load the values
            var props = this.GetType().GetProperties();

            #region most properties
            foreach (var prop in props)
            {
                // find the attrib with the name value
                var attrib = prop
                    .GetCustomAttributes(true)
                    .Where(a => a is SiteSettingsAttribute)
                    .FirstOrDefault() 
                    as SiteSettingsAttribute;

                if (attrib != null)
                {
                    // get the name from the attribute
                    var name = attrib.NameFormat.ToLower();

                    // find correct Name from the entity collection 
                    var setting = entities.Entities.Where(e => e["adx_name"].ToString().ToLower() == name).FirstOrDefault();

                    if (setting != null && setting.Attributes.ContainsKey("adx_value"))
                    {
                        var entVal = setting["adx_value"].ToString();

                        ReflectionHelper.SetSiteSettingsValue(this, prop, attrib, entVal);
                    }
                }
            }
            #endregion

            #region Open Auth Values
            // new settings, so MS, FB, LI, all now fall under this collection 
            OpenAuthProviders = OpenAuthProvider.LoadItems(entities, _websiteId).ToArray(); 
            #endregion

            #region OpenId Connect Values
            // now add the items back to the prop as an array for the prop grid 
            OpenIdConnectProviders = OpenIdConnect.LoadItems(entities).ToArray();

            #endregion

            #region SAML 2.0

            // now add the items back to the prop as an array for the prop grid 
            SAML20Providers = SAML20.LoadItems(entities).ToArray();

            #endregion
        }

        /// <summary>
        /// Get a list of the pending changes
        /// </summary>
        /// <param name="currentSettings"></param>
        /// <returns></returns>
        public List<PendingChange> GetUpdatedSettings(EntityCollection currentSettings)
        {
            var changesList = new List<PendingChange>();
            var props = GetType().GetProperties();

            foreach (var prop in props)
            {
                var entUpdate = EvaluateProperty(currentSettings, prop, this, _websiteId);

                if (entUpdate != null) {
                    changesList.Add(entUpdate);
                }
            }

            // now handle the auth settings 
            foreach (var openAuth in OpenAuthProviders)
            {
                props = openAuth.GetType().GetProperties();
                EvaluatePropertyList(currentSettings, props, openAuth, "{Provider}", openAuth.ProviderName, _websiteId, ref changesList);
            }

            // now for the OpenID Connect settings
            foreach (var openId in OpenIdConnectProviders)
            {
                props = openId.GetType().GetProperties();
                EvaluatePropertyList(currentSettings, props, openId, "{FederatedName}", openId.FederatedName, _websiteId, ref changesList);
            }
            // now for the OpenID Connect settings
            foreach (var saml in SAML20Providers)
            {
                props = saml.GetType().GetProperties();
                EvaluatePropertyList(currentSettings, props, saml, "{Provider}", saml.Provider, _websiteId, ref changesList);
            }

            return changesList;
        }
        #endregion

        #region Helper methods

        /// <summary>
        /// Evaluate a list of Properties for changes
        /// </summary>
        /// <param name="currentSettings"></param>
        /// <param name="props"></param>
        /// <param name="target"></param>
        /// <param name="slug"></param>
        /// <param name="slugValue"></param>
        /// <param name="changesList"></param>
        public static void EvaluatePropertyList(EntityCollection currentSettings, PropertyInfo[] props, object target, string slug, string slugValue, Guid websiteId, ref List<PendingChange> changesList) {

            foreach (var prop in props)
            {
                // special case here since we need to update the name 
                var siteSettingsAttrib = prop
                    .GetCustomAttributes(true)
                    .Where(a => a is SiteSettingsAttribute)
                    .FirstOrDefault() as SiteSettingsAttribute;

                if (siteSettingsAttrib != null)
                {
                    var newVal = prop.GetValue(target);

                    var descAttrib = prop
                            .GetCustomAttributes(true)
                            .Where(a => a is DescriptionAttribute)
                            .FirstOrDefault() as DescriptionAttribute;

                    var ignoreCase = newVal is bool;
                    var newValString = GetPropertyString(prop, newVal, siteSettingsAttrib);
                    var name = siteSettingsAttrib.NameFormat.Replace(slug, slugValue);
                    var entUpdate = CheckAttributeValue(currentSettings, name, newValString, websiteId, ignoreCase, siteSettingsAttrib.IsRequired, descAttrib?.Description);

                    if (entUpdate != null)
                    {
                        // now that we have a change - new or update - validated it
                        var messages = ValidatorHelper.ValidateProperty(prop, target);
                        entUpdate.ValidationMessage = string.Join(",", messages.ToArray());
                        changesList.Add(entUpdate);
                    }
                }
            }
        }

        /// <summary>
        /// Evaluate a given property and decide whether it's an update
        /// </summary>
        /// <param name="currentSettings"></param>
        /// <param name="prop"></param>
        /// <param name="target"></param>
        /// <param name="websiteId"></param>
        /// <returns></returns>
        public static PendingChange EvaluateProperty(EntityCollection currentSettings, PropertyInfo prop, object target, Guid websiteId) {
            string newValString = null;
            PendingChange entUpdate = null;

            var attrib = prop
                .GetCustomAttributes(true)
                .Where(a => a is SiteSettingsAttribute)
                .FirstOrDefault() as SiteSettingsAttribute;

            if (attrib != null)
            {
                var newVal = prop.GetValue(target);
                var descAttrib = prop
                    .GetCustomAttributes(true)
                    .Where(a => a is DescriptionAttribute)
                    .FirstOrDefault() as DescriptionAttribute;

                var ignoreCase = newVal is bool;
                newValString = GetPropertyString(prop, newVal, attrib);

                entUpdate = CheckAttributeValue(currentSettings, attrib.NameFormat, newValString, websiteId, ignoreCase, attrib.IsRequired, descAttrib?.Description);

                if (entUpdate != null)
                {
                    // now that we have a change - new or update - validated it
                    var messages = ValidatorHelper.ValidateProperty(prop, target);
                    entUpdate.ValidationMessage = string.Join(",", messages.ToArray());
                }
            }
            return entUpdate;
        }

        /// <summary>
        /// Get the string value of the current property since all settings are stored as strings 
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="newVal"></param>
        /// <param name="attrib"></param>
        /// <returns></returns>
        private static string GetPropertyString(PropertyInfo prop, object newVal, SiteSettingsAttribute attrib) {
            string newValString = null;

            // get the current property value 
            if (prop.PropertyType.IsArray) {

                if (newVal != null) {
                    newValString = string.Join(attrib.ValueDelimiter.ToString(), newVal as string[]);
                }
            }
            else {
                newValString = newVal?.ToString();
                if (newValString != null && newValString.Length == 0) {
                    newValString = null;
                }
            }
            return newValString;
        }

        /// <summary>
        /// Helper method to retrieve the current record and check to see if we are updating or inserting it
        /// </summary>
        /// <param name="currentSettings"></param>
        /// <param name="settingName"></param>
        /// <param name="newValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static PendingChange CheckAttributeValue(EntityCollection currentSettings, string settingName, string newValue, Guid websiteId, bool ignoreCase = false, bool isRequired = false, string description = null)
        {
            string currVal = null;
            Entity entity = null;

            // find the current record with the same name and check its value 
            var entRec = currentSettings.Entities
                .Where(e => e["adx_name"].ToString() == settingName)
                .FirstOrDefault();

            if (entRec != null)
            {
                if (entRec.Attributes.ContainsKey("adx_value")) 
                {
                    currVal = entRec["adx_value"].ToString();
                }
                // we have current record, update it if the values have changed
                var valsDiffer = false;

                // ignore case for some, like booleans
                if (ignoreCase) {
                    valsDiffer = (currVal?.ToLower() != newValue?.ToLower());
                }
                else 
                {
                    valsDiffer = (currVal != newValue);
                }
                // if different, update current record 
                if (valsDiffer) 
                {
                    entity = new Entity("adx_sitesetting") {
                        Id = entRec.Id,
                        EntityState = EntityState.Changed
                    };
                }
            }
            // if this is a null value and no record, check to see if it's required 
            else if ((isRequired && newValue == null) || (newValue != null))
            {
                // no existing record, create it 
                entity = new Entity("adx_sitesetting") {
                    EntityState = EntityState.Created
                };
            }

            if (entity != null)
            {
                entity.Attributes["adx_value"] = newValue;
                entity.Attributes["adx_name"] = settingName;
                entity.Attributes["adx_websiteid"] = new EntityReference("adx_website", websiteId);
                entity.Attributes["adx_description"] = description;
                return new PendingChange()
                {
                    Entity = entity,
                    Action = entity.EntityState.ToString(),
                    NewValue = newValue,
                    OldValue = currVal,
                    IsRequired = isRequired
                };
            }
            else {
                return null;
            }
        }
        #endregion
    }
}
