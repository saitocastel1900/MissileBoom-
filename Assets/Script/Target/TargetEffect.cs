using UniRx;
using UnityEngine;

/// <summary>
/// ビルのエフェクトを管理する
/// </summary>
public class TargetEffect : MonoBehaviour
{
    /// <summary>
    /// ビル
    /// </summary>
    [SerializeField] private TargetCore _core;

    /// <summary>
    /// 壊れたビル
    /// </summary>
    [SerializeField] private Transform _brokeEffect;

    private void Start()
    {
        //ビルが破壊されたら、ビルを木っ端みじんにする
        _core
            .IsBroke
            .Where(x => x == true)
            .Subscribe(_ => { EffectPlay(); })
            .AddTo(this.gameObject);
    }

    //TODO:ここはEffectを再生するだけにしたい。なんで分離必要かな
    [SerializeField] private float _force;
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _radius;
    [SerializeField] private float _modifier;
    [SerializeField] private ForceMode _forceMode;

    /// <summary>
    /// エフェクトを再生する
    /// </summary>
    private void EffectPlay()
    {
        Transform broke = Instantiate(_brokeEffect, transform.position, transform.rotation);
        broke.localScale = transform.localScale;

        foreach (var rigidbody in broke.GetComponentsInChildren<Rigidbody>())
        {
            rigidbody.AddExplosionForce(_force, transform.position + _position, _radius, _modifier, _forceMode);
        }
    }
}