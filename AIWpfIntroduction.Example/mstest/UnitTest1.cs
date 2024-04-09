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
    }
}
