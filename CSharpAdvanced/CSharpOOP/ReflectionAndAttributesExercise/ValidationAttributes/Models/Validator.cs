using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<Attribute> propertyCustomAttributes = property
                    .GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in propertyCustomAttributes)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
