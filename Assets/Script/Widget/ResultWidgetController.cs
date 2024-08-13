using System;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// リザルトを管理する
/// </summary>
public class ResultWidgetController : MonoBehaviour
{
   /// <summary>
   /// AudioManager
   /// </summary>
   [Inject] private AudioManager _audioManager;
   
   /// <summary>
   /// ビル
   /// </summary>
   [SerializeField] private TargetCore _target;
   
   /// <summary>
   /// リザルトを表示するクラス
   /// </summary>
   [SerializeField] private ResultDisplayWidget _resultDisplayWidget;
   
   /// <summary>
   /// ビルが壊されてからリザルトを表示するまでの時間
   /// </summary>
   [SerializeField] private float _duration;
   
   private void Start()
   {
      _resultDisplayWidget.SetActive(false);
      
      //ビルが壊されたらリザルトを表示する
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