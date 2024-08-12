using UniRx;
using UnityEngine;

public class TargetEffect : MonoBehaviour
{
   
   [SerializeField] private TargetCore _core;
   [SerializeField] private Transform _brokeEffect;

   //TODO:ここはEffectを再生するだけにしたい。なんで分離必要かな
   [SerializeField] private float _force;
   [SerializeField] private Vector3 _position;
   [SerializeField] private float _radius;
   [SerializeField] private float _modifier;
   [SerializeField] private ForceMode _forceMode;
   
   private void Start()
   {
      _core
         .IsBroke
         .Where(x => x == true)
         .Subscribe(_ =>
         {
            EffectPlay();
         })
         .AddTo(this.gameObject);
   }

   private void EffectPlay()
   {
      Transform broke = Instantiate(_brokeEffect, transform.position, transform.rotation);
      broke.localScale = transform.localScale;

      foreach (var rigidbody in broke.GetComponentsInChildren<Rigidbody>())
      {
         rigidbody.AddExplosionForce(_force, transform.position+_position, _radius, _modifier, _forceMode);
      }
   }
}
