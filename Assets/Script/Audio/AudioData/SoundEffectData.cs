using System;
using UnityEngine;

/// <summary>
/// SEを登録・調整するクラス
/// </summary>
[Serializable]
public class SoundEffectData
{
    /// <summary>
    /// 用途に応じたラベルを設定
    /// </summary>
    public enum SoundEffect
    {
        WidgetClick,
    }

    [Tooltip("音の種類をラベルで設定")] public SoundEffect se;
    [Tooltip("使用したい音を設定")] public AudioClip audioClip;
    [Range(0.0f, 1.0f), Tooltip("音量")] public float volume = 1.0f;
}