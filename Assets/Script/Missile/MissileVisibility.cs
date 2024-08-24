using UniRx;
using UnityEngine;

/// <summary>
/// ミサイルのアクティブを管理する
/// </summary>
public class MissileVisibility : MonoBehaviour
{
    /// <summary>
    /// ミサイル
    /// </summary>
    [SerializeField] private MissileCore _core;
    
    void Start()
    {
        //ミサイルが壊されたら、ミサイルを非アクティブにする
        _core
            .IsBroke
            .Where(x=>x==true)
            .Select(x=>x==false)
            .Subscribe(this.gameObject.SetActive)
            .AddTo(this.gameObject);
    }
}