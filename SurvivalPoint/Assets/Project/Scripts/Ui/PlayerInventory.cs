using System;
using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour
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
        _selectionColorItem.Enable();
        _itemCellCollection.Enable();
        
        _inventory.OnAdded += Add;
        _inventory.OnRemoved += Remove;
        
        _itemCellCollection.OnSelected += SetCurrent;
    }

    private void OnDisable()
    {
        _selectionColorItem.Disable();
        _itemCellCollection.Disable();
        
        _inventory.OnAdded -= Add;
        _inventory.OnRemoved -= Remove;
        
        _itemCellCollection.OnSelected -= SetCurrent;
    }

    public IItem Current { get; private set; }

    public void KickCurrent()
    {
        _inventory.Remove(Current);
    }

    private void Add(IItem item)
    {
        _itemCellCollection.Add(item);
    }
    
    private void Remove(IItem item)
    {
        print("Remove");
        _itemCellCollection.Remove(Current);
    }

    private void SetCurrent(ItemSlot itemSlot)
    {
        Current = itemSlot?.Item;
        print(Current);
    }
}