using System;
using System.Collections.Generic;
using System.Linq;

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
    
    public uint Fullness { get; private set; } = 0;
    
    public uint Lenght {
        get
        {
            return _lenght;
        }
        set
        {
            if (_lenght > value)
            {
                for (int i = (int)value; i < _lenght; i++)
                {
                    Remove(_items[i]);
                }
            }
            
            _lenght = value;
        }
    }

    public void Add(IItem item)
    {
        if (_lenght == 0)
        {
            return;
        }
        
        if (_lenght <= Fullness)
        {
            return;
        }

        Fullness++;
        
        OnAdded.Invoke(item);
        
        _items.Add(item);
        item.Collect();
    }

    public void Remove(IItem item)
    {
        if (_lenght == 0)
        {
            return;
        }
        
        if (Fullness == 0)
        {
            return;
        }

        Fullness--;
        
        if (_items.Contains(item) == false)
        {
            throw new Exception("Item is not exists!");
        }

        _items.Remove(item);
        
        OnRemoved.Invoke(item);
    }
    
    public T Get<T>() where T : class
    {
        return _items.FirstOrDefault(i => i is T) as T;
    }
}
