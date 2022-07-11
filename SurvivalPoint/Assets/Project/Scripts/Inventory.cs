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

    public bool IsExist(IItem item)
    {
        return _items.Contains(item);
    }
    
    public uint Lenght
    {
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

        _items.Add(item);
        OnAdded.Invoke(item);
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

        if (_items.Contains(item) == false)
        {
            throw new Exception("Item is not exists!");
        }
        
        Fullness--;

        OnRemoved.Invoke(item);
        _items.Remove(item);
    }

    public T Get<T>() where T : class
    {
        return _items.FirstOrDefault(i => i is T) as T;
    }
}
