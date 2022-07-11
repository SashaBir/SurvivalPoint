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
        ItemCell itemCell = _itemCells.FirstOrDefault(i => i.IsEmpty == true);
        if (itemCell.IsEmpty == true)
        {
            Debug.Log("awdwa");
            itemCell.ItemSlot = new ItemSlot(item);
            itemCell.UpdateIcon();
            itemCell.UpdateText();
            
            return;
        }
        
        itemCell.UpdateIcon();
        itemCell.UpdateText();
        
        itemCell.ItemSlot.Add();
    }
}