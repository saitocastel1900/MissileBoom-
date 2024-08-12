using System;
using UniRx;
using UnityEngine;
using Zenject;

public class ResultWidgetController : MonoBehaviour
{
   [Inject] private AudioManager _audioManager;
   [SerializeField] private TargetCore _target;
   [SerializeField] private ResultDisplayWidget _resultDisplayWidget;
   [SerializeField] private float _duration;
   
   private void Start()
   {
      _resultDisplayWidget.SetActive(false);
      
      _target
         .IsBroke
         .Where(x => x == true)
         .Delay(TimeSpan.FromSeconds(_duration))
         .Subscribe(_=>
         {
            _resultDisplayWidget.SetActive(true);
            _resultDisplayWidget.DisplayAnimation();
            _audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.GameClear1);
            _audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.GameClear2);
            _audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.GameClear3);
         })
         .AddTo(this.gameObject);
   }
}