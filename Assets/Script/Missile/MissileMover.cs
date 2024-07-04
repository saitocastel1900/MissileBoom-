using UniRx;
using UnityEngine;

public class MissileMover : MonoBehaviour
{
    [SerializeField] private MissileCore _core;
    [SerializeField] private MissileCharacterContorller _controller;
    [SerializeField] private float _speed = 100f;
    
    void Start()
    {
        Observable
            .EveryFixedUpdate()
            .SelectMany(_ => _core.OnInitialized)
            .Subscribe(_=>_controller.Move(_speed));
    }
}