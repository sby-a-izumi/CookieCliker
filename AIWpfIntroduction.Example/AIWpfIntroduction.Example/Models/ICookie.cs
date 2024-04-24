using System;

namespace AIWpfIntroduction.Example.Models;

public interface ICookie
{
    public event EventHandler NowCookieChanged;

  int NowCookie { get; set; }
  int IncCookie { get; set; }
  int NowAdd { get; set; }
  int NowMul { get; set; }
  int NowSec { get; set; }
  int NowInt { get; set; }
  int CostAdd { get; set; }
  int CostMul { get; set; }
  int CostSec { get; set; }
  int CostInt { get; set; }

  void UpdateNowCookie();
  void UpdateIncCookie();
  void OnAdd();
  void OnMul();
  void OnSec();
  void OnInt();

  void AddCookiePerSecond();

}
