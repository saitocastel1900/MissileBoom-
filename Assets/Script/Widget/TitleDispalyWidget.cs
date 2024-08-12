using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitleDispalyWidget : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private Image _logoImage1;
    [SerializeField] private Image _logoImage2;
    [SerializeField] private Image _SaturatedLineImage;
    [SerializeField] private float _duration;
    
    public void DisplayAnimation(Action onComplete)
    {
        Sequence mainSequence = DOTween.Sequence()
            .Append(AnimationUtility.PanelFadeOutTween(_fadePanel, 0.5f))
            .AppendInterval(_duration)
            .Append(CreateLogoSequence(_logoImage1))
            .Join(CreateLogoSequence(_logoImage2))
            .SetLink(this.gameObject)
            .OnComplete(()=>onComplete?.Invoke());
        
        mainSequence.Play();
    }
    
    public void SetActive(bool isView)
    {
        _fadePanel.gameObject.SetActive(isView);
        _logoImage1.gameObject.SetActive(isView);
        _logoImage2.gameObject.SetActive(isView);
        _SaturatedLineImage.gameObject.SetActive(isView);
    }
    
    private Sequence CreateLogoSequence(Image logoImage)
    {
        return DOTween.Sequence()
            .Append(logoImage.rectTransform.DOScale(new Vector3(0.75f, 1.25f, 1f), 0.25f).SetEase(Ease.InQuart))
            .Append(logoImage.rectTransform.DOScale(new Vector3(1.25f, 0f, 1f), 0.25f).SetEase(Ease.InOutQuart));
    }
}
