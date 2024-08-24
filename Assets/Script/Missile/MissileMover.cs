using UniRx;
using UnityEngine;

/// <summary>
/// ミサイルの移動を管理する
/// </summary>
public class MissileMover : MonoBehaviour
{
    /// <summary>
    /// ミサイル
    /// </summary>
    [SerializeField] private MissileCore _core;
    
    /// <summary>
    /// ミサイルのRigidbodyを管理する
    /// </summary>
    [SerializeField] private MissileCharacterContorller _controller;
    
    /// <summary>
    /// ミサイルの移動速度
    /// </summary>
    [SerializeField] private float _speed = 100f;
    
    void Start()
    {
        //ミサイルが発射されたら、移動する
        Observable
            .EveryFixedUpdate()
            .SelectMany(_ => _core.OnInitialized)
            .Subscribe(_=>_controller.Move(_speed));
    }
}