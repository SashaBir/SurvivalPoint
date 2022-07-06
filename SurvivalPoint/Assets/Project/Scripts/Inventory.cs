using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory : IInventory
{
    public event Action<IItem> Action;
    
    private readonly IList<IItem> _items;
    
    public Inventory(int capacity = 0)
    {
        _items = new List<IItem>(capacity);
    }
    
    public void Add(IItem item)
    {
        item.Collect();
        
        _items.Add(item);
    }

    public T Get<T>() where T : class
    {
        return _items.FirstOrDefault(i => i is T) as T;
    }

    public void Remove(IItem item)
    {
        if (_items.Contains(item) == false)
        {
            throw new Exception("Item is not exists!");
        }

        _items.Remove(item);
    }
}
