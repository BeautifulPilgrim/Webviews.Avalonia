using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.WebView.iOS.Core;
public partial class IosWebViewCore : IPlatformWebView<IosWebViewCore>
{
    public Task AddCookie(WebViewCookie cookie)
    {
        var tcs = new TaskCompletionSource<bool>();

        WebView.Configuration.WebsiteDataStore.HttpCookieStore.SetCookie(new NSHttpCookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain),
            () =>
            {
                tcs.SetResult(true);
            });
        return tcs.Task;
    }

    public async Task<List<WebViewCookie>?> GetCookies(string url)
    {
        var cookies = await WebView.Configuration.WebsiteDataStore.HttpCookieStore.GetAllCookiesAsync();

        if (cookies.Length == 0)
            return null;

        return cookies.Select(cookie => new WebViewCookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain)).ToList();
    }

    public Task RemoveCookie(WebViewCookie cookie)
    {
        var tcs = new TaskCompletionSource<bool>();

        WebView.Configuration.WebsiteDataStore.HttpCookieStore.DeleteCookie(new NSHttpCookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain),
            () =>
            {
                tcs.SetResult(true);
            });
        return tcs.Task;
    }

    public Task ClearCookies()
    {
        var tcs = new TaskCompletionSource<bool>();

        WebView.Configuration.WebsiteDataStore.HttpCookieStore.GetAllCookies(cookies =>
        {
            foreach (var cookie in cookies)
            {
                WebView.Configuration.WebsiteDataStore.HttpCookieStore.DeleteCookie(cookie, () => { });
            }
            tcs.SetResult(true);
        });

        return tcs.Task;
    }
}