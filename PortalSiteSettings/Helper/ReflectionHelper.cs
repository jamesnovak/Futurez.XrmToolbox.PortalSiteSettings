using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.XrmToolBox
{
    public class ReflectionHelper
    {
        /// <summary>
        /// Helper method that will set the property value using reflection on the target object
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propName"></param>
        /// <param name="propVal"></param>
        public static void SetSiteSettingsValue(object target, string propName, string propVal) {
            var prop = target
                .GetType()
                .GetProperties()
                .Where(p => p.Name.ToLower() == propName.ToLower())
                .FirstOrDefault();

            var attrib = prop
                .GetCustomAttributes(true)
                .Where(a => a is SiteSettingsAttribute)
                .FirstOrDefault()
                as SiteSettingsAttribute;

            SetSiteSettingsValue(target, prop, attrib, propVal);

        }

        /// <summary>
        /// Helper method that will set the property value using reflection on the target object
        /// </summary>
        /// <param name="target"></param>
        /// <param name="prop"></param>
        /// <param name="attrib"></param>
        /// <param name="propVal"></param>
        public static void SetSiteSettingsValue(object target, PropertyInfo prop, SiteSettingsAttribute attrib, string propVal)
        {
            if (prop.PropertyType.IsArray)
            {
                prop.SetValue(target, propVal.Split(attrib.ValueDelimiter));
            }
            else
            {
                var t = prop.PropertyType.UnderlyingSystemType;
                switch (t.Name)
                {
                    case "String":
                        prop.SetValue(target, propVal);
                        break;
                    case "Boolean":
                        if (bool.TryParse(propVal, out bool newBool))
                        {
                            prop.SetValue(target, newBool);
                        }
                        break;
                    case "Int32":
                        if (int.TryParse(propVal, out int newInt))
                        {
                            prop.SetValue(target, newInt);
                        }
                        break;
                    case "TimeSpan":
                        if (TimeSpan.TryParse(propVal, out TimeSpan newTS))
                        {
                            prop.SetValue(target, newTS);
                        }
                        break;
                    case @"Nullable`1":
                        if (t.FullName.Contains("System.Boolean"))
                        {
                            if (bool.TryParse(propVal, out bool nilBool))
                            {
                                prop.SetValue(target, nilBool);
                            }
                        }
                        else if (t.FullName.Contains("System.Int32"))
                        {
                            if (int.TryParse(propVal, out int nilInt))
                            {
                                prop.SetValue(target, nilInt);
                            }
                        }
                        else if (t.FullName.Contains("System.TimeSpan"))
                        {
                            if (TimeSpan.TryParse(propVal, out TimeSpan nilTS))
                            {
                                prop.SetValue(target, nilTS);
                            }
                        }
                        break;
                }
            }
        }
    }
}
