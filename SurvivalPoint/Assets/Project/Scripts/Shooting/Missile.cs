using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    [SerializeField, Min(0)] private int _damage;

    private bool _isDamage = false;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable<int> damageable) == false)
        {
            return;
        }

        if (_isDamage == false)
        {
            return;
        }
        
        damageable.Damage(_damage);
        Destroy(gameObject);
    }
}