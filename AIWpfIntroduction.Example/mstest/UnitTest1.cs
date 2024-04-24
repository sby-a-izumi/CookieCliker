using AIWpfIntroduction.Example.Models;
using AIWpfIntroduction.Example.ViewModels;
using Moq;

namespace mstest
{
  [TestClass]
  public class UnitTest1
  {
    /// <summary>
    /// Timerのテスト
    /// </summary>
    



    #region Cookieクラスのテスト

    /// <summary>
    /// UpdateNowCookie -> RaiseNowCookieChangedメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T000_UpdateNowCookieでイベントが発生することを確認()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;

      cookie.UpdateNowCookie();

      Assert.IsTrue(isCalled);
    }
    /// <summary>
    /// UpdateNowCookieメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T001_UpdateNowCookieで値がインクリメントすることを確認()
    {
      var cookie = new Cookie();
      cookie.NowCookie = 0;
      cookie.IncCookie = 1;
      cookie.UpdateNowCookie();
      Assert.AreEqual(cookie.NowCookie, 1);
    }

    /// <summary>
    /// UpdateIncCookieメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T002_UpdateIncCookieでIncCookieの値が更新されることを確認()
    {
      var cookie = new Cookie();
      cookie.IncCookie = 2;
      cookie.NowAdd = 3;
      cookie.NowMul = 4;
      cookie.UpdateIncCookie();
      Assert.AreEqual(cookie.IncCookie, 16);
    }

    /// <summary>
    /// OnAdd -> RaiseNowCookieChangedメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T003_OnAddでイベントが発生することを確認()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnAdd();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnAdd -> UpdateIncCookieメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T004_OnAddとUpdateIncCookieとの間で値が正しく送れているか確認()
    {
      var cookie = new Cookie();
      cookie.NowAdd = 3;
      cookie.NowCookie = 50;
      cookie.CostAdd = 30;
      cookie.OnAdd();
      Assert.IsTrue((cookie.CostAdd == 80) && (cookie.NowAdd == 4) && (cookie.NowCookie == 20));
    }

    /// <summary>
    /// OnMul -> RaiseNowCookieChangedメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T005_OnMulでイベントが発生することを確認()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnMul();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnMul -> UpdateIncCookieメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T006_OnMulとUpdateIncCookieとの間で値が正しく送れているか確認()
    {
      var cookie = new Cookie();
      cookie.NowMul = 3;
      cookie.NowCookie = 50;
      cookie.CostMul = 20;
      cookie.OnMul();
      Assert.IsTrue((cookie.CostMul == 200) && (cookie.NowMul == 4) && (cookie.NowCookie == 30));
    }

    /// <summary>
    /// OnSec -> RaiseNowCookieChangedメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T007_OnSecでイベントが発生することを確認()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnSec();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnSec -> UpdateIncCookieメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T008_OnSecとUpdateIncCookieとの間で値が正しく送れているか確認()
    {
      var cookie = new Cookie();
      cookie.NowSec = 4;
      cookie.NowCookie = 100;
      cookie.CostSec = 20;
      cookie.OnSec();
      Assert.IsTrue((cookie.CostSec == 50) && (cookie.NowSec == 5) && (cookie.NowCookie == 80));
    }

    /// <summary>
    /// OnInt -> RaiseNowCookieChangedメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T009_OnIntでイベントが発生することを確認()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnInt();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnInt -> UpdateIncCookieメソッドのテスト
    /// </summary>
    [TestMethod]
    public void T010_OnIntとUpdateIncCookieとの間で値が正しく送れているか確認()
    {
      var cookie = new Cookie();
      cookie.NowInt = 6;
      cookie.NowCookie = 200;
      cookie.CostInt = 180;
      cookie.OnInt();
      Assert.IsTrue((cookie.CostInt == 230) && (cookie.NowInt == 7) && (cookie.NowCookie == 20));
    }

    #endregion Cookieクラスのテスト
    #region MainViewModelクラスのテスト
    /// <summary>
    /// CalcNowCommandのテスト
    /// </summary>
    [TestMethod]
    public void T011_CalcNowCommandがModelに適切に作用するか確認()
    {
      // Cookie のインスタンスを作成
      Cookie _cookie = new Cookie();

      // MainViewModel のインスタンスを作成
      MainViewModel _mainViewModel = new MainViewModel(_cookie);

      // Cookie のインスタンスが持つプロパティの値を変更
      _cookie.NowCookie = 0;
      _cookie.IncCookie = 1;

      // テスト
      _mainViewModel.CalcNowCommand.Execute(null); 

      // 検査
      Assert.AreEqual(_cookie.NowCookie, 1);
    }

    /// <summary>
    /// Mockを利用したCalcNowCommandのテスト
    /// </summary>
    [TestMethod]
    public void T011M_CalcNowCommandがModelに適切に作用するか確認()
    {
      // Cookie のモックを作成
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModelクラスにMockオブジェクトを渡す
      var target = new MainViewModel(mockObj);

      // テスト
      target.CalcNowCommand.Execute(null);

      // 検査
      mock.Verify(x => x.UpdateNowCookie(), Times.Once);
    }
    /// <summary>
    /// CalcIncCommandのテスト
    /// </summary>
    [TestMethod]
    public void T012_CalcIncCommandがModelに適切に作用するか確認()
    {
      // Cookie のインスタンスを作成
      Cookie _cookie = new Cookie();

      // MainViewModel のインスタンスを作成
      MainViewModel _mainViewModel = new MainViewModel(_cookie);

      // Cookie のインスタンスが持つプロパティの値を変更
      _cookie.IncCookie = 2;
      _cookie.NowAdd = 3;
      _cookie.NowMul = 4;

      // テスト
      _mainViewModel.CalcIncCommand.Execute(null);

      // 検査
      Assert.AreEqual(_cookie.IncCookie, 16);
    }

    /// <summary>
    /// Mockを利用したCalcIncCommandのテスト
    /// 
    [TestMethod]
    public void T012M_CalcIncCommandがModelに適切に作用するか確認()
    {
      // Cookie のモックを作成
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModelクラスにMockオブジェクトを渡す
      var target = new MainViewModel(mockObj);

      // テスト
      target.CalcIncCommand.Execute(null);

      // 検査
      mock.Verify(x => x.UpdateIncCookie(), Times.Once);
    }


    #endregion MainViewModelクラスのテスト
  }
}
