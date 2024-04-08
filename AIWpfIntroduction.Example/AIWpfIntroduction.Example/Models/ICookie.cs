using System;

namespace AIWpfIntroduction.Example.Models;

public interface ICookie
{
    public event EventHandler NowCookieChanged;

    public void UpdateNowCookie();
}
