using UniRx;
using UnityEngine;

public class TargetCore : MonoBehaviour , IBreakable
{
    public IReactiveProperty<bool> IsBroke => _isBroke;
    private BoolReactiveProperty _isBroke = new BoolReactiveProperty(false);

    public void Break()
    {
        _isBroke.Value = true;
    }
}