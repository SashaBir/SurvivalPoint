using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Apple : MonoBehaviour, IItemProvider, IShootable
{
    [field: SerializeField] public Item Item { get; private set; }
    
    [field: SerializeField] public Rigidbody2D SelfRigidbody { get; private set; }
    
    [field: SerializeField] public float Lenght { get; private set; }
}