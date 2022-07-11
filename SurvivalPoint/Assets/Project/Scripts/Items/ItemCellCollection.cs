using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemCellCollection
{
    [SerializeField] private ItemCell[] _itemCells;
    
    public event Action<ItemSlot> OnSelected = delegate { };

    public void Enable()
    {
        foreach (var itemCell in _itemCells)
        {
            itemCell.AddListner(() => OnSelected.Invoke(itemCell.ItemSlot));
        }
    }

    public void Disable()
    {
        foreach (var itemCell in _itemCells)
        {
            itemCell.RemoveAllListner();
        }
    }

    public void Add(IItemProvider itemProvider)
    {
        var itemCell = _itemCells
            .Where(i => i.IsEmpty == false)
            .FirstOrDefault(i => i.ItemSlot.Item.ItemType == itemProvider.Item.ItemType);
        
        Action<IItemProvider> action = itemCell == null ? AddNew : AddExisting;
        action.Invoke(itemProvider);
    }

    public void AddNew(IItemProvider itemProvider)
    {
        var itemCell = _itemCells.FirstOrDefault(i => i.IsEmpty == true);
        itemCell.ItemSlot = new ItemSlot(itemProvider.Item);
        
        UpdateViewer(itemCell);
        
        Debug.Log("AddNew");
    }
    
    public void AddExisting(IItemProvider itemProvider)
    {
        var itemCell = _itemCells.FirstOrDefault(i => i.ItemSlot.Item.ItemType == itemProvider.Item.ItemType);
        itemCell.ItemSlot.Add();
        
        UpdateViewer(itemCell);
        
        Debug.Log("AddExisting");
    }

    private void UpdateViewer(ItemCell itemCell)
    {
        itemCell.UpdateIcon();
        itemCell.UpdateText();
    }
}