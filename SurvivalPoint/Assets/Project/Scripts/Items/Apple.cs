using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Apple : MonoBehaviour, IItemProvider
{
    [field: SerializeField] public Item Item { get; private set; }
}