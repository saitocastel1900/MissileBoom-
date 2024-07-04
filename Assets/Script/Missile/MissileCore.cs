using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MissileCore : MonoBehaviour
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IObservable<Unit> OnInitialized => _initializedSubject;
    private readonly AsyncSubject<Unit> _initializedSubject = new AsyncSubject<Unit>();
    
    /// <summary>
    /// 
    /// </summary>
    public IReactiveProperty<bool> IsBroke => _isBroke;
    private BoolReactiveProperty _isBroke = new BoolReactiveProperty(false);

    /// <summary>
    /// 
    /// </summary>
    public Transform TargetTransform=>_targetTransform;
    private Transform _targetTransform;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Collider _collider;
    
    private void Awake()
    {
        _initializedSubject.Subscribe(_ =>
        {
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
