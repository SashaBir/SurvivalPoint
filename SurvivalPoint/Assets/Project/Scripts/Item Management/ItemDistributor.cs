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

    private float RandomCoordinate => UnityEngine.Random.Range(0f, _radius);
    
    private bool CanScatter => UnityEngine.Random.Range(0f, _ratio) <= _ratio;

    private void Scatter()
    {
        int i = 0;
        foreach (var item in _items)
        {
            Vector2 position = (Vector2)transform.position + new Vector2(RandomCoordinate, RandomCoordinate);

            var go = Instantiate(item, position, Quaternion.identity);
            go.name = i.ToString();
            i++;
        }
    }
}