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

    public void Add(IItem item)
    {
        var itemCell = _itemCells
            .Where(i => i.IsEmpty == false)
            .FirstOrDefault(i => i.ItemSlot.Item.Type == item.Type);
        
        Action<IItem> action = itemCell == null ? AddNew : AddExisting;
        action.Invoke(item);
    }
    
    public void Remove(IItem item)
    {
        var itemCell = _itemCells.First(i => i.ItemSlot.Item == item);
        itemCell.ItemSlot.Reduce();
        
        Action<IItem> action = itemCell.IsEmpty == true ? RemoveFull : RemoveExisting;
        action.Invoke(itemCell.ItemSlot.Item);
    }

    private void AddNew(IItem item)
    {
        var itemCell = _itemCells.FirstOrDefault(i => i.IsEmpty == true);
        itemCell.ItemSlot = new ItemSlot(item);
        
        UpdateViewer(itemCell);
    }
    
    private void AddExisting(IItem item)
    {
        Debug.Log("AddExisting");
        var itemCell = _itemCells.FirstOrDefault(i => i.ItemSlot.Item.Type == item.Type);
        itemCell.ItemSlot.Add();
        
        UpdateViewer(itemCell);
    }
    
    private void RemoveFull(IItem item)
    {
        Debug.Log("RemoveFull");
        var itemCell = _itemCells.First(i => i.ItemSlot.Item == item);
        itemCell.ItemSlot = null;
            
        UpdateViewer(itemCell);
    }
    
    private void RemoveExisting(IItem item)
    {
        var itemCell = _itemCells.First(i => i.ItemSlot.Item == item);
        UpdateViewer(itemCell);
    }

    private void UpdateViewer(ItemCell itemCell)
    {
        itemCell.UpdateIcon();
        itemCell.UpdateText();
    }
}