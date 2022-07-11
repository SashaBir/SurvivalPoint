using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SelectionColorItem
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Color _selected;
    [SerializeField] private Color _unselected;

    public void Enable()
    {
        foreach (var button in _buttons)
        {
            button.onClick.AddListener(() =>
            {
                Select(button);
                foreach (var i in _buttons)  
                {
                    if (button != i)
                    {
                        Unselect(i);
                    }
                }
            });
        }
    }

    public void Disable()
    {
        foreach (var button in _buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
    
    private void Select(Button button)
    {
        button.image.color = _selected;
    }

    private void Unselect(Button button)
    {
        button.image.color = _unselected;
    }
}