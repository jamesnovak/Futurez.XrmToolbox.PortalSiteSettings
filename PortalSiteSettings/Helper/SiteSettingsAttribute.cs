using System;

namespace Futurez.XrmToolBox
{
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
        public SiteSettingsAttribute(string NameFormat, bool isRequired = false)
        {
            this.NameFormat = NameFormat;
            this.IsRequired = isRequired;
        }

        public string NameFormat { get; set; }
        public char ValueDelimiter { get; set; }
        public bool IsRequired { get; set; } = false;

    }
}
