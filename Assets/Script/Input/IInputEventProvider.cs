using UniRx;

/// <summary>
/// 入力を管理する
/// </summary>
public interface IInputEventProvider
{
    /// <summary>
    /// ボタンが押されたか
    /// </summary>
    /// <returns></returns>
    IReadOnlyReactiveProperty<bool> IsButtonPush { get; }
}
