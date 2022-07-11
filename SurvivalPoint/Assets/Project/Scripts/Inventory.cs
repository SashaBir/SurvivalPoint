using System;
using System.Collections.Generic;
using System.Linq;

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
    
    public uint Fullness { get; private set; } = 0;

    public bool IsExist(IItemProvider itemProvider)
    {
        return _items.Contains(itemProvider);
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

    public void Add(IItemProvider itemProvider)
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

        _items.Add(itemProvider);
        OnAdded.Invoke(itemProvider);
    }

    public void Remove(IItemProvider itemProvider)
    {
        if (_lenght == 0)
        {
            return;
        }

        if (Fullness == 0)
        {
            return;
        }

        if (_items.Contains(itemProvider) == false)
        {
            throw new Exception("Item is not exists!");
        }
        
        Fullness--;

        OnRemoved.Invoke(itemProvider);
        _items.Remove(itemProvider);
    }

    public T Get<T>() where T : class
    {
        return _items.FirstOrDefault(i => i is T) as T;
    }
}
