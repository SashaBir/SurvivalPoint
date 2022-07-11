using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemButton
{
    [SerializeField] private Button _button;

    public Color Color
    {
        set
        {
            _button.image.color = value;
        }
    }
    
    public void AddListner(Action action)
    {
        _button.onClick.AddListener(action.Invoke);
    }

    public void RemoveAllListner()
    {
        _button.onClick.RemoveAllListeners();
    }
}