using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class UiInventory : MonoBehaviour
{
    [SerializeField] private Button[] _items;
    
    private IInventory<IItem> _inventory;

    [Inject]
    private void Construct(IInventory<IItem> inventory)
    {
        _inventory = inventory;
    }

    private void Awake()
    {
        _inventory.OnAdded += Add;
        _inventory.OnRemoved += Remove;
    }

    private void OnDestroy()
    {
        _inventory.OnAdded -= Add;
        _inventory.OnRemoved -= Remove;
    }

    public IItem Current { get; private set; }

    public IItem TakeCurrent()
    {
        return Current;
    }

    private void Add(IItem item)
    {
        _items[0].image.sprite = item.Icon;
    }
    
    private void Remove(IItem item)
    {
        
    }
}