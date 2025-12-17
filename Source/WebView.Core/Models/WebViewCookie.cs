using System;
using System.Collections.Generic;
using System.Text;

namespace WebViewCore.Models;
public record WebViewCookie(string Name, string Value, string Domain, string Path);