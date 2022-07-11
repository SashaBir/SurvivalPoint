using System;
using UnityEngine;

[Serializable]
public class SelectionItem
{
    [Header("Buttons")]
    [SerializeField] private ItemButton[] _itemButtons;
    
    [Header("Selected colors")]
    [SerializeField] private Color _selected;
    [SerializeField] private Color _unselected;

    public void Enable()
    {
        foreach (var i in _itemButtons)
        {
            i.AddListner(() =>
            {
                Select(i);
                foreach (var item in _itemButtons)
                {
                    if (i == item)
                    {
                        continue;
                    }
                    
                    Unselect(item);
                }
            });
        }
    }

    public void Disable()
    {
        foreach (var itemButton in _itemButtons)
        {
            itemButton.RemoveAllListner();
        }
    }

    private void Select(ItemButton itemButton)
    {
        itemButton.Color = _selected;
    }

    private void Unselect(ItemButton itemButton)
    {
        itemButton.Color = _unselected;
    }
}