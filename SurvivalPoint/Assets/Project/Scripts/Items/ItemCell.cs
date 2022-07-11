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

    public bool IsEmpty => ItemSlot is null;
    
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
        _button.image.sprite = ItemSlot.Item.Icon;
    }
    
    public void UpdateText()
    {
        _text.text = ItemSlot.Count.ToString();
    }
}