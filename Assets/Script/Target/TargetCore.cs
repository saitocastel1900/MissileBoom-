using UniRx;
using UnityEngine;

/// <summary>
/// ビルのプロパティを管理する
/// </summary>
public class TargetCore : MonoBehaviour , IBreakable
{
    /// <summary>
    /// ビルが壊れたか
    /// </summary>
    public IReactiveProperty<bool> IsBroke => _isBroke;
    private BoolReactiveProperty _isBroke = new BoolReactiveProperty(false);

    /// <summary>
    /// 壊す
    /// </summary>
    public void Break()
    {
        _isBroke.Value = true;
    }
}