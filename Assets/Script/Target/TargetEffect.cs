using UniRx;
using UnityEngine;

public class TargetEffect : MonoBehaviour
{
   [SerializeField] private TargetCore _core;
   [SerializeField] private ParticleSystem _particle;

   private void Start()
   {
      _core
         .IsBroke
         .Where(x=>x==true)   
         .Subscribe(_ => Instantiate(_particle, transform.position,Quaternion.identity))
         .AddTo(this);
   }
}
