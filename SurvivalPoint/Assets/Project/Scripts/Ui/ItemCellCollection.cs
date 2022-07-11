using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemCellCollection
{
    [SerializeField] private ItemCell[] _itemCells;
    [SerializeField] private int _lenght;
    
    public event Action<ItemStack> OnSelected = delegate { };

    public void Enable()
    {
        foreach (var itemCell in _itemCells)
        {
            itemCell.AddListner(() => OnSelected.Invoke(itemCell.ItemStack));
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
        ItemCell itemCell = _itemCells.FirstOrDefault(i => i.ItemStack.Item != item);
        if (itemCell is null)
        {
            itemCell.ItemStack = new ItemStack(item);
            return;
        }
        
        itemCell.ItemStack.Add();
    }
}