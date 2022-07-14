﻿using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Apple : MonoBehaviour, IShootable, IEdible
{
    public GameObject Self => gameObject;
    
    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public ItemType Type { get; private set; } 

    [field: SerializeField] public Rigidbody2D SelfRigidbody { get; private set; }
    
    [field: SerializeField] public float Lenght { get; private set; }

    [field: SerializeField] public bool CanTaken { get; private set; }
    
    [field: SerializeField] public int CountHealthRestored { get; private set; }
    
    public void Take()
    {
        gameObject.SetActive(true);
    }

    public void Upload()
    {
        gameObject.SetActive(false);
    }
}