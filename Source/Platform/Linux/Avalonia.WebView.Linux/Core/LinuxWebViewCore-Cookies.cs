using System;
using System.Collections.Generic;
using System.Text;

namespace Avalonia.WebView.Linux.Core;
public partial class LinuxWebViewCore
{

    public Task AddCookie(WebViewCookie cookie)
    {
        throw new NotImplementedException();
        //WebView.Context.CookieManager.SetProperty(cookie.Name,new GLib.Value(cookie.Value));
        //return Task.CompletedTask;

    }

    public Task<List<WebViewCookie>?> GetCookies(string url)
    {
        throw new NotImplementedException();
        WebView.Context.CookieManager.GetCookies(url);
        var a = WebView.Context.CookieManager.GetCookiesFinish(null);
        return Task.FromResult<List<WebViewCookie>?>(null);
    }

    public Task RemoveCookie(WebViewCookie cookie)
    {
        WebView.Context.CookieManager.DeleteCookiesForDomain(cookie.Domain);
        return Task.CompletedTask;
    }

    public Task ClearCookies()
    {
        WebView.Context.CookieManager.DeleteAllCookies();
        return Task.CompletedTask;
    }
}