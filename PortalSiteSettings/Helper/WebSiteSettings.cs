using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.XrmToolBox
{
    public class WebSiteSettings // : INotifyPropertyChanged
    {
        internal Guid _websiteId = Guid.Empty;

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        public WebSiteSettings(Guid websiteId)
        {
            _websiteId = websiteId;
            Microsoft = new OpenAuthProvider("Micrsoft", "Authentication/OpenAuth/Microsoft/ClientId", "Authentication/OpenAuth/Microsoft/ClientSecret", _websiteId);
            Facebook = new OpenAuthProvider("Facebook", "Authentication/OpenAuth/Facebook/AppId", "Authentication/OpenAuth/Facebook/AppSecret", _websiteId);
            Twitter = new OpenAuthProvider("Twitter", "Authentication/OpenAuth/Twitter/ConsumerKey", "Authentication/OpenAuth/Twitter/ConsumerSecret", _websiteId);
            LinkedIn = new OpenAuthProvider("LinkedIn", "Authentication/OpenAuth/LinkedIn/ConsumerKey", "Authentication/OpenAuth/LinkedIn/ConsumerSecret", _websiteId);
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
        public bool SearchEnabled { get; set; }
        //{
        //    get { return _searchEnabled; }
        //    set {
        //        if (value != _searchEnabled) {
        //            _searchEnabled = value;
        //            NotifyPropertyChanged();
        //        }
        //    }
        //}

        [Category("Search")]
        [DisplayName("Faceted View")]
        [Description("Enable Faceted View?")]
        [SiteSettings(@"Search/FacetedView")]
        public bool FacetedView { get; set; } = true;

        [Category("Search")]
        [DisplayName("Index Notes Attachments")]
        [Description("Index Notes Attachments?")]
        [SiteSettings(@"Search/IndexNotesAttachments")]
        public bool IndexNotesAttachments { get; set; }

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
        public string BingmapsRestURL { get; set; }
        #endregion

        #region Other
        [Category("Customer Support")]
        [DisplayName("Display User Activities")]
        [Description("Display All User Activities On Timeline?")]
        [SiteSettings(@"CustomerSupport/DisplayAllUserActivitiesOnTimeline")]
        public bool DisplayUserActivities { get; set; } = false;

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
        public bool DisplayLanguageCodeInURL { get; set; } = false;

        [Category("Multi Language")]
        [DisplayName("Maximum Depth To Clone")]
        [Description("Maximum Depth To Clone")]
        [SiteSettings(@"MultiLanguage/MaximumDepthToClone")]
        public int MaximumDepthToClone { get; set; } = 3;
        #endregion

        #region Header/Footer
        [Category("Header/Footer")]
        [DisplayName("Footer Output Cache Enabled")]
        [Description("Enable Footer Output Cache?")]
        [SiteSettings(@"Footer/OutputCache/Enabled")]
        public bool FooterOutputCacheEnabled { get; set; } = true;

        [Category("Header/Footer")]
        [DisplayName("Header Output Cache Enabled")]
        [Description("Enable Header Output Cache?")]
        [SiteSettings(@"Header/OutputCache/Enabled")]
        public bool HeaderOutputCacheEnabled { get; set; } = true;

        #endregion

        #region Profile
        [Category("Profile")]
        [DisplayName("Force Signup")]
        [Description("Force Signup for Portal users?")]
        [SiteSettings(@"Profile/ForceSignUp")]
        public bool ForceSignUp { get; set; } = false;

        [Category("Profile")]
        [DisplayName("Show Marketing Options")]
        [Description("Show Marketing Options Panel")]
        [SiteSettings(@"Profile/ShowMarketingOptionsPanel")]
        public bool ShowMarketingOptionsPanel { get; set; } = true;
        #endregion

        #region Authenticaton
        #region Registration
        [Category("Authenticaton/Registration")]
        [DisplayName("AzureAD Login Enabled")]
        [Description("Enable AzureAD Login?")]
        [SiteSettings(@"Authentication/Registration/AzureADLoginEnabled")]
        public bool AzureADLoginEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Deny Minors")]
        [Description("Deny Minors?")]
        [SiteSettings(@"Authentication/Registration/DenyMinors")]
        public bool DenyMinors { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Deny Minors Without Parental Consent")]
        [Description("Deny Minors Without Parental Consent?")]
        [SiteSettings(@"Authentication/Registration/DenyMinorsWithoutParentalConsent")]
        public bool DenyMinorsWithoutParentalConsent { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Email Confirmation Enabled")]
        [Description("Enable Email Confirmation?")]
        [SiteSettings(@"Authentication/Registration/EmailConfirmationEnabled")]
        public bool EmailConfirmationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Registration Enabled")]
        [Description("Enables or disables all forms of user registration. Registration must be enabled for the other settings in this section to take effect. Default: true")]
        [SiteSettings(@"Authentication/Registration/Enabled")]
        public bool RegistrationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("External Login Enabled")]
        [Description("Enables or disables external account sign-in and registration. Default: true")]
        [SiteSettings(@"Authentication/Registration/ExternalLoginEnabled")]
        public bool ExternalLoginEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Invitation Enabled")]
        [Description("Enables or disables the sign-up registration form for creating new local users. The sign-up form allows any anonymous visitor to the portal to create a new user account. Default: true")]
        [SiteSettings(@"Authentication/Registration/InvitationEnabled")]
        public bool InvitationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Local Login Deprecated")]
        [Description("Disable Local Login for Users")]
        [SiteSettings(@"Authentication/Registration/LocalLoginDeprecated")]
        public bool LocalLoginDeprecated { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Local Login Enabled")]
        [Description("Enables or disables local account sign-in based on a username (or email) and password. Default: false")]
        [SiteSettings(@"Authentication/Registration/LocalLoginEnabled")]
        public bool LocalLoginEnabled { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Login Button Auth Type")]
        [Description("If a portal only requires a single external identity provider (to handle all authentication), this allows the Sign-In button of the header nav bar to link directly to the sign-in page of that external identity provider")]
        [SiteSettings(@"Authentication/Registration/LoginButtonAuthenticationType")]
        public string LoginButtonAuthenticationType { get; set; } = "";

        [Category("Authenticaton/Registration")]
        [DisplayName("Open Registration Enabled")]
        [Description("Enables or disables the sign-up registration form for creating new local users. The sign-up form allows any anonymous visitor to the portal to create a new user account. Default: true")]
        [SiteSettings(@"Authentication/Registration/OpenRegistrationEnabled")]
        public bool OpenRegistrationEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Profile Redirect Enabled")]
        [Description("Profile Redirect Enabled")]
        [SiteSettings(@"Authentication/Registration/ProfileRedirectEnabled")]
        public bool ProfileRedirectEnabled { get; set; } = true;

        [Category("Authenticaton/Registration")]
        [DisplayName("Terms Agreement Enabled")]
        [Description("Terms Agreement Enabled")]
        [SiteSettings(@"Authentication/Registration/TermsAgreementEnabled")]
        public bool TermsAgreementEnabled { get; set; } = false;

        [Category("Authenticaton/Registration")]
        [DisplayName("Captcha Enabled")]
        [Description("Enables or disables captcha on the user registration page. Default: false")]
        [SiteSettings(@"Authentication/Registration/CaptchaEnabled")]
        public bool CaptchaEnabled { get; set; } = false;
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
        public int MaxInvaildAttemptsFromIPAddress { get; set; } = 1000;
        

        [Category("Authenticaton/Login")]
        [DisplayName("Login Tracking Enabled")]
        [Description("Login Tracking Enabled")]
        [SiteSettings(@"Authentication/LoginTrackingEnabled")]
        public bool LoginTrackingEnabled { get; set; } = false;
        #endregion

        #region OpenAuth
        [Category("Authenticaton/OpenAuth")]
        [DisplayName("Microsoft OpenAuth")]
        [Description("Microsoft OpenAuth Provider details")]
        public OpenAuthProvider Microsoft { get; set; } 
        [Category("Authenticaton/OpenAuth")]
        [DisplayName("Facebook OpenAuth")]
        [Description("Facebook OpenAuth Provider details")]
        public OpenAuthProvider Facebook { get; set; }

        [Category("Authenticaton/OpenAuth")]
        [DisplayName("Twitter OpenAuth")]
        [Description("Twitter OpenAuth Provider details")]
        public OpenAuthProvider Twitter { get; set; } 

        [Category("Authenticaton/OpenAuth")]
        [DisplayName("LinkedIn OpenAuth")]
        [Description("LinkedIn OpenAuth Provider details")]
        public OpenAuthProvider LinkedIn { get; set; } 
        #endregion

        [Category("Authenticaton/OpenIdConnect")]
        [DisplayName("Open ID Connect Providers")]
        [Description("Collection of OpenId Connect Identity Providers")]
        public OpenIdConnect[] OpenIdConnectProviders { get; set; } = new OpenIdConnect[0];
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
                var attrib = prop.GetCustomAttributes(true)
                    .Where(a => a is SiteSettingsAttribute)
                    .FirstOrDefault() as SiteSettingsAttribute;

                if (attrib != null)
                {
                    // get the name from the attribute
                    var name = attrib.NameFormat;

                    // find correct Name from the entity collection 
                    var setting = entities.Entities.Where(e => e["adx_name"].ToString() == name).FirstOrDefault();

                    if (setting != null && setting.Attributes.ContainsKey("adx_value"))
                    {
                        var entVal = setting["adx_value"].ToString();
                        if (prop.PropertyType.IsArray) {
                            prop.SetValue(this, entVal.Split(attrib.ValueDelimiter));
                        }
                        else {
                            switch (prop.PropertyType.UnderlyingSystemType.Name)
                            {
                                case "String":
                                    prop.SetValue(this, entVal);
                                    break;
                                case "Boolean":
                                    if (bool.TryParse(entVal, out bool newBool)) {
                                        prop.SetValue(this, newBool);
                                    }
                                    break;
                                case "Int32":
                                    if (int.TryParse(entVal, out int newInt)) {
                                        prop.SetValue(this, newInt);
                                    }
                                    break;
                                case "TimeSpan":
                                    if (TimeSpan.TryParse(entVal, out TimeSpan newTS)) {
                                        prop.SetValue(this, newTS);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Open Auth Values
            // now handle the special auth cases
            var openAuthEnt = entities.Entities
                .Where(e => e["adx_name"].ToString().StartsWith("Authentication/OpenAuth/"))
                .Select( e => new {
                    name = e["adx_name"].ToString(),
                    value = (e.Attributes.ContainsKey("adx_value")) ? e["adx_value"].ToString(): null
                });

            foreach (var ent in openAuthEnt) {
                var parts = ent.name.Split('/');
                switch (parts[2]) {
                    case "Facebook":
                        if (parts[3] == "AppId") {
                            Facebook.ClientKey = ent.value;
                        }
                        else {
                            Facebook.ClientSecret = ent.value;
                        }
                        break;
                    case "LinkedIn":
                        if (parts[3] == "ConsumerKey") {
                            LinkedIn.ClientKey = ent.value;
                        }
                        else {
                            LinkedIn.ClientSecret = ent.value;
                        }
                        break;
                    case "Microsoft":
                        if (parts[3] == "ClientId") {
                            Microsoft.ClientKey = ent.value;
                        }
                        else {
                            Microsoft.ClientSecret = ent.value;
                        }
                        break;
                    case "Twitter":
                        if (parts[3] == "ConsumerKey") {
                            Twitter.ClientKey = ent.value;
                        }
                        else {
                            Twitter.ClientSecret = ent.value;
                        }
                        break;
                }
            }
            #endregion

            #region OpenId Connect Values
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

                if (openIdItem == null) {
                    openIdItem = new OpenIdConnect(_websiteId) {
                        FederatedName = fedName
                    };
                    items.Add(openIdItem);
                }

                switch (parts[3]) {
                    case "Authority":
                        openIdItem.Authority = ent.value;
                        break;
	                case "ClientId":
                        openIdItem.ClientID = ent.value;
                        break;
                    case "DefaultPolicyId":
                        openIdItem.DefaultPolicyId = ent.value;
                        break;
                    case "ExternalLogoutEnabled":
                        if (bool.TryParse(ent.value, out var newBool)) {
                            openIdItem.ExternalLogoutEnabled = newBool;
                        }
                        break;
                    case "PasswordResetPolicyId":
                        openIdItem.PasswordResetPolicyId = ent.value;
                        break;
                    case "RedirectUri":
                        openIdItem.RedirectUri = ent.value;
                        break;
                    case "ValidIssuers":
                        openIdItem.ValidIssuers = ent.value?.Split(',');
                        break;
                }
            }

            // now add the items back to the prop as an array for the prop grid 
            OpenIdConnectProviders = items.ToArray();

            #endregion
        }

        public void ValidateSettings() {
            // check for any errors 
        }

        // List<SiteSettingEdit> 
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
            var items = Facebook.GetUpdateInserts(currentSettings);
            if (items.Count > 0) {
                changesList.AddRange(items);
            }
            items = Microsoft.GetUpdateInserts(currentSettings);
            if (items.Count > 0) {
                changesList.AddRange(items);
            }
            items = Twitter.GetUpdateInserts(currentSettings);
            if (items.Count > 0) {
                changesList.AddRange(items);
            }
            items = LinkedIn.GetUpdateInserts(currentSettings);
            if (items.Count > 0) { 
                changesList.AddRange(items);
            }
            
            // now for the OpenID Connect settings
            foreach (var openId in OpenIdConnectProviders)
            {
                props = openId.GetType().GetProperties();
                foreach (var prop in props)
                {
                    // special case here since we need to update the name 
                    var attrib = prop
                        .GetCustomAttributes(true)
                        .Where(a => a is SiteSettingsAttribute)
                        .FirstOrDefault() as SiteSettingsAttribute;

                    if (attrib != null)
                    {
                        var newVal = prop.GetValue(openId);

                        var ignoreCase = newVal is bool;
                        var newValString = GetPropertyString(prop, newVal, attrib);
                        var name = attrib.NameFormat.Replace("{FederatedName}", openId.FederatedName);
                        var entUpdate = CheckAttributeValue(currentSettings, name, newValString, _websiteId, ignoreCase);

                        if (entUpdate != null) {
                            changesList.Add(entUpdate);
                        }
                    }
                }
            }

            return changesList;
        }
        #endregion

        #region Helper methods
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
                var ignoreCase = newVal is bool;
                newValString = GetPropertyString(prop, newVal, attrib);

                entUpdate = CheckAttributeValue(currentSettings, attrib.NameFormat, newValString, websiteId, ignoreCase);
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
        public static PendingChange CheckAttributeValue(EntityCollection currentSettings, string settingName, string newValue, Guid websiteId, bool ignoreCase = false)
        {
            string currVal = null;
            Entity entity = null;

            // find the current record with the same name and check its value 
            var entRec = currentSettings.Entities
                .Where(e => e["adx_name"].ToString() == settingName)
                .FirstOrDefault();

            if (entRec != null)
            {
                if (entRec.Attributes.ContainsKey("adx_value")) {
                    currVal = entRec["adx_value"].ToString();
                }
                // we have current record, update it if the values have changed
                var valsDiffer = false;

                // ignore case for some, like booleans
                if (ignoreCase) {
                    valsDiffer = (currVal?.ToLower() != newValue?.ToLower());
                }
                else {
                    valsDiffer = (currVal != newValue);
                }
                // if different, update current record 
                if (valsDiffer) {
                    var updateRec = new Entity("adx_sitesetting") {
                        Id = entRec.Id,
                        EntityState = EntityState.Changed
                    };
                    entity = updateRec;
                }
            }
            else
            {
                // no existing record, create it 
                var newRec = new Entity("adx_sitesetting") {
                    EntityState = EntityState.Created
                };
                entity = newRec;
            }

            if (entity != null)
            {
                entity.Attributes["adx_value"] = newValue;
                entity.Attributes["adx_name"] = settingName;
                entity.Attributes["adx_websiteid"] = new EntityReference("adx_website", websiteId);
                return new PendingChange()
                {
                    Entity = entity,
                    Action = entity.EntityState.ToString(),
                    NewValue = newValue,
                    OldValue = currVal
                };
            }
            else {
                return null;
            }
        }
        #endregion
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class OpenAuthProvider
    {
        private string _displayName = "";
        private Guid _websiteId = Guid.Empty;

        internal OpenAuthProvider(string displayName, string keyName, string secretName, Guid websiteId)
        {
            _displayName = displayName;
            ClientKeyName = keyName;
            ClientSecretName = secretName;
            _websiteId = websiteId;
        }
        [Category("OpenAuth")]
        [DisplayName("Key, Client/App Id")]
        [Description("The Client or Consumer id for this provider")]
        public string ClientKey { get; set; }

        [Category("OpenAuth")]
        [DisplayName("Secret")]
        [Description("The Client or Consumer Secret for this provider")]
        public string ClientSecret { get; set; }

        [Browsable(false)]
        public string ClientKeyName { get; set; }

        [Browsable(false)]
        public string ClientSecretName { get; set; }

        public List<PendingChange> GetUpdateInserts(EntityCollection currentSettings) {

            var items = new List<PendingChange>();

            if (IsValid()) {
                var ent = WebSiteSettings.CheckAttributeValue(currentSettings, ClientKeyName, ClientKey, _websiteId);
                if (ent != null) {
                    items.Add(ent);
                }
                ent = WebSiteSettings.CheckAttributeValue(currentSettings, ClientSecretName, ClientSecret, _websiteId);
                if (ent != null) {
                    items.Add(ent);
                }
            }

            return items;
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
                return $"{_displayName}: {ClientKey}, {ClientSecret}";

            }
            else if ((ClientKey != null) && (ClientSecret == null))
            {
                return $"{_displayName}: {ClientKey}";
            }
            else {
                return $"{_displayName}";
            }
        }
    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class OpenIdConnect
    {
        private string _federatedName = "New OpenID Connect";
        private Guid _websiteId = Guid.Empty;
        public OpenIdConnect() {
        }
        public OpenIdConnect(Guid websiteId): this()
        {
            _websiteId = websiteId;
        }

        [Category("OpenIdConnect")]
        [DisplayName("Federated Name")]
        [Description("The Federated Name used when setting up OpenId Connect Identity Provider")]
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
        public string Authority { get; set; }
        
        [Category("OpenIdConnect")]
        [DisplayName("Client ID")]
        [Description("Client/Application Id")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/ClientId")]
        public string ClientID { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Default Policy Id")]
        [Description("Default Policy Id")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/DefaultPolicyId")]
        public string DefaultPolicyId { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("External Logout Enabled")]
        [Description("Enable External Logout?")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/ExternalLogoutEnabled")]
        public bool ExternalLogoutEnabled { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Password Reset Policy Id")]
        [Description("Password Reset Policy Id")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/PasswordResetPolicyId")]
        public string PasswordResetPolicyId { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Redirect Uri")]
        [Description("Redirect Uri")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/RedirectUri")]
        public string RedirectUri { get; set; }

        [Category("OpenIdConnect")]
        [DisplayName("Valid Issuers")]
        [Description("List of Valid Issuers, one per line")]
        [SiteSettings(@"Authentication/OpenIdConnect/{FederatedName}/ValidIssuers", ',')]
        public string[] ValidIssuers { get; set; }

        public bool IsValid() {
            return true;
        }

        public override string ToString()
        {
            return FederatedName;
        }
    }

    /// <summary>
    /// Helper class to decorate attributes with the Site Setting Name value 
    /// </summary>
    public class SiteSettingsAttribute : Attribute
    {
        public SiteSettingsAttribute(string NameFormat, char ValueDelimiter)
        {
            this.NameFormat = NameFormat;
            this.ValueDelimiter = ValueDelimiter;
        }
        public SiteSettingsAttribute(string NameFormat)
        {
            this.NameFormat = NameFormat;
        }

        public string NameFormat { get; set; }
        public char ValueDelimiter { get; set; }
    }
}

/// <summary>
/// Helper class to report back which values have changed
/// </summary>
public class PendingChange
{
    public string Action { get; set; }
    public Entity Entity { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
}