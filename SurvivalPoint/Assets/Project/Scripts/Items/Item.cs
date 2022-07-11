using System;
using UnityEngine;

[Serializable]
public struct Item
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    
    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public ItemType ItemType { get; private set; }
}