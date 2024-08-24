using UnityEngine;

/// <summary>
/// タイトル管理する
/// </summary>
public class TitleWidgetControlle : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TitleDispalyWidget _titleWidget;

    private void Start()
    {
        //タイトルを表示したら、タイトルを非表示にする
        _titleWidget
            .DisplayAnimation(() => _titleWidget.SetActive(false));
    }
}