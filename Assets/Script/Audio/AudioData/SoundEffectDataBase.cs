using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SoundEffectDataBase")]
public class SoundEffectDataBase : ScriptableObject
{
    [SerializeField]
    List<SoundEffectData> _SoundEffectDataList = new List<SoundEffectData>();

    public SoundEffectData GetSoundEffectData(SoundEffectData.SoundEffect se)
    {
        var soundEffectData = _SoundEffectDataList.FirstOrDefault(clip => clip.se == se);
        return soundEffectData;
    }
}
