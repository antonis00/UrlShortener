using UrlShortener.Interfaces;
using UrlShortener.Models;
using UrlShortener.Shared;

namespace UrlShortener.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private const int RandomBytesLength = 3;
    private readonly IUrlShortenerDataService _urlShortenerDataService;

    public UrlShortenerService(IUrlShortenerDataService urlShortenerDataService)
    {
        _urlShortenerDataService = urlShortenerDataService;
    }

    public async Task<Result<Url>> GetUrlAsync(string shortUrl)
    {
        Url? url = await _urlShortenerDataService.GetLongUrlAsync(UrlHelper.Strip(shortUrl));

        if (url is null) { return Result<Url>.Failure("Short URL not found!"); }

        return Result<Url>.Success(url);
    }

    public async Task<Result<Url>> ShortenUrlAsync(string longUrl)
    {
        if (IsInvalid(longUrl)) { return Result<Url>.Failure("Invalid URL!"); }

        Url shortenedUrl = EncodeUrl(longUrl);

        await _urlShortenerDataService.AddUrlAsync(shortenedUrl);

        return Result<Url>.Success(shortenedUrl);
    }

    #region private methods

    private Url EncodeUrl(string longUrl)
    {
        var guid = Guid.NewGuid();
        return new Url { OriginalUrl = longUrl, ShortUrl = Base62Encode(guid) };
    }

    private string Base62Encode(Guid guid)
    {
        const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var bytes = guid.ToByteArray();
        ulong intData = BitConverter.ToUInt64(bytes, 0) ^ BitConverter.ToUInt64(bytes, 8);
        var result = new List<char>();

        while (intData > 0)
        {
            result.Insert(0, chars[(int)(intData % 62)]);
            intData /= 62;
        }

        return new string(result.ToArray());
    }

    private bool IsInvalid(string url)
    {
        if (Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) &&
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            return false;
        }
        return true;
    }

    #endregion

}
