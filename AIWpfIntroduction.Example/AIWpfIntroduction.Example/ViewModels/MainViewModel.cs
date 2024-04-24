using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIWpfIntroduction.Example.ViewModels
{
    using AIWpfIntroduction.Example.Models;
    using System.Security.Policy;
    using System.Windows.Media.Animation;
    /// <summary>
    /// MainViewに対するデータコンテキストであり、本プロジェクトのViewModelにあたるクラスです。
    /// </summary>
    public class MainViewModel : NotificationObject
    {

        private ICookie _cookie;
        /// <summary>
        /// MainViewModelのコンストラクタです。
        /// </summary>
        public MainViewModel(ICookie cookie)
        {
            _cookie = cookie;


            // 各コマンドに対して、実行メソッドと実行可能条件メソッドを明示したデリゲートをインスタンス化
            CalcNowCommand = new DelegateCommand(_ => CalcNow(), _ => CanCalcNow());
            CalcIncCommand = new DelegateCommand(_ => CalcInc(), _ => CanCalcInc());
            UpgradeAddCommand = new DelegateCommand(_ => UpgradeAdd(), _ => CanUpgradeAdd());
            UpgradeMulCommand = new DelegateCommand(_ => UpgradeMul(), _ => CanUpgradeMul());
            UpgradeSecCommand = new DelegateCommand(_ => UpgradeSec(), _ => CanUpgradeSec());
            UpgradeIntCommand = new DelegateCommand(_ => UpgradeInt(), _ => CanUpgradeInt());

            // NowCookieChangedイベントにOnNowCookieChangedイベントハンドラを登録しています。
            _cookie.NowCookieChanged += OnNowCookieChanged;
        }

        /// <summary>
        /// NowCookieChangedイベントハンドラです。
        /// アップグレード可能判定を変更しています。
        /// </summary>
        /// <param name="obj">イベント発行元</param>
        /// <param name="args">イベント引数</param>
        private void OnNowCookieChanged(object? obj, EventArgs args)
        {
            // すべてのプロパティを更新するメソッドです。
            RaiseAllPropertyChanged();
            // それぞれのデリゲートコマンドに対して、イベントを発行するメソッドの実行をしています。
            this.UpgradeAddCommand.RaiseCanExecuteChanged();
            this.UpgradeMulCommand.RaiseCanExecuteChanged();
            this.UpgradeSecCommand.RaiseCanExecuteChanged();
            this.UpgradeIntCommand.RaiseCanExecuteChanged();
        }

        #region Modelのインスタンスから各プロパティを取得

        /// <summary>
        /// 現在値の取得
        /// </summary>
        public int NowCookie
        {
            get { return _cookie.NowCookie; }
        }

        /// <summary>
        /// 増加値の取得
        /// </summary>
        public int IncCookie
        {
            get { return _cookie.IncCookie; }
        }

        /// <summary>
        /// 増加値の増加量の取得
        /// </summary>
        public int NowAdd
        {
            get { return _cookie.NowAdd; }
        }

        /// <summary>
        /// 増加値の倍率の取得
        /// </summary>
        public int NowMul
        {
            get { return _cookie.NowMul; }
        }

        /// <summary>
        /// 生産量の取得
        /// </summary>
        public int NowSec
        {
            get { return _cookie.NowSec; }
        }

        /// <summary>
        /// 利息率の取得
        /// </summary>
        public int NowInt
        {
            get { return _cookie.NowInt; }
        }

        /// <summary>
        /// 増加量コスト
        /// </summary>
        public int CostAdd
        {
            get { return _cookie.CostAdd; }
        }

        /// <summary>
        /// 倍率コスト
        /// </summary>
        public int CostMul
        {
            get { return _cookie.CostMul; }
        }

        /// <summary>
        /// 生産量コスト
        /// </summary>
        public int CostSec
        {
            get { return _cookie.CostSec; }
        }

        /// <summary>
        /// 利息率コスト
        /// </summary>
        public int CostInt
        {
            get { return _cookie.CostInt; }
        }
        #endregion 各プロパティの取得または設定


        #region 各コマンドの取得メソッド
        /// 各コマンドの取得メソッドでは以下のように構成されている。
        /// 1. executeに渡す、コマンドを実行したときに処理されるメソッド
        /// 2. canExecuteに渡す、コマンドの実行可否判断メソッド
        /// 3. コマンド本体の取得（ init アクセサを利用し、初期化処理のみ可能なプロパティの定義）


        
        #region 現在値に関するコマンド
        /// <summary>
        /// CalcNowCommandを実行したときに処理されるメソッド
        /// </summary>
        private void CalcNow()
        {
            _cookie.UpdateNowCookie();
        }

        /// <summary>
        /// CalcNowCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanCalcNow()
        {
            return true;
        }

        /// <summary>
        /// 現在値変更コマンド取得
        /// </summary>
        public DelegateCommand CalcNowCommand { get; init; }
        #endregion

        #region 増加値に関するコマンド
        /// <summary>
        /// CalcIncCommandを実行したときに処理されるメソッド
        /// </summary>
        private void CalcInc()
        {
            _cookie.UpdateIncCookie();
        }

        /// <summary>
        /// CalcIncCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanCalcInc()
        {
            return true;
        }

        /// <summary>
        /// 増加値変更コマンド取得
        /// </summary>
        public DelegateCommand CalcIncCommand { get; init; }
        #endregion

        #region 増加値の増加量に関するコマンド
        /// <summary>
        /// UpgradeAddCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeAdd()
        {
            _cookie.OnAdd();
        }

        /// <summary>
        /// UpgradeAddCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeAdd()
        {
            return _cookie.NowCookie >= _cookie.CostAdd;
        }

        /// <summary>
        /// 増加量アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeAddCommand { get; init; }
        #endregion

        #region 増加値の倍率に関するコマンド
        /// <summary>
        /// UpgradeMulCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeMul()
        {
            _cookie.OnMul();
        }

        /// <summary>
        /// UpgradeMulCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeMul()
        {
            return _cookie.NowCookie >= _cookie.CostMul;
        }
        #endregion

        #region 生産量に関するコマンド
        /// <summary>
        /// 倍率アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeMulCommand { get; init; }

        /// <summary>
        /// UpgradeSecCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeSec()
        {
            _cookie.OnSec();
        }

        /// <summary>
        /// UpgradeSecCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeSec()
        {
            return _cookie.NowCookie >= _cookie.CostSec;
        }
        
        /// <summary>
        /// 生産量アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeSecCommand { get; init; }
        #endregion

        #region 利息率に関するコマンド
        /// <summary>
        /// UpgradeIntCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeInt()
        {
            _cookie.OnInt();
        }

        /// <summary>
        /// UpgradeIntCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeInt()
        {
            return _cookie.NowCookie >= _cookie.CostInt;
        }
        
        /// <summary>
        /// 生産利息アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeIntCommand { get; init; }
        #endregion
        #endregion 各コマンドの取得メソッド


        //モデルオブジェクトのビューモデルクラス変数
        //private readonly Cookie _cookie;
    }
}

