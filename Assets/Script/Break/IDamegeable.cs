using UnityEngine;

/// <summary>
/// ダメージを受けることを定義する
/// </summary>
public interface IDamegeable
{
    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="pos"></param>
    public void ApplyDamage(Transform pos);
}
