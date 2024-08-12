using System;
using UniRx;
using UnityEngine;
using Zenject;

public class MissileLaunchManager : MonoBehaviour
{
    [Inject] private IInputEventProvider _input;
    [Inject] private AudioManager _audioManager;
    [SerializeField] private MissileCore _missile;
    [SerializeField] private Transform _target;
    [SerializeField] private float duraton;
    
    void Start()
    {
        _audioManager.PlayBGM(BgmData.BGM.Battle);
        
        _input
            .IsButtonPush
            .SkipLatestValueOnSubscribe()
            .FirstOrDefault()
            .Do(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.ButtonClick))
            .Delay(TimeSpan.FromSeconds(duraton))
            .Subscribe(_ => _missile.InitializeMissile(_target));
    }
}