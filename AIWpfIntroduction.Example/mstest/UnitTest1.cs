using AIWpfIntroduction.Example.Models;
using AIWpfIntroduction.Example.ViewModels;
using Moq;

namespace mstest
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void TestMethod1()
        {
            // Cookie �̃��b�N���쐬
            var mock = new Moq.Mock<ICookie>();
            var mockObj = mock.Object;

            // MainViewModel ���C���X�^���X��
            var target = new MainViewModel(mockObj);

            // �e�X�g
            target.CalcNowCommand.Execute(null);

            // ����
            mock.Verify(x => x.UpdateNowCookie(), Times.Once);
        }*/

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
    }
}
