using UnityEngine;

public interface IInventoryElement
{
    bool CanTaken { get; }
    
    void Take();
    
    void Upload();
}