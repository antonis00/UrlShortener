using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.DataServices;

public class UrlShortenerDataService : IUrlShortenerDataService
{
    private readonly UrlContext _context;

    public UrlShortenerDataService(UrlContext context)
    {
        _context = context;
    }

    public async Task AddUrlAsync(Url url)
    {
        _context.Urls.Add(url);
        await _context.SaveChangesAsync();
    }

    public async Task<Url?> GetLongUrlAsync(string shortUrl)
    {
        return await _context.Urls.AsNoTracking().FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);
    }
}
