using System;
using UniRx;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// UIのボタン入力を管理する
/// </summary>
public class WidgetButtonInputProvider : IInputEventProvider, IInitializable, IDisposable
{
    /// <summary>
    /// ボタンがおされたか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsButtonPush => _isButtonPush;
    private BoolReactiveProperty _isButtonPush = new BoolReactiveProperty(false);
    
    /// <summary>
    /// UIの発射ボタン
    /// </summary>
    private Button _launchButton;
    
    /// <summary>
    /// CompositeDisposable
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="launchButton">UIの発射ボタン</param>
    public WidgetButtonInputProvider(Button launchButton)
    {
        _launchButton = launchButton;
    }   
    
    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        //ボタンが押されたら、フラグを立てる
        _launchButton
            .OnClickAsObservable()
            .Select(_ =>true)
            .Subscribe(_isButtonPush.SetValueAndForceNotify)
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