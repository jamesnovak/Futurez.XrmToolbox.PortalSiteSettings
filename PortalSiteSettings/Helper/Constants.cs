using System.ComponentModel;

namespace Futurez.XrmToolBox
{
    public enum AuthenticationMode
    {
        [Description("In Active mode the authentication middleware will alter the user identity as the request arrives, and will also alter a plain 401 as the response leaves.")]
        Active,
        [Description("In Passive mode the authentication middleware will only provide user identity when asked, and will only alter 401 responses where the authentication type named in the extra challenge data.")]
        Passive
    }

    public class Constants
    {
        public const string RegEx_URL = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})";
    }
}
