using System;
using System.Collections.Generic;

public class ItemCellSelection
{
    public event Action<ItemCell> OnSelected = delegate { };
    
    public ItemCellSelection(IEnumerable<ItemCell> itemCells)
    {
        foreach (var itemCell in itemCells)
        {
            itemCell.Listner = () => OnSelected.Invoke(itemCell);
        }
    }
}