using AIWpfIntroduction.Example.Models;
using AIWpfIntroduction.Example.ViewModels;
using AIWpfIntroduction.Example;
using Moq;
using System.ComponentModel;

namespace mstest
{
  [TestClass]
  public class UnitTest1
  {
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
      Cookie cookie = new Cookie();

      // MainViewModel �̃C���X�^���X���쐬
      MainViewModel _mainViewModel = new MainViewModel(cookie);

      // Cookie �̃C���X�^���X�����v���p�e�B�̒l��ύX
      cookie.NowCookie = 0;
      cookie.IncCookie = 1;

      // �e�X�g
      _mainViewModel.CalcNowCommand.Execute(null); 

      // ����
      Assert.AreEqual(cookie.NowCookie, 1);
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
      Cookie cookie = new Cookie();

      // MainViewModel �̃C���X�^���X���쐬
      MainViewModel _mainViewModel = new MainViewModel(cookie);

      // Cookie �̃C���X�^���X�����v���p�e�B�̒l��ύX
      cookie.IncCookie = 2;
      cookie.NowAdd = 3;
      cookie.NowMul = 4;

      // �e�X�g
      _mainViewModel.CalcIncCommand.Execute(null);

      // ����
      Assert.AreEqual(cookie.IncCookie, 16);
    }

    /// <summary>
    /// Mock�𗘗p����CalcIncCommand�̃e�X�g
    /// </summary>
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

    /// <summary>
    /// Mock�𗘗p����UpgradeAddCommand�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T013M_UpgradeAddCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModel�N���X��Mock�I�u�W�F�N�g��n��
      var target = new MainViewModel(mockObj);

      // �e�X�g
      target.UpgradeAddCommand.Execute(null);

      // ����
      mock.Verify(x => x.OnAdd(), Times.Once);
    }

    /// <summary>
    /// Mock�𗘗p����UpgradeMulCommand�̃e�X�g
    /// </summary>
    [TestMethod]
    public void T014M_UpgradeMulCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModel�N���X��Mock�I�u�W�F�N�g��n��
      var target = new MainViewModel(mockObj);

      // �e�X�g
      target.UpgradeMulCommand.Execute(null);

      // ����
      mock.Verify(x => x.OnMul(), Times.Once);
    }

    /// <summary>
    /// Mock�𗘗p����UpgradeSecCommand�̃e�X�g
    /// 
    [TestMethod]
    public void T015M_UpgradeSecCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModel�N���X��Mock�I�u�W�F�N�g��n��
      var target = new MainViewModel(mockObj);

      // �e�X�g
      target.UpgradeSecCommand.Execute(null);

      // ����
      mock.Verify(x => x.OnSec(), Times.Once);
    }

    /// <summary>
    /// Mock�𗘗p����UpgradeIntCommand�̃e�X�g
    /// 
    [TestMethod]
    public void T016M_UpgradeIntCommand��Model�ɓK�؂ɍ�p���邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      // MainViewModel�N���X��Mock�I�u�W�F�N�g��n��
      var target = new MainViewModel(mockObj);

      // �e�X�g
      target.UpgradeIntCommand.Execute(null);

      // ����
      mock.Verify(x => x.OnInt(), Times.Once);
    }

    #endregion MainViewModel�N���X�̃e�X�g
    #region GameTimer�N���X�̃e�X�g

    [TestMethod, Timeout(5000)]
    public async Task T017M_GameTimer�����������삷�邩�m�F()
    {
      // Cookie �̃��b�N���쐬
      var mock = new Mock<ICookie>();
      var mockObj = mock.Object;

      int interval = 1000;
      // GameTimer �̃C���X�^���X���쐬
      GameTimer _gameTimer = new GameTimer(mockObj.AddCookiePerSecond,interval);

      // �e�X�g
      _gameTimer.SetupTimer();

      // GameTimer�̃C���^�[�o���ȏ�̎��Ԃ����e�X�g�̎��s���~���܂��B
      await Task.Delay(TimeSpan.FromSeconds(2));�@

      // ����
      mock.Verify(x => x.AddCookiePerSecond(), Times.AtLeastOnce());
    }

      
    
    #endregion GameTimer�N���X�̃e�X�g
  }
}
