using UniRx;
using UnityEngine;

public class MissileVisibility : MonoBehaviour
{
    [SerializeField] private MissileCore _core;
    [SerializeField] private GameObject _object;
    
    void Start()
    {
        _core
            .IsBroke
            .Where(x=>x==true)
            .Select(x=>x==false)
            .Subscribe(_object.SetActive)
            .AddTo(this.gameObject);
    }
}