
using System;

namespace ROMZOOM.Logic
{
    public static class HtmlCodeImageUrlExtractor
    {
        public static string Extract(string data)
        {
            int start = data.IndexOf("src=\"", StringComparison.Ordinal) + 5;

            return data.Substring(start, data.IndexOf("\"", start, StringComparison.Ordinal) - start);
        }
    }
}
