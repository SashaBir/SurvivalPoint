using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Missile))]
public class Bullet : MonoBehaviour, IShootable
{
    public GameObject Self => gameObject;
    
    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public ItemType Type { get; private set; } 

    [field: SerializeField] public Rigidbody2D SelfRigidbody { get; private set; }
    
    [field: SerializeField] public float Speed { get; private set; }
    
    [field: SerializeField] public float Lenght { get; private set; }
    
    [field: SerializeField] public bool IsHitted { get; private set; } = false;

    [field: SerializeField] public bool CanTaken { get; private set; }

    public Missile Missile { get; private set; }

    private void Awake()
    {
        Missile = GetComponent<Missile>();
    }

    public void Take()
    {
        gameObject.SetActive(true);
    }

    public void Upload()
    {
        gameObject.SetActive(false);
    }
}