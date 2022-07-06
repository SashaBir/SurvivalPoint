using UnityEngine;
using Zenject;

public class UiInventory : MonoBehaviour
{
    private IInventory _inventory;

    [Inject]
    private void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }
    
    public IItem Current { get; }

    public IItem TakeCurrent()
    {
        return Current;
    }
}