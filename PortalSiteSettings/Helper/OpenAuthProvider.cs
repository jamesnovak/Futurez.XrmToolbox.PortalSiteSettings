using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Design;
using System.Linq;

namespace Futurez.XrmToolBox
{
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class OpenAuthProvider
    {
        private string _providerName = "";
        private Guid _websiteId = Guid.Empty;

        internal OpenAuthProvider(string displayName, Guid websiteId)
        {
            _providerName = displayName;
            _websiteId = websiteId;
        }
        [Category("OpenAuth")]
        [DisplayName("Client Key")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/ClientId", true)]
        [Description("Required. The client ID value from the provider application. It may also be referred to as an App ID or Consumer Key.")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="The Client Key value is required.")]
        public string ClientKey { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Client Secret")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/ClientSecret", true)]
        [Description("Required. The client secret value from the provider application. It may also be referred to as an App Secret or Consumer Secret.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Client Secret value is required.")]
        public string ClientSecret { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Authentication Type (Optional)")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/AuthenticationType")]
        [Description("The OWIN authentication middleware type. Example: yahoo. authenticationoptions.authenticationtype.")]
        public string AuthenticationType { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Scope (Optional)")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/Scope", ',')]
        [Description("A comma separated list of permissions to request. microsoftaccountauthenticationoptions.scope.")]
        public string[] Scope { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Caption")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/Caption")]
        [Description("The text that the user can display on a sign in user interface. microsoftaccountauthenticationoptions.caption.")]
        public string Caption { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Backchannel Timeout")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/BackchannelTimeout")]
        [Description("Timeout value in milliseconds for back channel communications. microsoftaccountauthenticationoptions.backchanneltimeout.")]
        public uint BackchannelTimeout { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Callback Path")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/CallbackPath")]
        [Description("The request path within the application's base path where the user-agent will be returned. microsoftaccountauthenticationoptions.callbackpath.")]
        public string CallbackPath { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Sign In As Authentication Type")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/SignInAsAuthenticationType")]
        [Description("The name of another authentication middleware which will be responsible for actually issuing auserClaimsIdentity. microsoftaccountauthenticationoptions.signinasauthenticationtype.")]
        public string SignInAsAuthenticationType { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Authentication Mode")]
        [SiteSettings(@"Authentication/OpenAuth/{Provider}/AuthenticationMode")]
        [Description("The OWIN authentication middleware mode. security.authenticationoptions.authenticationmode.")]
        public AuthenticationMode AuthenticationMode { get; set; }

        [Browsable(false)]
        internal string ProviderName { get=> _providerName; }

        /// <summary>
        /// Helper method to generate updates/inserts with the correct values
        /// </summary>
        /// <param name="currentSettings"></param>
        /// <returns></returns>
        public List<PendingChange> GetUpdateInserts(EntityCollection currentSettings) {

            var changesList = new List<PendingChange>();

            if (IsValid()) 
            {
                var props = GetType().GetProperties();
                WebSiteSettings.EvaluatePropertyList(currentSettings, props, this, "{Provider}", _providerName, _websiteId, ref changesList);
            }

            return changesList;
        }

        /// <summary>
        /// Helper method to update the correct attribute values 
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        public void LoadValue(string propName, string propValue) 
        {
            if (propName.ToLower().EndsWith("secret")) {
                ClientKey = propValue;
            }
            else {
                ClientSecret = propValue;
            }
        }

        public static List<OpenAuthProvider> LoadItems(EntityCollection entities, Guid websiteId)
        {
            // now handle the special auth cases
            var openAuthEnt = entities.Entities
                .Where(e => e["adx_name"].ToString().StartsWith("Authentication/OpenAuth/"))
                .Select(e => new {
                    name = e["adx_name"].ToString(),
                    value = (e.Attributes.ContainsKey("adx_value")) ? e["adx_value"].ToString() : null
                });

            var newItems = new List<OpenAuthProvider>();

            foreach (var ent in openAuthEnt)
            {
                var parts = ent.name.Split('/');
                var providerName = parts[2];

                var newItem = newItems.Where(a => a.ProviderName == providerName).FirstOrDefault();
                if (newItem == null) {
                    newItem = new OpenAuthProvider(providerName, websiteId);
                    newItems.Add(newItem);
                }
                // check the specifics for backwards compatibility
                var part = parts[3].ToLower();
                if (part.EndsWith("secret"))
                {
                    newItem.ClientSecret = ent.value;
                }
                else
                {
                    newItem.ClientKey = ent.value;
                }
            }

            return newItems;
        }

        /// <summary>
        /// Only valid if both the values are filled in
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            return (((ClientKey != null) && (ClientSecret != null)) ||
                ((ClientKey == null) && (ClientSecret == null)));
        }
        /// <summary>
        /// Helper for the display string in Property Grid
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ((ClientKey != null) && (ClientSecret != null))
            {
                return $"{ProviderName}: {ClientKey}, {ClientSecret}";

            }
            else if ((ClientKey != null) && (ClientSecret == null))
            {
                return $"{ProviderName}: {ClientKey}";
            }
            else {
                return $"{ProviderName}";
            }
        }
    }
}
