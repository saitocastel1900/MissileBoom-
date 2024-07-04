using UniRx;
using UnityEngine;
using Zenject;

public class MissileAudio : MonoBehaviour
{
    [SerializeField] private MissileCore _core;
    [Inject] private AudioManager _audioManager;
    
    private void Start()
    {
        _core
            .OnInitialized
            .Subscribe(_=>_audioManager.PlayBGM(BgmData.BGM.Battle))
            .AddTo(this.gameObject);
    }
}
