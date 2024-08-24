using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ミサイルの音を管理する
/// </summary>
public class MissileAudio : MonoBehaviour
{
    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    /// <summary>
    /// ミサイル
    /// </summary>
    [SerializeField] private MissileCore _core;
    
    private void Start()
    {
        //ミサイルが発射されたら、発射音を流す
        _core
            .OnInitialized
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.MissileLaunch))
            .AddTo(this.gameObject);
    }
}
