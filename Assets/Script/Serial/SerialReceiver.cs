using UniRx;
using UnityEngine;
using Zenject;

public class SerialReceiver : MonoBehaviour
{
    [Inject] private SerialHandler _serial;

    private void Start()
    {
        Observable
            .EveryUpdate()
            .Subscribe(_=> Debug.Log(_serial.MessagesProp.Value))
            .AddTo(this.gameObject);
     }
}