using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Stick : MonoBehaviour, IItem
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _prefab;
    
    public GameObject Prefab => _prefab;

    public Sprite Icon => _sprite;
    
    public void Collect()
    {
        Destroy(gameObject);
    }
}
