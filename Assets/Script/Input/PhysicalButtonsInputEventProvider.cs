using System;
using UniRx;
using Zenject;

/// <summary>
/// Arduinoのボタン入力を管理する
/// </summary>
public class PhysicalButtonsInputEventProvider : IInputEventProvider, IInitializable, IDisposable
{
    /// <summary>
    /// ボタンがおされたか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsButtonPush => _isButtonPush;
    private BoolReactiveProperty _isButtonPush = new BoolReactiveProperty(false);
    
    /// <summary>
    /// シリアル通信を管理する
    /// </summary>
    [Inject] private SerialHandler _serialHandler;

    /// <summary>
    /// CompositeDisposable
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        //ボタンが押されたら、フラグを立てる
        Observable.EveryUpdate()
            .Select(_ => _serialHandler.MessagesProp.Value)
            .Where(message => !string.IsNullOrEmpty(message))
            .Select(int.Parse)
            .Select(isButtonPush => isButtonPush == 1)
            .Subscribe(isButtonPush=>_isButtonPush.Value=isButtonPush)
            .AddTo(_compositeDisposable);
    }

    /// <summary>
    /// リソースを開放する
    /// </summary>
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}