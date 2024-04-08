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
        /// UppdateNowCookieChanged���\�b�h�̃e�X�g
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
        [TestMethod]
        public void T001_UpdateNowCookie�Œl���C���N�������g���邱�Ƃ��m�F()
        {
            var cookie = new Cookie();
            cookie.NowCookie = 0;
            cookie.IncCookie = 1;
            cookie.UpdateNowCookie();
            Assert.AreEqual(cookie.NowCookie, 1);
        }

        
    }
}
