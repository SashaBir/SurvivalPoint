using System;
using UnityEngine;

public class ItemDistributor : MonoBehaviour
{
    [Header("Collection")]
    [SerializeField] private GameObject[] _items;
    
    [Header("Scatter")]
    [SerializeField, Range(0, 1)] private float _ratio;
    [SerializeField] private float _radius;
    
    private void OnDisable()
    {
        if (CanScatter == false)
        {
            return;
        }
        
        Scatter();
    }

    private bool CanScatter => UnityEngine.Random.Range(0f, _ratio) <= _ratio;
    
    private void Scatter()
    {
        foreach (var item in _items)
        {
            float randomRadius = UnityEngine.Random.Range(0f, _radius);
            Vector2 position = (Vector2)transform.position + Vector2.one * randomRadius;

            var go = Instantiate(item, position, Quaternion.identity);
        }
    }
}