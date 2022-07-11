using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour, IHealable<int>, IDamageable<int>, IExecutorLastAction
{
    [SerializeField] private int _health;

    public void Heal(int value)
    {
        _health += value;
    }

    public void Damage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            ExecutableBeforeDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }

    public Action ExecutableBeforeDestroyed { private get; set; }
}