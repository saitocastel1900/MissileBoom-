using UnityEngine;
using System;
using UniRx;

/// <summary>
/// ミサイルの回転を管理する
/// </summary>
public class MissileRotater : MonoBehaviour
{
    /// <summary>
    /// ミサイル
    /// </summary>
    [SerializeField] private MissileCore _core;
    
    /// <summary>
    /// ミサイルのTransform
    /// </summary>
    [SerializeField] private Transform _transform;
    
    /// <summary>
    /// ミサイルが回転するまでの時間
    /// </summary>
    [SerializeField] private float _delaytime  = 5.0f;
    
    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField] private float _rotationSpeed = 0.025f; 
    
    void Start()
    {
        //ミサイルが発射されたら、一定時間後に目標に向く
        _core.OnInitialized
            .Delay(TimeSpan.FromSeconds(_delaytime ))
            .SelectMany(_ => Observable.EveryFixedUpdate()) 
            .Subscribe(_ => Rotate(_core.TargetTransform))
            .AddTo(this);
    }

    /// <summary>
    /// 回転する
    /// </summary>
    /// <param name="targetTransform">ビル</param>
    private void Rotate(Transform targetTransform)
    {
        var diff = targetTransform.position - _transform.position;
        var targetRot = Quaternion.LookRotation(diff);
        _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRot, _rotationSpeed);
    }
}