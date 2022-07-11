using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemCell
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;
    
    public ItemStack ItemStack { get; set; }

    public void AddListner(Action action)
    {
        _button.onClick.AddListener(action.Invoke);
    }
    
    public void RemoveAllListner()
    {
        _button.onClick.RemoveAllListeners();
    }
}