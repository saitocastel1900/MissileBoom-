using System;
using UnityEngine;

/// <summary>
/// SEを登録・調整する
/// </summary>
[Serializable]
public class SoundEffectData
{
    /// <summary>
    /// SoundEffectの種類
    /// </summary>
    public enum SoundEffect
    {
        ButtonClick,
        MissileLaunch,
        BuildingBreak,
        GameClear1,
        GameClear2,
        GameClear3,
        WidgetClick,
    }

    [Tooltip("音の種類をラベルで設定")] public SoundEffect se;
    [Tooltip("使用したい音を設定")] public AudioClip audioClip;
    [Range(0.0f, 1.0f), Tooltip("音量")] public float volume = 1.0f;
}