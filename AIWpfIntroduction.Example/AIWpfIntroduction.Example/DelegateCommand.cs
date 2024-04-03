using System;
using System.Windows.Input;

namespace AIWpfIntroduction.Example
{
    /// <summary>
    /// Viewの処理をViewModelへ伝えるためにICommandインターフェースを利用する必要があるので、デリゲートを用いて処理の委譲をするクラスです。
    /// </summary>
    internal class DelegateCommand : ICommand
    {   
        /// <summary>
        /// コマンド実行時の処理内容を保持
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// コマンド実行可能判別の処理内容を保持
        /// </summary>
        private Func<object, bool> _canExecute;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="execute">コマンド実行処理を指定します。</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="execute">コマンド実行処理を指定します。</param>
        /// <param name="canExecute">コマンド実行可能判別処理を指定します。</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        #region ICommand の実装
        /// <summary>
        /// コマンドが実行可能かどうかの判別処理をします。
        /// </summary>
        /// <param name="parameter">判別処理に対するパラメータを指定します。</param>
        /// <returns>実行可能であれば、true を返します。</returns>
        public bool CanExecute(object? parameter)
        {
            return (this._canExecute != null) ? this._canExecute(parameter) : true;
        }
        /// <summary>
        /// 実行可能かどうかの判別処理の関する状態が変更された時に発生します。
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// CanExecuteChanged イベントを発行するメソッドです。
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
        }

        /// <summary>
        /// コマンドが実行されたときの処理です。
        /// </summary>
        /// <param name="parameter">コマンドに対するパラメータを指定します。</param>
        public void Execute(object? parameter)
        {
            if(this._execute != null)
                this._execute(parameter);
        }
        #endregion ICommand の実装
    }
}
