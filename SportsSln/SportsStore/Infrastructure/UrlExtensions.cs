using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;

namespace SportsStore.Infrastructure
{
    /// <summary>
    /// The PathAndQuery extension method operates on the HttpRequest class, which .Net Core uses
    /// to describe an Http request. The extension method generates a URL that the browser will be 
    /// returned to after the cart has been updated, taking into account the query string, if there is one.
    /// </summary>
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
    }
}
