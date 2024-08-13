using System;
using Cinemachine;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// カメラを切り替える
/// </summary>
public class MainCameraChangeController : MonoBehaviour
{
    /// <summary>
    /// ミサイルに向いているカメラ
    /// </summary>
    [SerializeField] private CinemachineVirtualCamera _missileLookAtCamera;
    
    /// <summary>
    /// ビルに向いているカメラ
    /// </summary>
    [SerializeField] private CinemachineVirtualCamera _buildingLookAtCamera;
    
    /// <summary>
    /// 切り替え始めるまでの時間
    /// </summary>
    [SerializeField] private float _duration;
    
    /// <summary>
    /// IInputEventProvider
    /// </summary>
    [Inject] private IInputEventProvider _input;
    
    private void Start()
    {
        //発射ボタンが押されたら、カメラを切り替える
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
