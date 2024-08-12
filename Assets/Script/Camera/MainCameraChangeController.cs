using System;
using Cinemachine;
using UniRx;
using UnityEngine;
using Zenject;

public class MainCameraChangeController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _missileLookAtCamera;
    [SerializeField] private CinemachineVirtualCamera _buildingLookAtCamera;
    [SerializeField] private float _duration;
    [Inject] private IInputEventProvider _input;
    
    void Start()
    {
        _input
            .IsButtonPush
            .SkipLatestValueOnSubscribe()
            .FirstOrDefault()
            .Delay(TimeSpan.FromSeconds(_duration))
            .Subscribe(_ =>
            {
                _missileLookAtCamera.gameObject.SetActive(false);
                _buildingLookAtCamera.gameObject.SetActive(true);
            })
            .AddTo(this.gameObject);
    }
}
