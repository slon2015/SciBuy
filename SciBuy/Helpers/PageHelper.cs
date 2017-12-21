using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace SciBuy.Helpers
{
    public  static class PageHelper
    {
        public static string GetExcerpt(string content, int length)
        {
            string cleanstr = CleanHtmlTags(content);
            if (cleanstr.Length < length)
                return cleanstr;
            return cleanstr.Substring(0, length)+"...";
        }
        public static string CleanHtmlTags(string content)
        {
            return Regex.Replace(content, "<.*?>", string.Empty).Replace("&nbsp;", string.Empty);
        }
    }
}