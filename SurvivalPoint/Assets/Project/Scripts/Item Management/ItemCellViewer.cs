using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemCellViewer
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    
    public void AddListner(Action action)
    {
        _button.onClick.AddListener(action.Invoke);
    }
    
    public void RemoveAllListner()
    {
        _button.onClick.RemoveAllListeners();
    }

    public Sprite Picture
    {
        set => _button.image.sprite = value;
    }

    public int  Count
    {
        set => _text.text = value.ToString();
    }
}