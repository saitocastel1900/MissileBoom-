using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// ミサイルのプロパティを管理する
/// </summary>
public class MissileCore : MonoBehaviour
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IObservable<Unit> OnInitialized => _initializedSubject;
    private readonly AsyncSubject<Unit> _initializedSubject = new AsyncSubject<Unit>();
    
    /// <summary>
    /// ミサイルが壊れたか
    /// </summary>
    public IReactiveProperty<bool> IsBroke => _isBroke;
    private BoolReactiveProperty _isBroke = new BoolReactiveProperty(false);

    /// <summary>
    /// 目標のTransform
    /// </summary>
    public Transform TargetTransform=>_targetTransform;
    private Transform _targetTransform;

    /// <summary>
    /// Collider
    /// </summary>
    [SerializeField] private Collider _collider;
    
    private void Awake()
    {
        _initializedSubject.Subscribe(_ =>
        {
            //何か接触したら&&IBreakableを持っていたら、そのオブジェクトを壊す
            //そして、ミサイルも壊す
            _collider
                .OnTriggerEnterAsObservable()
                .Subscribe(target =>
                {
                    var breakable = target.GetComponent<IBreakable>();
                    if (breakable != null)
                    {
                        breakable.Break();
                        _isBroke.Value = true;
                    }
                })
                .AddTo(this);
        }).AddTo(this.gameObject);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void InitializeMissile(Transform targetTransform)
    {
        _targetTransform = targetTransform;
        _initializedSubject.OnNext(Unit.Default);
        _initializedSubject.OnCompleted();
    }
}
