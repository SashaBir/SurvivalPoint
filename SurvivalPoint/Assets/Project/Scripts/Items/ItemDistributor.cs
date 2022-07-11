using System;
using UnityEngine;

[RequireComponent(typeof(IExecutorLastAction))]
public class ItemDistributor : MonoBehaviour
{
    [Header("Collection")]
    [SerializeField] private GameObject[] _items;
    
    [Header("Scatter")]
    [SerializeField, Range(0, 1)] private float _ratio;
    [SerializeField] private float _radius;

    private IExecutorLastAction _executorLastAction;

    private void Awake()
    {
        _executorLastAction = GetComponent<IExecutorLastAction>();
        _executorLastAction.ExecutableBeforeDestroyed = () =>
        {
            if (CanScatter == false)
            {
                return;
            }
        
            Scatter();
        };
        
        GetComponent<Health>().Damage(10);
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