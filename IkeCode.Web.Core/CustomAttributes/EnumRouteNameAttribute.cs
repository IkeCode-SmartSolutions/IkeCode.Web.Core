using System;
using System.Linq;
using System.Reflection;

namespace IkeCode.Web.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class EnumRouteNameAttribute : Attribute
    {
        readonly string routeName;

        public EnumRouteNameAttribute(string routeName)
        {
            this.routeName = routeName;
        }

        public string RouteName
        {
            get { return routeName; }
        }
    }

    public static class EnumRouteNameAttributeHelper
    {
        public static T GetEnumRouteNameAttribute<T>(this string attributeRouteName)
            where T : struct
        {
            var type = typeof(T);
            
            var memInfo = type.GetMembers(BindingFlags.Public | BindingFlags.Static);
            T result = default(T);

            if (memInfo != null)
            {
                memInfo.ToList().ForEach(i =>
                {
                    if (i.DeclaringType.Name == type.Name)
                    {
                        var attrs = i.GetCustomAttributes<EnumRouteNameAttribute>(false);
                        if (attrs.Any(j => j.RouteName == attributeRouteName))
                        {
                            result = (T)Enum.Parse(typeof(T), i.Name);
                        }
                    }
                });
            }

            return result;
        }

        public static string GetEnumRouteNameAttributeValue<T>(this T enumValue)
            where T : struct
        {
            var type = typeof(T);

            var memInfo = type.GetMember(enumValue.ToString());            
            var result = string.Empty;

            if (memInfo != null)
            {
                memInfo.ToList().ForEach(i =>
                {
                    if (i.DeclaringType.Name == type.Name)
                    {
                        var attr = i.GetCustomAttributes<EnumRouteNameAttribute>(false).FirstOrDefault();
                        if (attr != null)
                        {
                            result = attr.RouteName;
                        }
                    }
                });
            }

            return result;
        }
    }
}
