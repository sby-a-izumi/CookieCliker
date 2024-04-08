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
            // Cookie のモックを作成
            var mock = new Moq.Mock<ICookie>();
            var mockObj = mock.Object;

            // MainViewModel をインスタンス化
            var target = new MainViewModel(mockObj);

            // テスト
            target.CalcNowCommand.Execute(null);

            // 検査
            mock.Verify(x => x.UpdateNowCookie(), Times.Once);
        }*/

        /// <summary>
        /// UppdateNowCookieChangedメソッドのテスト
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
        [TestMethod]
        public void T001_UpdateNowCookieで値がインクリメントすることを確認()
        {
            var cookie = new Cookie();
            cookie.NowCookie = 0;
            cookie.IncCookie = 1;
            cookie.UpdateNowCookie();
            Assert.AreEqual(cookie.NowCookie, 1);
        }

        
    }
}
