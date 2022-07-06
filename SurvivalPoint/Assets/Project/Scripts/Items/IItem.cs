using UnityEngine;

public interface IItem
{
    GameObject Prefab { get; }
    
    Sprite Icon { get; }

    void Collect();
}