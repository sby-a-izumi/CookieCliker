﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIWpfIntroduction.Example.Models
{
    using AIWpfIntroduction.Example.ViewModels;
    using System.Security.Cryptography.X509Certificates;


    /// <summary>
    /// クッキーの計算処理、計算を記すモデルクラス
    /// </summary>
    public class Cookie : ICookie
    {
        public Cookie()
        {
            /// 実行するタイマーの時間を指定(ms)
            int Timer_time = 100;
            this._timer = new GameTimer(AddCookiePerSecond, Timer_time);
        }
        #region Cookieクラスの変数
        /// <summary>
        /// クッキーの現在値を示すプロパティ
        /// </summary>
        #if DEBUG
            public int NowCookie { get; set; } = 0;
        #else
            public int NowCookie { get; private set; } = 0;
        #endif

        /// <summary>
        /// ボタンを押すごとに増加する値を示すプロパティ
        /// </summary>
        #if DEBUG
            public int IncCookie { get; set; } = 1;
        #else
            public int IncCookie { get; private set; } = 1;
        #endif

        /// <summary>
        /// 適応された増加値を示すプロパティ
        /// </summary>
        #if DEBUG
            public int NowAdd { get; set; } = 0;
        #else
            public int NowAdd { get; private set; } = 0;
        #endif

        /// <summary>
        /// 適応された増加率を示すプロパティ
        /// </summary>
        #if DEBUG
            public int NowMul { get; set; } = 1;
        #else
            public int NowMul { get; private set; } = 1;
        #endif

        /// <summary>
        /// 適応された毎秒ごとの増加値を示すプロパティ
        /// </summary>
        #if DEBUG
            public int NowSec { get; set; } = 1;
        #else
            public int NowSec { get; private set; } = 1;
        #endif

        /// <summary>
        /// 適応された時間ごとの増加率を示すプロパティ
        /// </summary>
        #if DEBUG
            public int NowInt { get; set; } = 0;
        #else
            public int NowInt { get; private set; } = 0;
        #endif

        /// <summary>
        /// 増加量のアップグレードコストを示すプロパティ
        /// </summary>
        #if DEBUG
            public int CostAdd { get; set; } = 10;
        #else
            public int CostAdd { get; private set; } = 10;
        #endif

        /// <summary>
        /// 倍率のアップグレードコストを示すプロパティ
        /// </summary>
        #if DEBUG
            public int CostMul { get; set; } = 20;
        #else
            public int CostMul { get; private set; } = 20;
        #endif

        /// <summary>
        /// 生産量のアップグレードコストを示すプロパティ
        /// </summary>
        #if DEBUG
            public int CostSec { get; set; } = 30;
        #else
            public int CostSec { get; private set; } = 30;
        #endif

        /// <summary>
        /// 利息率のアップグレードコストを示すプロパティ
        /// </summary>
        #if DEBUG
            public int CostInt { get; set; } = 100;
        #else
            public int CostInt { get; private set; } = 100;
        #endif


#endregion Cookieクラスの変数


        #region 各コマンド本体
        /// <summary>
        /// timerによって実行されるメソッド
        /// </summary>
        private void AddCookiePerSecond()
        {
            this.NowCookie = this.NowCookie + this.NowSec + (this.NowCookie * this.NowInt / 100);

            /// App.Current.Dispatcher.InvokeAsyncはWPFにおける非同期に操作を実行するためのメソッドです。
            /// RaiseNowCookieChangedメソッドを呼び出すアクションを実行しています。
            App.Current.Dispatcher.InvokeAsync((Action)(() => RaiseNowCookieChanged()));
        }

        

        public event EventHandler? NowCookieChanged;

        /// <summary>
        /// NowCookieChangedイベントを発行しています。
        /// </summary>
        private void RaiseNowCookieChanged()
        {
            var h = NowCookieChanged;
            if (h != null)
            {
                h(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// 現在値を増加値分だけ加算する
        /// </summary>
        public void UpdateNowCookie()
        {
            this.NowCookie += this.IncCookie;
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 増加値を変更する
        /// </summary>
        public void UpdateIncCookie()
        {
            this.IncCookie = (1 + this.NowAdd) * this.NowMul;
        }

        /// <summary>
        /// 増加値の増加量をアップグレード
        /// </summary>
        public void OnAdd()
        {
            //増加値の増加量を計算
            this.NowAdd += 1;
            //コスト消費計算
            this.NowCookie -= this.CostAdd;
            //コスト上昇計算
            this.CostAdd += 50;
            //増加値更新
            UpdateIncCookie();
            //現在値更新
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 増加値の倍率をアップグレード
        /// </summary>
        public void OnMul()
        {
            //増加値の倍率を計算
            this.NowMul += 1;
            //コスト消費計算
            this.NowCookie -= this.CostMul;
            //コスト上昇計算
            this.CostMul *= 10;
            //増加値更新
            UpdateIncCookie();
            //現在値更新
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 生産量をアップグレード
        /// </summary>
        public void OnSec()
        {   
            this.NowSec += 1;
            this.NowCookie -= this.CostSec;
            this.CostSec += 30;
            UpdateIncCookie();
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 利息率をアップグレード
        /// </summary>
        public void OnInt()
        {
            this.NowInt += 1;
            this.NowCookie -= this.CostInt;
            this.CostInt += 50;
            UpdateIncCookie();
            RaiseNowCookieChanged();
        }
    #endregion 各コマンド本体

        private GameTimer _timer;

    }
}
