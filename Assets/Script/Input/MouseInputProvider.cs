using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

public class MouseInputProvider : IInputEventProvider, IInitializable, IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsButtonPush => _isButtonPush;
    private BoolReactiveProperty _isButtonPush = new BoolReactiveProperty(false);
    
    /// <summary>
    /// 
    /// </summary>
    private Button _launchButton;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shotButton"></param>
    public MouseInputProvider(Button launchButton)
    {
        _launchButton = launchButton;
    }   
    
    /// <summary>
    /// 
    /// </summary>
    public void Initialize()
    {
        _launchButton
            .OnClickAsObservable()
            .Select(_ =>true)
            .Subscribe(_isButtonPush.SetValueAndForceNotify)
            .AddTo(_compositeDisposable);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}