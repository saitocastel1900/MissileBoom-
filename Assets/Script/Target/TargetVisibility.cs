using UniRx;
using UnityEngine;

public class TargetVisibility : MonoBehaviour
{
    [SerializeField] private TargetCore _core;

    void Start()
    {
        _core
            .IsBroke
            .Where(x => x == true)
            .Select(x => x == false)
            .Subscribe(this.gameObject.SetActive)
            .AddTo(this.gameObject);
    }
}