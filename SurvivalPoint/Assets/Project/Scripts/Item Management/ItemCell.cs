using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemCell
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    
    public ItemSlot ItemSlot { get; set; }

    public bool IsEmpty => ItemSlot is null || ItemSlot.Count == 0;
    
    public void AddListner(Action action)
    {
        _button.onClick.AddListener(action.Invoke);
    }
    
    public void RemoveAllListner()
    {
        _button.onClick.RemoveAllListeners();
    }
    
    public void UpdateIcon()
    {
        Sprite icon = ItemSlot is null ? null : ItemSlot.Item.Icon;
        
        _button.image.sprite = icon;
    }
    
    public void UpdateText()
    {
        string text = ItemSlot is null ? String.Empty : ItemSlot.Count.ToString();
        
        _text.text = text;
    }
}