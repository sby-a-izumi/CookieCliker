using System;
using System.Threading;
using System.Timers;

namespace AIWpfIntroduction.Example
{
    public class GameTimer // 単体テストのためにpublicに変更
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="action">引数なしのデリゲートを指定</param>
        public GameTimer(Action action, int Timer_time)
        {
            _timer_time = Timer_time;
            SetupTimer();

            //create time　によってインスタンス化した後　返り値
            _action = action;
        }

        private readonly Action _action;

        /// <summary>
        /// Elapsedイベントが発行された際に実行されるイベントハンドラ
        /// </summary>
        /// <param name="sender">発行元</param>
        /// <param name="e">イベント引数</param>
        private void OnElapsed(object? sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            _action();
        }

        private System.Timers.Timer _timer;
        private int _timer_time;

        /// <summary>
        /// 一定の間隔でイベントを生成するメソッド
        /// 1000miri秒ごとに動くタイマを登録
        /// </summary>
        public void SetupTimer()
        {
            // 1秒ごとに実行するtimerをインスタンス化
            // 時間を外部から
            _timer = new System.Timers.Timer(_timer_time);

            // Elapsedイベントを登録
            _timer.Elapsed +=OnElapsed;

            // 設定されたTimer設定でスタート
            _timer.Start();
        }
    }
}
