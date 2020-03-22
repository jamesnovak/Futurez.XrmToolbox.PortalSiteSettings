using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Futurez.XrmToolBox
{
    public class ValidatorHelper
    {
        /// <summary>
        /// Helper method that will perform validation using the attributes on the fields
        /// </summary>
        /// <returns></returns>
        public List<string> Validate()
        {
            var messages = new List<string>();

            var props = this.GetType().GetProperties();

            foreach (var prop in props)
            {
                var msg = ValidateProperty(prop, this);
                if (msg.Count > 0) {
                    messages = messages.Concat(msg).ToList();
                }
            }

            return messages;
        }

        /// <summary>
        /// Check for any validator attributes, such as Required
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<string> ValidateProperty(PropertyInfo prop, object target) {

            var messages = new List<string>();

            var valAttribs = prop
                .GetCustomAttributes(true)
                .Where(a => a is ValidationAttribute);
            if (valAttribs != null)
            {
                var val = prop.GetValue(target);
                foreach (ValidationAttribute attrib in valAttribs)
                {
                    if (!attrib.IsValid(val))
                    {
                        messages.Add($"{prop.Name}: {attrib.ErrorMessage}");
                    }
                }
            }
            return messages;
        }
    }
}
