using System;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ミサイルの発射を管理する
/// </summary>
public class MissileLaunchManager : MonoBehaviour
{
    /// <summary>
    /// IInputEventProvider
    /// </summary>
    [Inject] private IInputEventProvider _input;
    
    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    /// <summary>
    /// ミサイル
    /// </summary>
    [SerializeField] private MissileCore _missile;
    
    /// <summary>
    /// ミサイルの目標
    /// </summary>
    [SerializeField] private Transform _target;
    
    /// <summary>
    /// ボタンが押されてからミサイルの発射までの待機時間
    /// </summary>
    [SerializeField] private float duraton;
    
    void Start()
    {
        _audioManager.PlayBGM(BgmData.BGM.Battle);
        
        //ボタンが押されたら、ミサイルを発射する
        _input
            .IsButtonPush
            .SkipLatestValueOnSubscribe()
            .FirstOrDefault()
            .Do(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.ButtonClick))
            .Delay(TimeSpan.FromSeconds(duraton))
            .Subscribe(_ => _missile.InitializeMissile(_target));
    }
}