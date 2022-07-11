using System;
using UnityEngine;
using Zenject;


public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private SelectionColorItem _selectionColorItem;
    [SerializeField] private ItemCellCollection _itemCellCollection;
    
    private IInventory<Item> _inventory;
//
    [Inject]
    private void Construct(IInventory<Item> inventory)
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

    public GameObject Current { get; private set; }

    private void Add(Item itemProvider)
    {
        _itemCellCollection.Add(itemProvider);
    }
    
    private void Remove(Item itemProvider)
    {
        print("Remove");
    }

    private void SetCurrent(ItemSlot itemSlot)
    {
        Current = itemSlot.Item.Prefab;
        print(Current);
    }
}