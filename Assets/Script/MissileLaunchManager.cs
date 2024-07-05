using UniRx;
using UnityEngine;
using Zenject;

public class MissileLaunchManager : MonoBehaviour
{
    [Inject] private IInputEventProvider _input;
    [SerializeField] private MissileCore _missile;
    [SerializeField] private Transform _target;
    
    void Start()
    {
        _input
            .IsButtonPush
            .SkipLatestValueOnSubscribe()
            .FirstOrDefault()
            .Subscribe(_ => _missile.InitializeMissile(_target));
    }
}