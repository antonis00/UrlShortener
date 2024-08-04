using UrlShortener.Models;

namespace UrlShortener.Interfaces;

public interface IUrlShortenerDataService
{
    Task AddUrlAsync(Url url);
    Task<Url?> GetLongUrlAsync(string shortUrl);
}
