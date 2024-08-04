using System.Text;

namespace UrlShortener.Shared;

public static class Base62Converter
{
    private const string Characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Encode(long number)
    {
        if (number == 0) return Characters[0].ToString();

        var encoded = new StringBuilder();
        while (number > 0)
        {
            encoded.Insert(0, Characters[(int)(number % 62)]);
            number /= 62;
        }
        return encoded.ToString();
    }
}
