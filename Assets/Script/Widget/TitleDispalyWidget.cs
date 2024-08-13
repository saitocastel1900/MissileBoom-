using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルを表示する
/// </summary>
public class TitleDispalyWidget : MonoBehaviour
{
    /// <summary>
    /// フェードパネル
    /// </summary>
    [SerializeField] private Image _fadePanel;
    
    /// <summary>
    /// タイトルのロゴ1
    /// </summary>
    [SerializeField] private Image _logoImage1;
    
    /// <summary>
    /// タイトルのロゴ2
    /// </summary>
    [SerializeField] private Image _logoImage2;
    
    /// <summary>
    /// 集中線
    /// </summary>
    [SerializeField] private Image _SaturatedLineImage;
    
    /// <summary>
    /// 表示アニメーション
    /// </summary>
    /// <param name="onComplete"></param>
    public void DisplayAnimation(Action onComplete)
    {
        Sequence mainSequence = DOTween.Sequence()
            .Append(AnimationUtility.PanelFadeOutTween(_fadePanel, 0.5f))
            .AppendInterval(1.0f)
            .Append(CreateLogoSequence(_logoImage1))
            .Join(CreateLogoSequence(_logoImage2))
            .SetLink(this.gameObject)
            .OnComplete(()=>onComplete?.Invoke());
        
        mainSequence.Play();
    }
    
    /// <summary>
    /// アクティブを設定する
    /// </summary>
    /// <param name="isView">アクティブにするか</param>
    public void SetActive(bool isView)
    {
        _fadePanel.gameObject.SetActive(isView);
        _logoImage1.gameObject.SetActive(isView);
        _logoImage2.gameObject.SetActive(isView);
        _SaturatedLineImage.gameObject.SetActive(isView);
    }
    
    /// <summary>
    /// ロゴのSequenceを作成する
    /// </summary>
    /// <param name="logoImage">ロゴ</param>
    /// <returns></returns>
    private Sequence CreateLogoSequence(Image logoImage)
    {
        return DOTween.Sequence()
            .Append(logoImage.rectTransform.DOScale(new Vector3(0.75f, 1.25f, 1f), 0.25f).SetEase(Ease.InQuart))
            .Append(logoImage.rectTransform.DOScale(new Vector3(1.25f, 0f, 1f), 0.25f).SetEase(Ease.InOutQuart));
    }
}
