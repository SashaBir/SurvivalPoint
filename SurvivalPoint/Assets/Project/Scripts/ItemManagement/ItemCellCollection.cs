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

    public void Add(Item item)
    {
        var itemCell = _itemCells
            .Where(i => i.IsEmpty == false)
            .FirstOrDefault(i => i.ItemSlot.Item.Type == item.Type);
        
        Action<Item> action = itemCell == null ? AddNew : AddExisting;
        action.Invoke(item);
    }

    public void AddNew(Item item)
    {
        var itemCell = _itemCells.FirstOrDefault(i => i.IsEmpty == true);
        itemCell.ItemSlot = new ItemSlot(item);
        
        UpdateViewer(itemCell);
    }
    
    public void AddExisting(Item item)
    {
        var itemCell = _itemCells.FirstOrDefault(i => i.ItemSlot.Item.Type == item.Type);
        itemCell.ItemSlot.Add();
        
        UpdateViewer(itemCell);
    }

    public void Remove()
    {
        
    }

    private void UpdateViewer(ItemCell itemCell)
    {
        itemCell.UpdateIcon();
        itemCell.UpdateText();
    }
}