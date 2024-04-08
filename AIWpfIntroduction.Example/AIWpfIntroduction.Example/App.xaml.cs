using System.Threading;
using System.Windows;
using AIWpfIntroduction.Example.Models;
using AIWpfIntroduction.Example.ViewModels;
using AIWpfIntroduction.Example.Views;

namespace AIWpfIntroduction.Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            /// 非同期に動いているかスレッドIDを確認するための処理
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            base.OnStartup(e);

            /// データコンテキストの設定
            var w = new MainView();
            var vm = new MainViewModel(new Cookie());

            w.DataContext = vm;

            w.Show();
        }
    }
}
