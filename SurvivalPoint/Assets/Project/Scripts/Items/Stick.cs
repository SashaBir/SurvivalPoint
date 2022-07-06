using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Stick : MonoBehaviour, IItem
{
    public GameObject Prefab => gameObject;
    
    public Sprite Icon { get; }
    
    public void Collect()
    {
        Destroy(gameObject);
    }
}