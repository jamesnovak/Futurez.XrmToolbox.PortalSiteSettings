using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Futurez.XrmToolBox
{
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class OpenIdConnect
    {
        private string _federatedName = "New OpenID Connect";

        public OpenIdConnect() { }

        [Category("Name")]
        [DisplayName("Federated Name")]
        [Description("The Federated Name used when setting up OpenId Connect Identity Provider")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Federated Name is a required field.")]
        public string FederatedName
        {
            get { return _federatedName; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Federated Name is a required field");
                }
                _federatedName = value;
            }
        }

        [Category("OpenIdConnect")]
        [DisplayName("Authority")]
        [Description("Authority URL")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/Authority")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required. The Authority to use when making OpenIdConnect calls. Example: https://login.microsoftonline.com/contoso.onmicrosoft.com/. For more information:OpenIdConnectAuthenticationOptions.Authority..")]
        [RegularExpression(Constants.RegEx_URL, ErrorMessage = "The Authority URL is not a valid URL string")]
        public string Authority { get; set; }
        
        [Category("OpenIdConnect")]
        [DisplayName("Client ID")]
        [Description("Client/Application Id")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/ClientId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Client Id is a required field.")]
        public string ClientID { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Default Policy Id")]
        [Description("D of the sign-in or sign-up policy.")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/DefaultPolicyId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Default Policy Id is a required field.")]
        public string DefaultPolicyId { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("External Logout Enabled")]
        [Description("Enables or disables federated sign-out. When set to true, users are redirected to the federated sign-out user experience when they sign out from the portal.When set to false, users are signed out from the portal only.By default, it is set to false.")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/ExternalLogoutEnabled")]
        public bool ExternalLogoutEnabled { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Password Reset Policy Id")]
        [Description("ID of the password reset policy.")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/PasswordResetPolicyId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Password Reset Policy Id is a required field.")]
        public string PasswordResetPolicyId { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Valid Issuers")]
        [Description("A comma-delimited list of issuers that includes the [Policy-Signin-URL] and the issuer of the password reset policy.")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/ValidIssuers", ',')]
        public string[] ValidIssuers { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Valid Audiences")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ValidAudiences", ',')]
        [Description("Comma-separated list of audience URLs. For more information: TokenValidationParameters.AllowedAudiences.")]
        public string[] ValidAudiences { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Metadata Address")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/MetadataAddress")]
        [Description("The discovery endpoint for obtaining metadata. Commonly ending with the path:/.well-known/openid-configuration . Example: https://login.microsoftonline.com/contoso.onmicrosoft.com/.well-known/openid-configuration. For more information:OpenIdConnectAuthenticationOptions.MetadataAddress.")]
        public string MetadataAddress { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Authentication Type")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/AuthenticationType")]
        [Description("The OWIN authentication middleware type. Specify the value of the issuer in the service configuration metadata. Example: https://sts.windows.net/contoso.onmicrosoft.com/. For more information: AuthenticationOptions.AuthenticationType.")]
        public string AuthenticationType { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Client Secret")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ClientSecret")]
        [Description("The client secret value from the provider application. It may also be referred to as an \"App Secret\" or \"Consumer Secret\". For more information: OpenIdConnectAuthenticationOptions.ClientSecret.")]
        public string ClientSecret { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Redirect Uri")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/RedirectUri")]
        [Description("Recommended. The AD FS WS-Federation passive endpoint. Example: https://portal.contoso.com/signin-saml2. For more information: OpenIdConnectAuthenticationOptions.RedirectUri.")]
        public string RedirectUri { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Caption")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/Caption")]
        [Description("Recommended. The text that the user can display on a sign in user interface. Default: [provider]. For more information: OpenIdConnectAuthenticationOptions.Caption.")]
        public string Caption { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Resource")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/Resource")]
        [Description("The 'resource'. For more information: OpenIdConnectAuthenticationOptions.Resource.")]
        public string Resource { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Response Type")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ResponseType")]
        [Description("The 'response_type'. For more information: OpenIdConnectAuthenticationOptions.ResponseType.")]
        public string ResponseType { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Scope")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/Scope")]
        [Description("A space separated list of permissions to request. Default: openid. For more information: OpenIdConnectAuthenticationOptions.Scope .")]
        public string Scope { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Callback Path")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/CallbackPath")]
        [Description("An optional constrained path on which to process the authentication callback. If not provided and RedirectUri is available, this value will be generated from RedirectUri. For more information: OpenIdConnectAuthenticationOptions.CallbackPath.")]
        public string CallbackPath { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Backchannel Timeout")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/BackchannelTimeout")]
        [Description("Timeout value for back channel communications. Example: 00:05:00 (5 mins). For more information: OpenIdConnectAuthenticationOptions.BackchannelTimeout.")]
        public TimeSpan BackchannelTimeout { get; set; } = new TimeSpan(00, 5, 00);

        [Category("OpenIdConnect")]
        [DisplayName("Refresh On Issuer Key Not Found")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/RefreshOnIssuerKeyNotFound")]
        [Description("Determines whether a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. For more information: OpenIdConnectAuthenticationOptions.RefreshOnIssuerKeyNotFound.")]
        public bool RefreshOnIssuerKeyNotFound { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Use Token Lifetime")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/UseTokenLifetime")]
        [Description("Indicates that the authentication session lifetime (e.g. cookies) should match that of the authentication token. For more information: OpenIdConnectAuthenticationOptions.UseTokenLifetime.")]
        public bool UseTokenLifetime { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Authentication Mode")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/AuthenticationMode")]
        [Description("The OWIN authentication middleware mode. For more information: AuthenticationOptions.AuthenticationMode.")]
        public AuthenticationMode AuthenticationMode { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Sign In As Authentication Type")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/SignInAsAuthenticationType")]
        [Description("The AuthenticationType used when creating the System.Security.Claims.ClaimsIdentity. For more information: OpenIdConnectAuthenticationOptions.SignInAsAuthenticationType.")]
        public string SignInAsAuthenticationType { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Post Logout Redirect Uri")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/PostLogoutRedirectUri")]
        [Description("The 'post_logout_redirect_uri'. For more information: OpenIdConnectAuthenticationOptions.PostLogoutRedirectUri.")]
        public string PostLogoutRedirectUri { get; set; }


        [Category("OpenIdConnect")]
        [DisplayName("Clock Skew")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ClockSkew")]
        [Description("The clock skew to apply when validating times.")]
        public string ClockSkew { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Name Claim Type")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/NameClaimType")]
        [Description("The claim type used by the ClaimsIdentity to store the name claim.")]
        public string NameClaimType { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Role Claim Type")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/RoleClaimType")]
        [Description("The claim type used by the ClaimsIdentity to store the role claim.")]
        public string RoleClaimType { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Require Expiration Time")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/RequireExpirationTime")]
        [Description("A value indicating whether tokens must have an 'expiration' value.")]
        public bool RequireExpirationTime { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Require Signed Tokens")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/RequireSignedTokens")]
        [Description("A value indicating whether a System.IdentityModel.Tokens.SecurityToken xmlns=https://ddue.schemas.microsoft.com/authoring/2003/5 can be valid if not signed.")]
        public bool RequireSignedTokens { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Save Signin Token")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/SaveSigninToken")]
        [Description("A Boolean to control if the original token is saved when a session is created.")]
        public bool SaveSigninToken { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Validate Actor")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ValidateActor")]
        [Description("A value indicating whether the System.IdentityModel.Tokens.JwtSecurityToken.Actor should be validated.")]
        public bool ValidateActor { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Validate Audience")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ValidateAudience")]
        [Description("A Boolean to control if the audience will be validated during token validation.")]
        public bool ValidateAudience { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Validate Issuer")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ValidateIssuer")]
        [Description("A Boolean to control if the issuer will be validated during token validation.")]
        public bool ValidateIssuer { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Validate Lifetime")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ValidateLifetime")]
        [Description("A Boolean to control if the lifetime will be validated during token validation.")]
        public bool ValidateLifetime { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Validate Issuer Signing Key")]
        [SiteSettings("Authentication/OpenIdConnect/{FederatedName}/ValidateIssuerSigningKey")]
        [Description("A Boolean that controls if validation of the System.IdentityModel.Tokens.SecurityKey that signed the securityToken xmlns=https://ddue.schemas.microsoft.com/authoring/2003/5 is called.")]
        public bool ValidateIssuerSigningKey { get; set; }

        public bool IsValid() {
            return true;
        }

        /// <summary>
        /// Helper method to load a collection of items from an Entity List
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<OpenIdConnect> LoadItems(EntityCollection entities)
        {
            var openIdEnt = entities.Entities
                .Where(e => e["adx_name"].ToString().StartsWith("Authentication/OpenIdConnect/"))
                .Select(e => new {
                    name = e["adx_name"].ToString(),
                    value = (e.Attributes.ContainsKey("adx_value")) ? e["adx_value"].ToString() : null
                });

            // use new list, dynamic add
            var items = new List<OpenIdConnect>();

            foreach (var ent in openIdEnt)
            {
                var parts = ent.name.Split('/');
                var fedName = parts[2];

                // see if we have a current item with this fed name 
                var openIdItem = items
                    .Where(o => o.FederatedName == fedName)
                    .FirstOrDefault();

                if (openIdItem == null)
                {
                    openIdItem = new OpenIdConnect()
                    {
                        FederatedName = fedName
                    };
                    items.Add(openIdItem);
                }
                // set the value on the object using helper method
                ReflectionHelper.SetSiteSettingsValue(openIdItem, parts[3], ent.value);
            }

            return items;
        }

        public override string ToString()
        {
            return FederatedName;
        }
    }
}
