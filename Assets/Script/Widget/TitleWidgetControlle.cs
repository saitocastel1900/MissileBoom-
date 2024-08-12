using UnityEngine;

public class TitleWidgetControlle : MonoBehaviour
{
    [SerializeField] private TitleDispalyWidget _titleWidget;

    private void Start()
    {
        _titleWidget
            .DisplayAnimation(()=>_titleWidget.SetActive(false));
    }
}
