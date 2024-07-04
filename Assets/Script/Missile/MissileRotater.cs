using UnityEngine;
using System;
using UniRx;

public class MissileRotater : MonoBehaviour
{
    [SerializeField] private MissileCore _core;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _delaytime  = 5.0f;
    [SerializeField] private float _rotationSpeed = 0.025f; 
    
    void Start()
    {
        _core.OnInitialized
            .Delay(TimeSpan.FromSeconds(_delaytime ))
            .SelectMany(_ => Observable.EveryFixedUpdate()) 
            .Subscribe(_ => Rotate(_core.TargetTransform))
            .AddTo(this);
    }

    private void Rotate(Transform targetTransform)
    {
        var diff = targetTransform.position - _transform.position;
        var targetRot = Quaternion.LookRotation(diff);
        _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRot, _rotationSpeed);
    }
}