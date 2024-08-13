using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ビルの音を管理する
/// </summary>
public class TargetAudio : MonoBehaviour
{
    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    /// <summary>
    /// ビル
    /// </summary>
    [SerializeField] private TargetCore _core;
        
    void Start()
    {
        //ビルが壊れたら、爆発音を流す
        _core
            .IsBroke
            .Where(x => x == true)
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.BuildingBreak))
            .AddTo(this.gameObject);
    }
}
