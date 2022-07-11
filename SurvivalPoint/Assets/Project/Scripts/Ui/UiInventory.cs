using System;
using UnityEngine;
using Zenject;


public class UiInventory : MonoBehaviour
{
    [SerializeField] private SelectionColorItem _selectionColorItem;
    [SerializeField] private ItemCellCollection _itemCellCollection;
    
    private IInventory<IItemProvider> _inventory;

    [Inject]
    private void Construct(IInventory<IItemProvider> inventory)
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

    public IItemProvider Current { get; private set; }

    public IItemProvider TakeCurrent()
    {
        return Current;
    }

    private void Add(IItemProvider itemProvider)
    {
        _itemCellCollection.Add(itemProvider);
    }
    
    private void Remove(IItemProvider itemProvider)
    {
        
    }
}