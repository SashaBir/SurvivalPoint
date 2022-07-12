using System;
using System.Collections.Generic;

public class Inventory : IInventory<IItem>
{
    public event Action<IItem> OnAdded = delegate { };

    public event Action<IItem> OnRemoved = delegate { };

    private readonly IList<IItem> _items;

    private uint _lenght;

    public Inventory(int lenght = 0)
    {
        _lenght = (uint)lenght;
        _items = new List<IItem>(lenght);
    }

    public void Add(IItem item)
    {
        if (_lenght == 0)
        {
            return;
        }
        
        _items.Add(item);
        OnAdded.Invoke(item);
        
        item.Hide();
    }

    public void Remove(IItem item)
    {
        if (_lenght == 0)
        {
            return;
        }

        if (_items.Contains(item) == false)
        {
            return;
        }

        OnRemoved.Invoke(item);
        _items.Remove(item);
        
        item.Show();
    }
}
