using UnityEngine;

public interface IItem : IInventoryElement
{
    GameObject Self { get; }
    
    Sprite Icon { get; }
    
    ItemType Type { get; }
}