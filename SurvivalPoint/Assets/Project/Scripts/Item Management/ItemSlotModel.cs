using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSlotModel
{
    private readonly IList<IItem> _items = new List<IItem>();

    public IEnumerable<IItem> Items => _items;

    public int Count => _items.Count;

    public void Add(IItem item)
    {
        _items.Add(item);
    }

    public IItem Get()
    {
        var item = _items.FirstOrDefault();
        _items.Remove(item);
        
        return item;
    }
}