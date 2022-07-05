using UnityEngine;

public interface IItem
{
    GameObject SelfGameObject { get; }
    
    Sprite Icon { get; }
}