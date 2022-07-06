using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Apple : MonoBehaviour, IItem
{
    public GameObject Prefab { get; }
    
    public Sprite Icon { get; }
    
    public void Collect()
    {
        Destroy(gameObject);
    }
}