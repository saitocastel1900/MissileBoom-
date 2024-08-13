using UniRx;
using UnityEngine;

/// <summary>
/// ビルのアクティブを管理する
/// </summary>
public class TargetVisibility : MonoBehaviour
{
    /// <summary>
    /// ビル
    /// </summary>
    [SerializeField] private TargetCore _core;

    void Start()
    {
        //ビルが壊れたら、ビルを非アクティブにする
        _core
            .IsBroke
            .Where(x => x == true)
            .Select(x => x == false)
            .Subscribe(this.gameObject.SetActive)
            .AddTo(this.gameObject);
    }
}