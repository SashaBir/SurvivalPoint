using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemCell
{
    [SerializeField] private ItemCellViewer _viewer;

    private readonly ItemSlotModel _model = new ItemSlotModel();

    public IItem Current => _model.Items?.FirstOrDefault();
    
    public ItemType Type => _model.Items?.FirstOrDefault()?.Type ?? ItemType.NonType;

    public bool IsEmpty => _model.Count == 0;
    
    public Action Listner
    {
        set => _viewer.AddListner(value);
    }

    public void Add(IItem item)
    {
        if (_model.Count == 0)
        {
            _viewer.Picture = item.Icon;
        }
        
        _model.Add(item);
        _viewer.Count = _model.Count;
    }
    
    public IItem Pop()
    {
        var item = _model.Get();
        
        if (IsEmpty == true)
        {
            _viewer.Clear();
        }
        
        _viewer.Count = _model.Count;
        
        return item;
    }
}