using System;

namespace UrlShortener.Shared;

public class UrlHelper
{
    private const string _prefix = "https://abc.";
    private const string _postfix = ".com";

    public static string Strip(string url)
    {
        if (url.StartsWith(_prefix, StringComparison.OrdinalIgnoreCase))
        {
            url = url.Substring(_prefix.Length);
        }

        if (url.EndsWith(_postfix, StringComparison.OrdinalIgnoreCase))
        {
            url = url.Substring(0, url.Length - _postfix.Length);
        }


        return url;
    }
}
