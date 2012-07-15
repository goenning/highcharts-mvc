using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace System.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static bool ContainsAttribute<T>(this PropertyInfo property) where T : Attribute
        {
            return property.GetCustomAttributes(false).Any(a => a.GetType().Equals(typeof(T)));
        }
    }
}
