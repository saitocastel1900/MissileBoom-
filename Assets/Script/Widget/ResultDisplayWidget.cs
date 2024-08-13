using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// リザルトを表示する
/// </summary>
public class ResultDisplayWidget : MonoBehaviour
{
    /// <summary>
    /// フェードパネル
    /// </summary>
    [SerializeField] private Image _fadePanel;
    
    /// <summary>
    /// リザルトのロゴ
    /// </summary>
    [SerializeField] private Image _resultLogoImage;

    /// <summary>
    /// 表示アニメーション
    /// </summary>
    public void DisplayAnimation()
    {
        DOTween.Sequence()
            .OnStart(() =>
            {
                _resultLogoImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                _resultLogoImage.transform.localScale = Vector3.one * 3.0f;
            })
            .Append(_fadePanel.DOFade(0.5f, 0.25f).SetEase(Ease.OutCubic))
            .Join(_resultLogoImage.DOFade(1.0f, 1.0f).SetEase(Ease.OutCubic))
            .Join(_resultLogoImage.transform.DOScale(1.0f, 1.0f).SetEase(Ease.OutBounce, 0))
            .SetLink(this.gameObject);
    }

    /// <summary>
    /// アクティブを設定する
    /// </summary>
    /// <param name="isView">アクティブにするか</param>
    public void SetActive(bool isView)
    {
        _fadePanel.gameObject.SetActive(isView);
        _resultLogoImage.gameObject.SetActive(isView);
    }
}