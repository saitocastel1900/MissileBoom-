using System;
using UnityEngine;

[Serializable]
public class BgmData
{
    /// <summary>
    /// 用途に応じたラベルを設定
    /// </summary>
    public enum BGM
    {
       Battle,
    }

    [Tooltip("音の種類をラベルで設定")]
    public BGM bgm;
    [Tooltip("使用したい音を設定")]
    public AudioClip audioClip;
    [Range(0.0f, 1.0f), Tooltip("音量")] public float volume = 1.0f;
}
