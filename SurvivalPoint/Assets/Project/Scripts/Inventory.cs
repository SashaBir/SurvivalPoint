using System;
using System.Collections.Generic;

public class Inventory : IInventory<Item>
{
    public event Action<Item> OnAdded = delegate { };

    public event Action<Item> OnRemoved = delegate { };

    private readonly IList<Item> _items;

    private uint _lenght;

    public Inventory(int lenght = 0)
    {
        _lenght = (uint)lenght;
        _items = new List<Item>(lenght);
    }

    public void Add(Item item)
    {
        if (_lenght == 0)
        {
            return;
        }
        
        _items.Add(item);
        OnAdded.Invoke(item);
    }

    public void Distribute(Item item)
    {
        if (_lenght == 0)
        {
            return;
        }

        /*
        if (_items.Contains(item) == false)
        {
            throw new Exception("Item is not exists!");
        }
        */

        OnRemoved.Invoke(item);
        _items.Remove(item);
    }
}
