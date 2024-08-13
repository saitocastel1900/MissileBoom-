using UniRx;
using UnityEngine;

/// <summary>
/// ミサイルのエフェクトを管理する
/// </summary>
public class MissileEffect : MonoBehaviour
{
    /// <summary>
    /// ミサイル
    /// </summary>
    [SerializeField] private MissileCore _core;
    
    /// <summary>
    /// 煙のエフェクト
    /// </summary>
    [SerializeField] private ParticleSystem _smokeEffect;
    
    /// <summary>
    /// 炎のエフェクト
    /// </summary>
    [SerializeField] private ParticleSystem _fireEffect;
    
    /// <summary>
    /// 爆発のエフェクト
    /// </summary>
    [SerializeField] private ParticleSystem _explosionEffect;
    
    void Start()
    {
        //ミサイルが発射されたら、煙と炎のエフェクトを再生する
        _core
            .OnInitialized
            .Subscribe(_ =>
            {
                _smokeEffect.Play();
                _fireEffect.Play();
            })
            .AddTo(this.gameObject);
        
        //ミサイルが壊れたら、爆発する
        _core
            .IsBroke
            .Where(x=>x==true)   
            .Subscribe(_ => Instantiate(_explosionEffect, transform.position,Quaternion.identity))
            .AddTo(this);
    }
}
