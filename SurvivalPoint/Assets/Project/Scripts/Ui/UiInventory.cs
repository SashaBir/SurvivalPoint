using System;
using UnityEngine;
using Zenject;


public class UiInventory : MonoBehaviour
{
    [SerializeField] private SelectionColorItem _selectionColorItem;
    [SerializeField] private ItemCellCollection _itemCellCollection;
    
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
        
        _selectionColorItem.Enable();
        _itemCellCollection.Enable();
    }

    private void OnDisable()
    {
        _inventory.OnAdded -= Add;
        _inventory.OnRemoved -= Remove;
        
        _selectionColorItem.Disable();
        _itemCellCollection.Disable();
    }

    public IItem Current { get; private set; }

    public IItem TakeCurrent()
    {
        return Current;
    }

    private void Add(IItem item)
    {
        _itemCellCollection.Add(item);
    }
    
    private void Remove(IItem item)
    {
        
    }
}