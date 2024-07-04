using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BgmDataBase")]
public class BgmDataBase : ScriptableObject
{
    [SerializeField]
    List<BgmData> _BgmDataList = new List<BgmData>();

    public BgmData GetBgmData(BgmData.BGM bgm)
    {
        var bgmData = _BgmDataList.FirstOrDefault(clip => clip.bgm == bgm);
        return bgmData;
    }
}
