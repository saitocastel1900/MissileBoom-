using Commons.Extensions;
using Commons.Utility;
using UnityEngine;
using UnityEngine.Serialization;


public class AudioManagerComponent : MonoBehaviour
    {
        /// <summary>
        /// BGMのAudioSource
        /// </summary>
        [SerializeField] private AudioSource _bgmAudioSourceSource;

        /// <summary>
        /// SEのAudioSource
        /// </summary>
        [SerializeField] private AudioSource _seAudioSourceSource;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private BgmDataBase _bgmDataBase;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private SoundEffectDataBase _soundEffectDataBase;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField, Range(0.0f, 1.0f), Tooltip("マスタ-音量")]
        public float masterVolume = 1.0f;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField, Range(0.0f, 1.0f), Tooltip("BGMのマスタ音量")]
        public float bgmMasterVolume = 1.0f;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField, Range(0.0f, 1.0f), Tooltip("SEのマスタ音量")]
        public float seMasterVolume = 1.0f;

        public void Start()
        {
            _bgmAudioSourceSource = InitializeAudioSource(_bgmAudioSourceSource, true);
            _seAudioSourceSource = InitializeAudioSource(_seAudioSourceSource, false);
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private AudioSource InitializeAudioSource(AudioSource audioSource, bool isLoop = false)
        {
            audioSource.loop = isLoop;
            audioSource.playOnAwake = false;

            return audioSource;
        }

        /// <summary>
        /// BGMを流す
        /// </summary>
        public void PlayBGM(BgmData.BGM bgm)
        {
            var bgmData = _bgmDataBase.GetBgmData(bgm);
            
            if (bgmData == null)
            {
                DebugUtility.Log(bgm + "は見つかりません");
                return;
            }
            
            _bgmAudioSourceSource.volume = Mathf.Clamp(bgmData.volume * bgmMasterVolume * masterVolume, 0.0f, 1.0f);
            _bgmAudioSourceSource.Play(bgmData.audioClip);
        }

        /// <summary>
        /// SEを流す
        /// </summary>
        /// <param name="soundEffect">流したいSE</param>
        public void PlaySoundEffect(SoundEffectData.SoundEffect soundEffect)
        {
            var soundEffectData = _soundEffectDataBase.GetSoundEffectData(soundEffect);
            
            if (soundEffectData == null)
            {
                DebugUtility.Log(soundEffect + "は見つかりません");
                return;
            }
            
            
            _seAudioSourceSource.volume = Mathf.Clamp(soundEffectData.volume * seMasterVolume * masterVolume, 0.0f, 1.0f);
            _seAudioSourceSource.PlayOneShot(soundEffectData.audioClip);
        }
    }
