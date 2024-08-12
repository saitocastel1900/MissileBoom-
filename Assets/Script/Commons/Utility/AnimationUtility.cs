using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public static class AnimationUtility
{
    /// <summary>
    /// フェードアウトのTween
    /// </summary>
    public static Tween PanelFadeOutTween(Image panel,float duration= 2.5f)
    {
        return panel.DOFade(0f, duration)
            .SetEase(Ease.Linear).OnComplete(() => { Debug.Log("フェードアウトが完了しました"); });
    }
        
    /// <summary>
    /// フェードインのTween
    /// </summary>
    public static Tween TransitionEffectTween(Image panel,float duration= 2.5f,Subject<Unit> OnCallback=null)
    {
        return panel.DOFade(1.0f, duration)
            .SetEase(Ease.Linear).OnComplete(() =>
            {
                Debug.Log("フェードインが完了しました");
                OnCallback?.OnNext(Unit.Default);
            });
    }

    /// <summary>
    /// フェードインを繰り返すTween
    /// </summary>
    public static Tween FadeImageLoopTween(Image image)
    {
        return image.DOFade(0.0f, 1f)
            .SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo);
    }
}
