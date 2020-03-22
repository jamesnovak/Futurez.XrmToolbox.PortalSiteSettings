using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Futurez.XrmToolBox
{

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class SAML20
    {
        private string _provider = "Provider";
        [Category("Name")]
        [Description("The Provider used when setting up a unique SAML 2.0 Provider")]
        public string Provider
        {
            get { return _provider; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Provider is a required field");
                }
                _provider = value;
            }
        }
        #region Properties
        [Category("SAML 2.0 Details")]
        [DisplayName("Metadata Address")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/MetadataAddress")]
        [Description("Required. The WS-Federation metadata URL of the AD FS (STS) server. It commonly ends with the path:/FederationMetadata/2007-06/FederationMetadata.xml.Example: https://adfs.contoso.com/FederationMetadata/2007-06/FederationMetadata.xml. More information: WsFederationAuthenticationOptions.MetadataAddress")]
        public string MetadataAddress { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Authentication Type")]
        [SiteSettings(@"Authentication/SAML2/{Provider}/AuthenticationType")]
        [Description("Required. The OWIN authentication middleware type.Specify the value of the entityID attribute at the root of the federation metadata XML.Example: https://adfs.contoso.com/adfs/services/trust. More information: AuthenticationOptions.AuthenticationType")]
        public string AuthenticationType { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Service Provider Realm")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/ServiceProviderRealm")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Service Provider Realm is required")]
        [RegularExpression(Constants.RegEx_URL, ErrorMessage = "Service Provider Realm is not a valid URL string")]
        [Description("Required. The AD FS relying party identifier. Example: https://portal.contoso.com/. More information: WsFederationAuthenticationOptions.Wtrealm")]
        public string ServiceProviderRealm { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Assertion Consumer Service Url")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/AssertionConsumerServiceUrl")]
        [Description("Required. The AD FS SAML Consumer Assertion endpoint.Example: https://portal.contoso.com/signin-saml2. More information: WsFederationAuthenticationOptions.Wreply")]
        public string AssertionConsumerServiceUrl { get; set; } // = @"https://portal.contoso.com/signin-saml2";

        [Category("SAML 2.0 Details")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/Caption")]
        [Description("Recommended. The text that the user can display on a sign-in user interface. Default: {Provider}. More information: WsFederationAuthenticationOptions.Caption")]
        public string Caption { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Callback Path")]
        [SiteSettings(@"Authentication/SAML2/{Provider}/CallbackPath")]
        [Description("An optional constrained path on which to process the authentication callback.More information: WsFederationAuthenticationOptions.CallbackPath")]
        public string CallbackPath { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Backchannel Timeout")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/BackchannelTimeout")]
        [Description("Timeout value for back-channel communications. Example: 00:05:00 (5 mins). More information: WsFederationAuthenticationOptions.BackchannelTimeout")]
        public TimeSpan BackchannelTimeout { get; set; } = new TimeSpan(00, 5, 00);

        [Category("SAML 2.0 Details")]
        [DisplayName("UseToken Lifetime")]
        [SiteSettings(@"Authentication/SAML2/{Provider}/UseTokenLifetime")]
        [Description("Indicates that the authentication session lifetime(for example, cookies) should match that of the authentication token.WsFederationAuthenticationOptions.UseTokenLifetime.")]
        public string UseTokenLifetime { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Authentication Mode")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/AuthenticationMode")]
        [Description("The OWIN authentication middleware mode.More information: AuthenticationOptions.AuthenticationMode")]
        public AuthenticationMode AuthenticationMode { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Sign In As Authentication Type")]
        [SiteSettings(@"Authentication/SAML2/{Provider}/SignInAsAuthenticationType")]
        [Description("The AuthenticationType used when creating the System.Security.Claims.ClaimsIdentity.More information: WsFederationAuthenticationOptions.SignInAsAuthenticationType")]
        public string SignInAsAuthenticationType { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("ValidAudiences")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/ValidAudiences", ',')]
        [Description("Comma-separated list of audience URLs.More information: TokenValidationParameters.AllowedAudiences")]
        public string[] ValidAudiences { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Clock Skew")]
        [SiteSettings(@"Authentication/SAML2/{Provider}/ClockSkew")]
        [Description("The clock skew to apply when validating times.")]
        public string ClockSkew { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Require Expiration Time")]
        [SiteSettings(@"Authentication /SAML2/{Provider}/RequireExpirationTime")]
        [Description("A value indicating whether tokens must have an expiration value.")]
        public bool? RequireExpirationTime { get; set; }

        [Category("SAML 2.0 Details")]
        [DisplayName("Default Policy Id")]
        [SiteSettings(@"Authentication/SAML2/{Provider}/ValidateAudience")]
        [Description("A Boolean to control whether the audience will be validated during token validation.")]
        public bool? ValidateAudience { get; set; }
        #endregion

        /// <summary>
        /// Helper method to load a collection of items from an Entity List
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<SAML20> LoadItems(EntityCollection entities) 
        {
            var samlEnt = entities.Entities
                .Where(e => e["adx_name"].ToString().StartsWith("Authentication/SAML2/"))
                .Select(e => new {
                    name = e["adx_name"].ToString(),
                    value = (e.Attributes.ContainsKey("adx_value")) ? e["adx_value"].ToString() : null
                });

            // use new list, dynamic add
            var samlItems = new List<SAML20>();

            foreach (var ent in samlEnt)
            {
                var parts = ent.name.Split('/');
                var providerName = parts[2];

                // see if we have a current item with this fed name 
                var samlItem = samlItems
                    .Where(o => o.Provider == providerName)
                    .FirstOrDefault();

                if (samlItem == null)
                {
                    samlItem = new SAML20() {
                        Provider = providerName
                    };
                    samlItems.Add(samlItem);
                }
                // set the value on the object using helper method
                ReflectionHelper.SetSiteSettingsValue(samlItem, parts[3], ent.value);
            }

            return samlItems;
        }

        public override string ToString()
        {
            return Provider;
        }
    }
}
