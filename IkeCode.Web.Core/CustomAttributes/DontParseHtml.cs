using System;

namespace IkeCode.Web.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class DontParseHtml : Attribute
    {
    }
}
