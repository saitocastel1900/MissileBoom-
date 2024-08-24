using UnityEngine;

/// <summary>
/// 倒されることを定義する
/// </summary>
public interface IDieable
{
    /// <summary>
    /// 倒す
    /// </summary>
    /// <param name="pos"></param>
    public void Kill(Vector3 pos);
}
