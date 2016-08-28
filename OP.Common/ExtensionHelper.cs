using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OP.Common
{
    public static class ExtensionHelper
    {
        public static TagBuilder MergeAttributeEx(this TagBuilder tb, string key, string value)
        {
            tb.MergeAttribute(key, value);
            return tb;
        }

        public static TagBuilder AddCssClassEx(this TagBuilder tb, string value)
        {
            tb.AddCssClass(value);
            return tb;
        }

        public static TagBuilder InnerHtmlEx(this TagBuilder tb, object html)
        {
             tb.InnerHtml += html.ToString();
            return tb;
        }
    }
}
