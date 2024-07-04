using UnityEngine;

public class MissileCharacterContorller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    
    public void Move(float speed)
    {
        _rigidbody.velocity = transform.forward * speed;
    }
}
