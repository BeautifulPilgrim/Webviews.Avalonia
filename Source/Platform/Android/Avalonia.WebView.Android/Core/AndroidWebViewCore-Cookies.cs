using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.WebView.Android.Core;
public partial class AndroidWebViewCore : IPlatformWebView<AndroidWebViewCore>
{
    public Task AddCookie(WebViewCookie cookie)
    {
        CookieManager.Instance?.SetCookie(cookie.Domain, $"{cookie.Name}={cookie.Value}; Path={cookie.Path}");
        return Task.CompletedTask;
    }

    public Task RemoveCookie(WebViewCookie cookie)
    {
        CookieManager.Instance?.SetCookie(cookie.Domain, $"{cookie.Name}=; Path={cookie.Path}");
        return Task.CompletedTask;
    }

    public Task ClearCookies()
    {
        CookieManager.Instance?.RemoveAllCookies(null);
        return Task.CompletedTask;
    }

    public Task<List<WebViewCookie>?> GetCookies(String url)
    {
        throw new NotImplementedException();
        var res = CookieManager.Instance?.GetCookie(url);
        return Task.FromResult(new List<WebViewCookie>());
    }
}