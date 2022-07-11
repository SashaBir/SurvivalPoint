using System;
using System.Collections.Generic;

public class Inventory : IInventory<IItemProvider>
{
    public event Action<IItemProvider> OnAdded = delegate { };

    public event Action<IItemProvider> OnRemoved = delegate { };

    private readonly IList<IItemProvider> _items;

    private uint _lenght;

    public Inventory(int lenght = 0)
    {
        _lenght = (uint)lenght;
        _items = new List<IItemProvider>(lenght);
    }

    public void Add(IItemProvider itemProvider)
    {
        if (_lenght == 0)
        {
            return;
        }
        
        _items.Add(itemProvider);
        OnAdded.Invoke(itemProvider);
    }

    public void Remove(IItemProvider itemProvider)
    {
        if (_lenght == 0)
        {
            return;
        }

        if (_items.Contains(itemProvider) == false)
        {
            throw new Exception("Item is not exists!");
        }

        OnRemoved.Invoke(itemProvider);
        _items.Remove(itemProvider);
    }
}
