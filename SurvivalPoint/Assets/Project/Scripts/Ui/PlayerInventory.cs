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

    public T TakeCurrent<T>() where T : class
    {
        T result = Current.GetComponent<T>();
        IItemProvider itemProvider = Current.GetComponent<IItemProvider>();

        
        return result;
    }

    private void Add(IItemProvider itemProvider)
    {
        _itemCellCollection.Add(itemProvider);
    }
    
    private void Remove(IItemProvider itemProvider)
    {
        print("Remove");
    }

    private void SetCurrent(ItemSlot itemSlot)
    {
        Current = itemSlot?.Item.Prefab;
    }
}