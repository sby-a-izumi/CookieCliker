using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AIWpfIntroduction.Example
{
    /// <summary>
    /// プロパティ値に変更があったタイミングでPropertyChangedイベントを発行して、変更を通知ためのクラスです。
    /// </summary>
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        #region InotifyPropertyChanged の実装
        /// <summary>
        /// プロパティに変更があった場合に発生するイベントです。
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発行するメソッドです。
        /// </summary>
        /// <param name="propertyName">プロパティ値に変更があったプロパティ名を指定します。</param>
        protected void RaisePropertyChanged([CallerMemberName]string? propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaiseAllPropertyChanged()
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(null));
        }

        /// <summary>
        /// プロパティを設定するためのメソッドです。プロパティ値変更に使用されます。
        /// </summary>
        /// <typeparam name="T">プロパティの型を表すジェネリック型パラメータです。（型によって限定しないため）</typeparam>
        /// <param name="target">プロパティの現在の値を参照するためのパラメータです。</param>
        /// <param name="value">新しい値を指定するためのパラメータです。</param>
        /// <param name="propertyName">呼び出し元のプロパティ名を表します。</param>
        /// <returns>プロパティ値に変更があったときに true を返します。</returns>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName]string? propertyName = null)
        {
            if (Equals(target, value))
                return false;
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        #endregion INotifyPropertyChanged の実装
    }
}
