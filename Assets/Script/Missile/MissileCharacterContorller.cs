using UnityEngine;

/// <summary>
/// ミサイルのRigidbodyを管理する
/// </summary>
public class MissileCharacterContorller : MonoBehaviour
{
    /// <summary>
    /// Rigidbody
    /// </summary>
    [SerializeField] private Rigidbody _rigidbody;
    
    /// <summary>
    /// 動かす
    /// </summary>
    /// <param name="speed">速度</param>
    public void Move(float speed)
    {
        _rigidbody.velocity = transform.forward * speed;
    }
}
