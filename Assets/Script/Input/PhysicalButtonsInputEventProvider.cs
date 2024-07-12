using System;
using UniRx;
using Zenject;

public class PhysicalButtonsInputEventProvider : IInputEventProvider, IInitializable, IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsButtonPush => _isButtonPush;
    private BoolReactiveProperty _isButtonPush = new BoolReactiveProperty(false);
    
    [Inject] private SerialHandler _serialHandler;

    /// <summary>
    /// 
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    public void Initialize()
    {
        Observable.EveryUpdate()
            .Select(_ => _serialHandler.MessagesProp.Value)
            .Where(message => !string.IsNullOrEmpty(message))
            .Select(int.Parse)
            .Select(isButtonPush => isButtonPush == 1)
            .Subscribe(isButtonPush=>_isButtonPush.Value=isButtonPush)
            .AddTo(_compositeDisposable);
    }

    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}