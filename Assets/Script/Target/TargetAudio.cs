using UniRx;
using UnityEngine;
using Zenject;

public class TargetAudio : MonoBehaviour
{
    [SerializeField] private TargetCore _core;
    [Inject] private AudioManager _audioManager;
        
    void Start()
    {
        _core
            .IsBroke
            .Where(x => x == true)
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.BuildingBreak))
            .AddTo(this.gameObject);
    }
}
