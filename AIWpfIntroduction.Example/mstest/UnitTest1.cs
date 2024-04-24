using AIWpfIntroduction.Example.Models;
using AIWpfIntroduction.Example.ViewModels;
using Moq;

namespace mstest
{
  [TestClass]
  public class UnitTest1
  {
    /// <summary>
    /// Timer�̃e�X�g
    /// </summary>
    



    #region Cookie�N���X�̃e�X�g

    /// <summary>
    /// UpdateNowCookie -> RaiseNowCookieChanged���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T000_UpdateNowCookie�ŃC�x���g���������邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;

      cookie.UpdateNowCookie();

      Assert.IsTrue(isCalled);
    }
    /// <summary>
    /// UpdateNowCookie���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T001_UpdateNowCookie�Œl���C���N�������g���邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      cookie.NowCookie = 0;
      cookie.IncCookie = 1;
      cookie.UpdateNowCookie();
      Assert.AreEqual(cookie.NowCookie, 1);
    }

    /// <summary>
    /// UpdateIncCookie���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T002_UpdateIncCookie��IncCookie�̒l���X�V����邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      cookie.IncCookie = 2;
      cookie.NowAdd = 3;
      cookie.NowMul = 4;
      cookie.UpdateIncCookie();
      Assert.AreEqual(cookie.IncCookie, 16);
    }

    /// <summary>
    /// OnAdd -> RaiseNowCookieChanged���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T003_OnAdd�ŃC�x���g���������邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnAdd();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnAdd -> UpdateIncCookie���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T004_OnAdd��UpdateIncCookie�Ƃ̊ԂŒl������������Ă��邩�m�F()
    {
      var cookie = new Cookie();
      cookie.NowAdd = 3;
      cookie.NowCookie = 50;
      cookie.CostAdd = 30;
      cookie.OnAdd();
      Assert.IsTrue((cookie.CostAdd == 80) && (cookie.NowAdd == 4) && (cookie.NowCookie == 20));
    }

    /// <summary>
    /// OnMul -> RaiseNowCookieChanged���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T005_OnMul�ŃC�x���g���������邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnMul();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnMul -> UpdateIncCookie���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T006_OnMul��UpdateIncCookie�Ƃ̊ԂŒl������������Ă��邩�m�F()
    {
      var cookie = new Cookie();
      cookie.NowMul = 3;
      cookie.NowCookie = 50;
      cookie.CostMul = 20;
      cookie.OnMul();
      Assert.IsTrue((cookie.CostMul == 200) && (cookie.NowMul == 4) && (cookie.NowCookie == 30));
    }

    /// <summary>
    /// OnSec -> RaiseNowCookieChanged���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T007_OnSec�ŃC�x���g���������邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnSec();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnSec -> UpdateIncCookie���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T008_OnSec��UpdateIncCookie�Ƃ̊ԂŒl������������Ă��邩�m�F()
    {
      var cookie = new Cookie();
      cookie.NowSec = 4;
      cookie.NowCookie = 100;
      cookie.CostSec = 20;
      cookie.OnSec();
      Assert.IsTrue((cookie.CostSec == 50) && (cookie.NowSec == 5) && (cookie.NowCookie == 80));
    }

    /// <summary>
    /// OnInt -> RaiseNowCookieChanged���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T009_OnInt�ŃC�x���g���������邱�Ƃ��m�F()
    {
      var cookie = new Cookie();
      var isCalled = false;
      cookie.NowCookieChanged += (s, e) => isCalled = true;
      cookie.OnInt();
      Assert.IsTrue(isCalled);
    }

    /// <summary>
    /// OnInt -> UpdateIncCookie���\�b�h�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T010_OnInt��UpdateIncCookie�Ƃ̊ԂŒl������������Ă��邩�m�F()
    {
      var cookie = new Cookie();
      cookie.NowInt = 6;
      cookie.NowCookie = 200;
      cookie.CostInt = 180;
      cookie.OnInt();
      Assert.IsTrue((cookie.CostInt == 230) && (cookie.NowInt == 7) && (cookie.NowCookie == 20));
    }

    #endregion Cookie�N���X�̃e�X�g
    #region MainViewModel�N���X�̃e�X�g
    /// <summary>
    /// CalcNowCommand�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T011_CalcNowCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃C���X�^���X���쐬
      Cookie _cookie = new Cookie();

      // MainViewModel �̃C���X�^���X���쐬
      MainViewModel _mainViewModel = new MainViewModel(_cookie);

      // Cookie �̃C���X�^���X�����v���p�e�B�̒l��ύX
      _cookie.NowCookie = 0;
      _cookie.IncCookie = 1;

      // �e�X�g
      _mainViewModel.CalcNowCommand.Execute(null); 

      // ����
      Assert.AreEqual(_cookie.NowCookie, 1);
    }

    /// <summary>
    /// Mock�𗘗p����CalcNowCommand�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T011M_CalcNowCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModel�N���X��Mock�I�u�W�F�N�g��n��
      var target = new MainViewModel(mockObj);

      // �e�X�g
      target.CalcNowCommand.Execute(null);

      // ����
      mock.Verify(x => x.UpdateNowCookie(), Times.Once);
    }
    /// <summary>
    /// CalcIncCommand�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T012_CalcIncCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃C���X�^���X���쐬
      Cookie _cookie = new Cookie();

      // MainViewModel �̃C���X�^���X���쐬
      MainViewModel _mainViewModel = new MainViewModel(_cookie);

      // Cookie �̃C���X�^���X�����v���p�e�B�̒l��ύX
      _cookie.IncCookie = 2;
      _cookie.NowAdd = 3;
      _cookie.NowMul = 4;

      // �e�X�g
      _mainViewModel.CalcIncCommand.Execute(null);

      // ����
      Assert.AreEqual(_cookie.IncCookie, 16);
    }

    /// <summary>
    /// Mock�𗘗p����CalcIncCommand�̃e�X�g
    /// 
    [TestMethod]
    public void T012M_CalcIncCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModel�N���X��Mock�I�u�W�F�N�g��n��
      var target = new MainViewModel(mockObj);

      // �e�X�g
      target.CalcIncCommand.Execute(null);

      // ����
      mock.Verify(x => x.UpdateIncCookie(), Times.Once);
    }


    #endregion MainViewModel�N���X�̃e�X�g
  }
}
