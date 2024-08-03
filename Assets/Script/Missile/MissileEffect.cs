using UniRx;
using UnityEngine;

public class MissileEffect : MonoBehaviour
{
    [SerializeField] private MissileCore _core;
    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private ParticleSystem _fireEffect;
    [SerializeField] private ParticleSystem _explosionEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        _core
            .OnInitialized
            .Subscribe(_ =>
            {
                _smokeEffect.Play();
                _fireEffect.Play();
            })
            .AddTo(this.gameObject);
        
        _core
            .IsBroke
            .Where(x=>x==true)   
            .Subscribe(_ => Instantiate(_explosionEffect, transform.position,Quaternion.identity))
            .AddTo(this);
    }
}
