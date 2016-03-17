using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IkeCode.Web.Core.CustomAttributes.Helpers
{
    public static class EnumDisplayAttributeHelper
    {
        public static string GetDisplayName<T>(this T value)
            where T : struct
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptionAttributes = fieldInfo.GetCustomAttributes<DisplayAttribute>(false) as DisplayAttribute[];
            
            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}
