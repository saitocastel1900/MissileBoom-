using UniRx;

public interface IInputEventProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyReactiveProperty<bool> IsButtonPush { get; }
}
