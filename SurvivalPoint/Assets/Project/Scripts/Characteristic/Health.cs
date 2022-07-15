using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour, IHealable<int>, IDamageable<int>, IExecutorLastAction
{
    [SerializeField] private int _health;

    public event Action<int> OnChanged = delegate { }; 

    public void Heal(int value)
    {
        _health += value;
    }

    public void Damage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            // 0 - minimum
            OnChanged.Invoke(0);
            
            ExecutableBeforeDestroyed?.Invoke();
            Destroy(gameObject);
        }
        
        OnChanged.Invoke(_health);
    }

    public Action ExecutableBeforeDestroyed { private get; set; }
}