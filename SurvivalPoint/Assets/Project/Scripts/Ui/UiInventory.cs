using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class UiInventory : MonoBehaviour
{
    [SerializeField] private Button[] _items;
    [SerializeField] private SelectionItem _selectionItem;
    
    private IInventory<IItem> _inventory;

    [Inject]
    private void Construct(IInventory<IItem> inventory)
    {
        _inventory = inventory;
    }

    private void OnEnable()
    {
        _inventory.OnAdded += Add;
        _inventory.OnRemoved += Remove;
        
        _selectionItem.Enable();
    }

    private void OnDisable()
    {
        _inventory.OnAdded -= Add;
        _inventory.OnRemoved -= Remove;
        
        _selectionItem.Disable();
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