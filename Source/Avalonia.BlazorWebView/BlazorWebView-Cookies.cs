using System;
using System.Collections.Generic;
using System.Text;
using WebViewCore.Models;

namespace AvaloniaBlazorWebView;
partial class BlazorWebView
{
    public Task AddCookie(WebViewCookie cookie)
    {
        if (_platformWebView is null || !_platformWebView.IsInitialized)
        {
            throw new InvalidOperationException("WebView is not initialized.");
        }

        return _platformWebView.AddCookie(cookie);
    }

    public Task<List<WebViewCookie>?> GetCookies(string url)
    {
        if (_platformWebView is null || !_platformWebView.IsInitialized)
        {
            throw new InvalidOperationException("WebView is not initialized.");
        }

        return _platformWebView.GetCookies(url);
    }

    public Task RemoveCookie(WebViewCookie cookie)
    {
        if (_platformWebView is null || !_platformWebView.IsInitialized)
        {
            throw new InvalidOperationException("WebView is not initialized.");
        }

        return _platformWebView.RemoveCookie(cookie);
    }

    public Task ClearCookies()
    {
        if (_platformWebView is null || !_platformWebView.IsInitialized)
        {
            throw new InvalidOperationException("WebView is not initialized.");
        }

        return _platformWebView.ClearCookies();
    }
}
