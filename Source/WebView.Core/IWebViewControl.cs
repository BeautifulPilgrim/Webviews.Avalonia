using WebViewCore.Models;

namespace WebViewCore;
public interface IWebViewControl
{
    bool IsCanGoForward { get; }
    bool IsCanGoBack { get; }

    bool Navigate(Uri? uri);
    bool NavigateToString(string htmlContent);

    bool GoBack();
    bool GoForward();
    bool Stop();
    bool Reload();

    Task<string?> ExecuteScriptAsync(string javaScript);

    bool PostWebMessageAsJson(string webMessageAsJson, Uri? baseUri);
    bool PostWebMessageAsString(string webMessageAsString, Uri? baseUri);

    bool OpenDevToolsWindow();
    #region Cookies

    Task AddCookie(WebViewCookie cookie);
    Task<List<WebViewCookie>?> GetCookies(string url);
    Task RemoveCookie(WebViewCookie cookie);
    Task ClearCookies();

    #endregion
}
